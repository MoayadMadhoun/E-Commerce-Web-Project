using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Repository;
using MyStore.Services;
using StartASP.Repositories;

namespace MyStore.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IUploudService _upload;
        private readonly AppDbContext _context;

        public EditModel(CategoryRepository categoryRepository, IUploudService uploud, AppDbContext context)
        {
            this._categoryRepository = categoryRepository;
            this._upload = uploud;
            this._context = context;
        }
        [BindProperty]
        public Category Category { get; set; }
        [BindProperty]
        public IFormFile? catImage { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Category = await _categoryRepository.GetByIdAsync(id);

            if (Category is null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (catImage != null)
            {
                try
                {
                    Category.ImageUrl = _upload.UploudFile(Upload: catImage, subFolder: "categories");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Category.ImageUrl", ex.Message);
                    return Page();
                }
            }
            //var exists = await _context.Categories
            //.AnyAsync(c => c.Name.ToLower() == Category.Name.ToLower());

            //if (exists)
            //{
            //    ModelState.AddModelError("Category.Name", " The category name is already exist, chose another name");
            //    return Page();
            //}
            await _categoryRepository.UpdateAsync(Category);
            return RedirectToPage("Index");
        }
    }
}
