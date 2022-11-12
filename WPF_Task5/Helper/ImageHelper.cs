using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Task5.Helper
{
    public class ImageHelper
    {
        public static ImageSource StringToImageSource(string source)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(source, UriKind.RelativeOrAbsolute);
            bi3.CacheOption = BitmapCacheOption.OnLoad;
            bi3.EndInit();
            return bi3;
        }
    }
}
