using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Sqlite.Standard;
using Xamarin.Forms;
using System.Windows.Input;



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

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }

       /* public override string ToString()
        {
            return string.Format("({0}) {1}, {2}", Id, Name, Gender, Size, Color, Date, Address);
        }*/
        public System.Windows.Input.ICommand RefreshCommand
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
                        Name = this.Name,
                        Gender = this.Gender,
                        Size = this.Size,
                        Color = this.Color,
                        Date = this.Date,
                        Address = this.Address

                    };
                    await _productsRepository.AddProductAsync(product);
                });
            }
        }

        public ProductsViewModel(Sqlite.Standard.IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
