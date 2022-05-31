using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteApp
{
    public partial class App : Application
    {
        public App(IProductRepository productRepository)
        {
            InitializeComponent();

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
