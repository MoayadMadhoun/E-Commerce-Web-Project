
namespace MyStore.Services
{
    public interface IUploudService
    {
        string? UploudFile(IFormFile Upload, string subFolder="products");
    }
}