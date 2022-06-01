using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteApp
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            Sqlite.Standard.IProductRepository productRepository = Sqlite.Standard.ProductRepository.Instance;

            MainPage = new ProductsPage()
            {
                BindingContext = new ProductsViewModel(productRepository),
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
