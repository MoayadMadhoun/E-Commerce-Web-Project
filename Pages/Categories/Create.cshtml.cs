using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Repository;
using MyStore.Services;

namespace MyStore.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IUploudService _upload;
        private readonly AppDbContext _context;

        public CreateModel(CategoryRepository categoryRepository, IUploudService upload,AppDbContext context)
        {
            this._categoryRepository = categoryRepository;
            this._upload = upload;
            this._context = context;
        }

        [BindProperty]
        public Category Category { get; set; }
        [BindProperty]
        public IFormFile? catImage { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
            
            if(catImage is null)
            {
                ModelState.AddModelError("catImage", "Please choose an image");
                return Page();
            }

            try
            {
                Category.ImageUrl = _upload.UploudFile(Upload: catImage, subFolder: "categories");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Product.Image", ex.Message);
                return Page();
            }
            var exists = await _context.Categories
            .AnyAsync(c => c.Name.ToLower() == Category.Name.ToLower());

            if (exists)
            {
                ModelState.AddModelError("Category.Name", " The category name is already exist, chose another name");
                return Page();
            }

            await _categoryRepository.AddAsync(Category);
            return RedirectToPage("Index");


        }
    }
}
