using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SQLite;

namespace Sqlite.Standard
{ 

    public class ProductRepository: IProductRepository 
    {

        private SQLite.SQLiteAsyncConnection _sqlitConnection;

        public static IProductRepository Instance = new ProductRepository();

        public  ProductRepository()
        {
            var sqliteFilename = "ordering.db3";

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            path = path + sqliteFilename;

            _sqlitConnection = new SQLite.SQLiteAsyncConnection(path, SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _sqlitConnection.CreateTableAsync<Product>().Wait();
        }



        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product  = await _sqlitConnection.Table<Product>().Where(x => x.Id == id).FirstOrDefaultAsync();

                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                int tracking = await _sqlitConnection.InsertAsync(product);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                var tracking = await _sqlitConnection.UpdateAsync(product);

 
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                var product = await _sqlitConnection.DeleteAsync(id);


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

 
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _sqlitConnection.Table <Product>().ToListAsync();

                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
