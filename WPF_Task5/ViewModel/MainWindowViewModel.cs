using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task5.Commands;
using WPF_Task5.Helper;
using WPF_Task5.Models;
using WPF_Task5.Views;

namespace WPF_Task5.ViewModel
{
    public class MainWindowViewModel
    {
        public RelayCommand AllProductsCommand { get; set; }
        public RelayCommand BasketCommand { get; set; }

        public MainWindowViewModel()
        {
            List<Product> products = GetProducts();
            AddProductsToView(products);

            AllProductsCommand = new RelayCommand((a) =>
            {
                AddProductsToView(products);
                App.InBasketSide = false;
            });

            BasketCommand = new RelayCommand((b) =>
            {
                App.InBasketSide = true;
                App.ProductsWrapPanel.Children.Clear();
                if (App.ProductsInBasket.Count == 0)
                {
                    var noProductUC = new NoProductUC();
                    App.ProductsWrapPanel.Children.Add(noProductUC);
                    return;
                }
                AddProductsToView(App.ProductsInBasket, @"..\..\Images\minus.png");
            });
        }

        public void AddProductsToView(List<Product> products,string imagesource = @"..\..\Images\add.png")
        {
            App.ProductsWrapPanel.Children.Clear();
            foreach (var product in products)
            {
                //product.ImageSource = ImageHelper.StringToImageSource(imagesource);
                var productView = new ProductUC();
                productView.Image.Source = ImageHelper.StringToImageSource(imagesource);
                var productViewModel = new ProductUCViewModel(product);
                productView.DataContext = productViewModel;
                App.ProductsWrapPanel.Children.Add(productView);
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Product p1 = new Product("$234.00", "Apple AirPods Pro", ImageHelper.StringToImageSource(@"..\..\Images\product1.jpg"));
            Product p2 = new Product("$90.00", "4K Fire TV ", ImageHelper.StringToImageSource(@"..\..\Images\product2.jpg"));
            Product p3 = new Product("$434.00", "Aria air", ImageHelper.StringToImageSource(@"..\..\Images\product3.jpg"));
            Product p4 = new Product("$34.00", "Beats Earbuds", ImageHelper.StringToImageSource(@"..\..\Images\product4.jpg"));
            Product p5 = new Product("$76.00", "Tv Streaming Device", ImageHelper.StringToImageSource(@"..\..\Images\product5.jpg"));
            Product p6 = new Product("$1243.00", "LG OLED TV", ImageHelper.StringToImageSource(@"..\..\Images\product6.jpg"));
            Product p7 = new Product("$345.00", "Wireless headphone", ImageHelper.StringToImageSource(@"..\..\Images\product7.jpg"));
            Product p8 = new Product("$216.00", "Wireless Earbuds", ImageHelper.StringToImageSource(@"..\..\Images\product8.jpg"));
            Product p9 = new Product("$55.00", "Samsung drive", ImageHelper.StringToImageSource(@"..\..\Images\product9.jpg"));
            Product p10 = new Product("$2456.00", "QLED TV", ImageHelper.StringToImageSource(@"..\..\Images\product10.jpg"));
            Product p11 = new Product("$1200.00", "Fire Tablet", ImageHelper.StringToImageSource(@"..\..\Images\product11.jpg"));
            Product p12 = new Product("$1764.00", "Sony TV", ImageHelper.StringToImageSource(@"..\..\Images\product12.jpg"));

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);
            products.Add(p6);
            products.Add(p7);
            products.Add(p8);
            products.Add(p9);
            products.Add(p10);
            products.Add(p11);
            products.Add(p12);
            return products;
        }
    }
}
