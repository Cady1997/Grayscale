using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Grayscale
{
    public interface IMainWindow
    {
        string BitmapPath { get; set; }

        Image GrayScale(BitmapImage Img);
        void InitializeComponent();
        void load_image(object sender, RoutedEventArgs e);
    }
}