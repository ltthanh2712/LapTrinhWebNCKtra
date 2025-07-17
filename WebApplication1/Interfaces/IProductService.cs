using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProductService
    {
        Product GetFirstProducts();
        void UpdateProduct(int id, Product product, string webRootPath);
    }
}
