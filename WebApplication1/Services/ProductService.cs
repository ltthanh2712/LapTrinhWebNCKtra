using System;
using WebApplication1.Interfaces;
using WebApplication1.Models;
namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly SportProductContext _context;
        public ProductService(SportProductContext context)
        {
            _context = context;
        }
        public Product GetFirstProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).FirstOrDefault();
        }
        public void UpdateProduct(int id, Product newProduct, string webRootPath) { 
            var product = _context.Products.Find(id);
            if (product == null) return;
            product.NamePro = newProduct.NamePro;
            product.DecriptionPro = newProduct.DecriptionPro;
            if (newProduct.ImageUpload != null && newProduct.ImageUpload.Length > 0)
            {
                var uploadsFolder = Path.Combine(webRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newProduct.ImageUpload.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    newProduct.ImageUpload.CopyTo(stream);
                }

                product.ImagePro = fileName;
            }
            product.Category = newProduct.Category;
            product.Price = newProduct.Price;
            product.ManufacturingDate = newProduct.ManufacturingDate;

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }   
}
