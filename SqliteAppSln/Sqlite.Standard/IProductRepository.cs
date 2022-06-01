using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqlite.Standard
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<bool> AddProductAsync(Product product);

        Task<bool> UpdateProductAsync(Product product);

        Task<bool> RemoveProductAsync(int id);

    }
}
