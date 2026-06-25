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
    public class EditModel : PageModel
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IUploudService _uploud;

        public EditModel(ProductRepository productRepository, CategoryRepository categoryRepository, IUploudService uploud)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._uploud = uploud;
        }
        [BindProperty]
        public ProductViewModel Product { get; set; }
        public SelectList Categories { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");

            Product p = await _productRepository.GetByIdAsync(id);

            if(p is null)
            {
                return NotFound();
            }
            Product = new ProductViewModel();
            Product.Name = p.Name;
            Product.Price = p.Price;
            Product.CategoryId = p.CategoryId;
            Product.StockQuantity = p.StockQuantity;
            Product.ImageUrl = p.ImageUrl;
            Product.ProductId = p.ProductId;

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {


            if (!ModelState.IsValid)
            {
                Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
                return Page();
            }

            Product newProduct = new Product
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                CategoryId = Product.CategoryId,
                Updated = DateTime.Now,
                ImageUrl = Product.ImageUrl
            };
            if(Product.Image != null)
            {
                try
                {
                    newProduct.ImageUrl = _uploud.UploudFile(Product.Image);
                }
                catch (Exception ex)
                {
                    Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
                    ModelState.AddModelError("Product.Image", ex.Message);
                    return Page();
                }
            }
            

            await _productRepository.UpdateAsync(newProduct);
            return RedirectToPage("Index");
        }
    }
}
