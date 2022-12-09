using RestSharp;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QRGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerateQrCode_Click(object sender, RoutedEventArgs e)
        {
            //getting size
            //var rb = rdSize.Children;
            //int size = 0;
            //foreach (var item in rdSize.Children)
            //{
            //    RadioButton rb = (RadioButton)item;

            //    if ((bool)rb.IsChecked) //без bool не уверен что там не нулл
            //    {
            //        size = Convert.ToInt32(rb.Content);
            //        break;
            //    }
            //}

            RadioButton rb_ = rdSize.Children.Cast<RadioButton>().FirstOrDefault(item => (bool)item.IsChecked); //LINQ

            var restClient = new RestClient("http://qrcoder.ru/code");

            var request = new RestRequest(String.Format("?{0}&{1}&0", tbxQrText.Text, rb_), Method.Get);

            RestResponse response = restClient.Execute(request);    
            
            var img = response.RawBytes;

            WindowQrCodeImage wqci = new WindowQrCodeImage(img, 200, 200);
            wqci.Show();
        }
    }
}
