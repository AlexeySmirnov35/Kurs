using Kurs.AppData;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для ProductsClient.xaml
    /// </summary>
    public partial class ProductsClient : Window
    {
        public ProductsClient()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
             MnFrame.Navigate(new GlavProductClient());
        }
      
    }
}
