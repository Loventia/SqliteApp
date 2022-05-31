using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SqliteApp
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private readonly IProductRepository _productsRepository;
        private IEnumerable<Product> _products;

        public IEnumerable<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public double ProductPrice { get; set; }

        public string ProductTitle { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Products = await _productsRepository.GetProductsAsync();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var product = new Product
                    {
                        Title = ProductTitle,
                        Price = ProductPrice,
                    };
                    await _productsRepository.AddProductAsync(product);
                });
            }
        }

        public ProductsViewModel(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
