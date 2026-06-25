using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using MyStore.Services;
using StartASP.Repositories;

namespace MyStore.Pages.Products
{
    public class ImagesModel : PageModel
    {
        private readonly ProductRepository _productRepository;
        private readonly IUploudService _uploud;

        public ImagesModel(ProductRepository productRepository, IUploudService uploud)
        {
            _productRepository = productRepository;
            _uploud = uploud;
        }
        public Product Product { get; set; }

        public List<ProductImages> Images { get; set; } = new List<ProductImages>();


        [BindProperty]
        public List<IFormFile> ExtraImages { get; set; }

        private async Task CreateViewModelAsync(int productId)
        {
            Product = await _productRepository.GetByIdAsync(productId);

            if (Product is null) return;

            Images = await _productRepository.GetImagesAsync(productId);
        }
        public async Task<IActionResult> OnGet(int productId)
        {
            await CreateViewModelAsync(productId);
            if (Product is null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost(int productId)
        {
            if (!ModelState.IsValid)
            {
                await CreateViewModelAsync(productId);

                return Page();
            }
            if (ExtraImages != null && ExtraImages.Any())
            {
                foreach (var image in ExtraImages)
                {
                    try
                    {
                        var imgUrl = _uploud.UploudFile(image);
                        await _productRepository.AddImg(new ProductImages { ProductId = productId, ImageUrl = imgUrl });
                    }
                    catch (Exception ex)
                    {
                        await CreateViewModelAsync(productId);
                        ModelState.AddModelError("ExtraImages", ex.Message);
                        return Page();
                    }
                }
            }
            return RedirectToPage(new { productId = productId });
        }
        public async Task<IActionResult> OnPostDelete(int productId, int imageId)
        {
            await _productRepository.DeleteImage(imageId);
            
            return RedirectToPage(new { productId = productId });

        }


    }
}
