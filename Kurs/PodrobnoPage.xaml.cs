using Kurs.AppData;
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

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для PodrobnoPage.xaml
    /// </summary>
    public partial class PodrobnoPage : Page
    {
        private Product _product = new Product();
        public PodrobnoPage(Product selectedProduct)
        {
            InitializeComponent();
            if (selectedProduct != null)
            {
                _product = selectedProduct;
            }
            AppConnect.zooBd = new ZooBdEntities1();
            DataContext = _product;
       //   tbAmimal.ItemsSource = ZooBdEntities1.GetContext().TypeAnimals.ToList();
          //  tbProvider.ItemsSource = ZooBdEntities1.GetContext().Povider.ToList();
        }

        private void Btn_Podr(object sender, RoutedEventArgs e)
        {

        }
      
      
           
           
               
           
           
           
        
    }
    
}
