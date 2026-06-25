using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Models;
using MyStore.ModelsView;
using MyStore.Repository;
using MyStore.Services;
using StartASP.Repositories;

namespace MyStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IUploudService _uploud;
        private readonly UserManager<AppUser> _userManager;

        public AppUser user { get; set; }


           
        public CreateModel(ProductRepository productRepository, CategoryRepository categoryRepository, IUploudService uploud, UserManager<AppUser> userManager)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._uploud = uploud;
            this._userManager = userManager;
        }
        [BindProperty]
        public ProductViewModel Product { get; set; }
        public SelectList Categories { get; set; }


        public async Task OnGet()
        {
            // colliction, dataValueField, dataTextField
            Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
                return Page();
            }

            if(Product.Image is null)
            {
                Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
                ModelState.AddModelError("Product.Image", "Please choose an image");
                return Page();
            }
            Product newProduct = new Product
            {
                Name = Product.Name,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                CategoryId = Product.CategoryId,
                Publiser = user?.FullName
            };

            try
            {
                newProduct.ImageUrl = _uploud.UploudFile(Product.Image);
            }
            catch(Exception ex)
            {
                Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
                ModelState.AddModelError("Product.Image", ex.Message);
                return Page();
            }

            await _productRepository.AddAsync(newProduct);

            return RedirectToPage("Index");
        }
    }
}
