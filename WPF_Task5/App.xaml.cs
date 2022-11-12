using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_Task5.Models;
using WPF_Task5.ViewModel;

namespace WPF_Task5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WrapPanel ProductsWrapPanel { get; internal set; }
        public static List<Product> ProductsInBasket { get; internal set; } = new List<Product>();
        public static MainWindowViewModel MainWindowViewModel { get; internal set; }
        public static bool InBasketSide { get; set; } = false;
    }
}
