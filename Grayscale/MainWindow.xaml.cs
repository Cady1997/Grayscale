using Microsoft.Win32;
using System;

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageProcessing;
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace Grayscale
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        SaveFileDialog save = new SaveFileDialog();
        OpenFileDialog open = new OpenFileDialog();
        ImageProcessing.Grayscale img = new ImageProcessing.Grayscale();

        Bitmap bmp;

        public void load_gray(object sender, RoutedEventArgs e)
        {

            Stopwatch s = new Stopwatch();

            Thread.Sleep(10000);
            TimeSpan ts = s.Elapsed;
            s.Start();
            after.Source = img.ConvToBitmapImage(img.ToGrayByPixel(bmp));
            s.Stop();
            string elapsedTime = String.Format("Czas: {0} ms", s.Elapsed.TotalMilliseconds);


            timer.Text = elapsedTime;
        }


        public void load_image(object sender, RoutedEventArgs e)
        {
            open.Filter = "JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";

            if (open.ShowDialog() == true)
            {
                bmp = (Bitmap)Bitmap.FromFile(open.FileName);

                before.Source = img.ConvToBitmapImage(bmp);


            }
        }
        public void save_image(object sender, RoutedEventArgs e)
        {
            ImageProcessing.Grayscale img = new ImageProcessing.Grayscale();
            img.Save(img.ToGrayByPixel(bmp));
        }
    }
}
