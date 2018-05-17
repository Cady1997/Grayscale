using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageProcessing
{
    public class Grayscale
    {     
        public Bitmap ToGrayByPixel(Bitmap bmp)
        {


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    byte gray = (byte)(.21 * c.R + .72 * c.G + .07 * c.B);
                    bmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return bmp;
        }
        public SaveFileDialog Save(Bitmap bmp)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (save.ShowDialog() == true)
            {
                try
                {
                    bmp.Save(save.FileName, ImageFormat.Jpeg);
                    MessageBox.Show("Zapisano");
                }
                catch
                {
                    MessageBox.Show("Najpierw wczytaj obraz...");
                }
            }
            return null;
        }
        public BitmapImage ConvToBitmapImage(Bitmap bitmap) // zamiana z bitmap na bitmapimage
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    } 
}
