using API.Models;
using System.Collections.Generic;

namespace API.Services.Interfaces
{
    public interface IProductRepository
    {
        Product AddProduct(Product newProduct);

        Product UpdateProduct(string productId);

        void DeleteProduct(string productId);

        Product GetProduct(string productId);

        IEnumerable<Product> ListProducts();
    }
}
