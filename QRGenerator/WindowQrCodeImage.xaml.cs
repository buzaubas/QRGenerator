using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QRGenerator
{
    /// <summary>
    /// Логика взаимодействия для WindowQrCodeImage.xaml
    /// </summary>
    public partial class WindowQrCodeImage : Window
    {
        public WindowQrCodeImage(byte[] buffer, int height, int width)
        {
            InitializeComponent();

            GetImage(buffer, qrImage);
            this.Height = height;
            this.Width = width;
        }

        private void GetImage(byte[] rawBytes, Image img)
        {
            byte[] imageBytes = rawBytes;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageBytes);
            bitmapImage.CreateOptions = BitmapCreateOptions.None;
            bitmapImage.CacheOption = BitmapCacheOption.Default;
            bitmapImage.EndInit();

            
            this.Dispatcher.Invoke((Action)(() => { img.Source = bitmapImage; }));
        }
    }
}
