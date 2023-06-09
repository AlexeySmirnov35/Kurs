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
    /// Логика взаимодействия для GlavProductClient.xaml
    /// </summary>
    public partial class GlavProductClient : Page
    {
        public GlavProductClient()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
            var allTypes = ZooBdEntities1.GetContext().TypeAnimals.ToList();
            allTypes.Insert(0, new TypeAnimals
            {
                NameType = "Все категории"
            });
          // ComboType.ItemsSource = allTypes;
            //ComboType.SelectedIndex = 0;

            UpdateProduct();
        }
        private void UpdateProduct()
        {
            var curProduct = ZooBdEntities1.GetContext().Product.ToList();
           /* if (ComboType.SelectedIndex > 0)
            {
               var anim=ComboType.SelectedItem as TypeAnimals;
                curProduct=curProduct.Where(anim).ToList();
                curProduct=curProduct.Where(p => p.TypeAnimals.Contains(ComboType.SelectedItem as TypeAnimals)).ToList();
            }*/

            curProduct = curProduct.Where(p => p.NameProduct.ToLower().Contains(TboxSerch.Text.ToLower())).ToList();
            LVieew.ItemsSource = curProduct.OrderBy(p => p.Count).ToList();

        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void Tbox_Search(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }
        private void Page_IsVis(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (Visibility == Visibility.Visible)
            {
                ZooBdEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LVieew.ItemsSource = ZooBdEntities1.GetContext().Product.ToList();
            }

        }
        private void Btn_Podr(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PodrobnoPage((sender as Button).DataContext as Product));
        }

        private void Btn_LogOut(object sender, RoutedEventArgs e)
        {
            ProductsClient productsClient = new ProductsClient();
            productsClient.Close();
            
        }
    }
}
