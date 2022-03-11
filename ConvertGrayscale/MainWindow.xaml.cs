using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows;
//using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConvertGrayscale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\wallpaper\\wallpaper";
            ofd.Filter = "Jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                string path = ofd.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(path));
                imageOriginal.Source = bitmap; 


                Bitmap btm = new Bitmap(path);
                
                int height = btm.Height;
                int width = btm.Width;

                Color p;
                
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        p = btm.GetPixel(j, i);
                        int a = p.R; 
                        int b = p.G;
                        int c = p.B;
                        int d = p.A;

                        int avg = (a + b + c) / 3;

                        btm.SetPixel(j, i, Color.FromArgb(d, avg, avg, avg));
                    }
                }
                string pathToSave = System.AppDomain.CurrentDomain.BaseDirectory + "\\grayscale.png";
                btm.Save(pathToSave);
                imageGray.Source = new BitmapImage(new Uri(pathToSave));
            }
        }

        //private System.Windows.Media.Color GetAverageColor(BitmapSource bitmap)
        //{
        //    var format = bitmap.Format;
        //    if (format != PixelFormats.Bgr24 &&
        //        format != PixelFormats.Bgr32 &&
        //        format != PixelFormats.Bgra32 &&
        //        format != PixelFormats.Pbgra32)
        //    {
        //        throw new InvalidOperationException("BitmapSource must have Bgr24, Bgr32, Bgra32 or Pbgra32 format");
        //    }
        //    var width = bitmap.PixelWidth;
        //    var height = bitmap.PixelHeight;
        //    var numPixels = width * height;
        //    var bytesPerPixel = format.BitsPerPixel / 8;
        //    var pixelBuffer = new byte[numPixels * bytesPerPixel];
        //    bitmap.CopyPixels(pixelBuffer, width * bytesPerPixel, 0);
        //    long blue = 0;
        //    long green = 0;
        //    long red = 0;
        //    for (int i = 0; i < pixelBuffer.Length; i += bytesPerPixel)
        //    {
        //        blue += pixelBuffer[i];
        //        green += pixelBuffer[i + 1];
        //        red += pixelBuffer[i + 2];
        //    }
        //    return System.Windows.Media.Color.FromRgb((byte)(red / numPixels), (byte)(green / numPixels), (byte)(blue / numPixels));
        //}
    }
}
