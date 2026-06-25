using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;


namespace StartASP.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductRepository(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IQueryable<Product> GetAllQueryable() => _context.Products.Include(p => p.category).AsNoTracking().AsQueryable();
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.category).ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.category)
                //single
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }


        // searching by title
        public async Task<IEnumerable<Product>> Get(string query)
        {


            return await _context.Products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToListAsync();


        }
        //add async
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }
        //update asysc
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                //is deleted true
                //product.IsDeleted = true;
                //await _context.SaveChangesAsync();


                if (product.ImageUrl.Length > 0)
                    DeletePhysicalFile(product.ImageUrl);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Product not found with {id}");
            }
        }

        public async Task AddImg(ProductImages productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteImage(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                return;

            DeletePhysicalFile(image.ImageUrl);
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProductImages>> GetImagesAsync(int productId)

        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId
                ).ToListAsync();
        }


        private void DeletePhysicalFile(string imgurl)
        {
            if (string.IsNullOrEmpty(imgurl))
                return;
            //wwwroot/images/...
            var filePath = Path.Combine(_environment.WebRootPath, imgurl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public async Task<List<Product>> GetAllCategoryProductsAsync(int catId)
        {
            return await _context.Products.Where(p => p.CategoryId == catId).ToListAsync();
        }
    }
}