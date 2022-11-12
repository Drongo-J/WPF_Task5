using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_Task5.ViewModel;
using System.Windows.Media;
using WPF_Task5.Commands;
using ToastNotifications;
using ToastNotifications.Position;
using System.Windows;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace WPF_Task5.Models
{
    public class ProductUCViewModel : BaseViewModel
    {
        public RelayCommand AddToBasketCommand { get; set; }

        public Product Product { get; set; }

        public ProductUCViewModel(Product product)
        {
            Product = product;

            AddToBasketCommand = new RelayCommand((a) =>
            {
                Notifier notifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: App.Current.MainWindow,
                        corner: Corner.TopLeft,
                        offsetX: 10,
                        offsetY: 10);

                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(3),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(1));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                });
                if (App.InBasketSide)
                {
                    App.ProductsInBasket.Remove(Product);
                    notifier.ShowSuccess("Product was removed from basket.");
                    App.MainWindowViewModel.AddProductsToView(App.ProductsInBasket, @"..\..\Images\minus.png");
                }
                else
                {
                    App.ProductsInBasket.Add(Product);
                    notifier.ShowSuccess("Product was added to basket. Check your basket");
                }
            });
            Product = product;
        }
    }
}
