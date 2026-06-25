using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;

namespace MyStore.Repository
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CategoryRepository(AppDbContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }

        public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        //adding new cat
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(p => p.CategoryId == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var cat = await GetByIdAsync(id);
            if (cat != null)
            {
                //is deleted true
                //product.IsDeleted = true;
                //await _context.SaveChangesAsync();


                if (cat.ImageUrl.Length > 0)
                    DeletePhysicalFile(cat.ImageUrl);
                _context.Categories.Remove(cat);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Category not found with {id}");
            }
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

        //public async Task DeleteCatAsync(int id)
        //{
        //    var cat = await GetByIdAsync(id);
        //    if (cat != null)
        //    {
        //        //is deleted true
        //        //product.IsDeleted = true;
        //        //await _context.SaveChangesAsync();


        //        if (cat.ImageUrl.Length > 0)
        //            DeletePhysicalFile(cat.ImageUrl);

        //        _context.Categories.Remove(cat);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new Exception($"Product not found with {id}");
        //    }
        //}

    }
}
