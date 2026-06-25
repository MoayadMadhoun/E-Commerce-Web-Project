using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using StartASP.Repositories;

namespace MyStore.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public DeleteModel(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Product = await _productRepository.GetByIdAsync(id);
            if(Product is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Product = await _productRepository.GetByIdAsync(id);
            if (Product is null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);

            return RedirectToPage("Index");

        }
    }
}
