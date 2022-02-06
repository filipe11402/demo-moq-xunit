using API.Models;
using System.Collections.Generic;

namespace API.Services.Interfaces
{
    public interface IProductRepository
    {
        Product AddProduct(Product newProduct);

        Product UpdateProduct(int productId);

        void DeleteProduct(int productId);

        Product GetProduct(int productId);

        IEnumerable<Product> ListProducts();
    }
}
