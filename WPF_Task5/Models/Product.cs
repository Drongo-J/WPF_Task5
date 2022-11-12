using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_Task5.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public ImageSource ImageSource { get; set; }

        public Product(string price, string name, ImageSource imageSource)
        {
            Name = name;
            Price = price;
            ImageSource = imageSource;
        }
    }
}
