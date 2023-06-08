using Kurs.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для GlavPage.xaml
    /// </summary>
    public partial class GlavPage : Page
    {
        public GlavPage()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
           
        }
        
        private void Btn_Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProduct(null));
            

        }

        private void Page_IsVis(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        if (Visibility == Visibility.Visible)
            {
                ZooBdEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                listview.ItemsSource=ZooBdEntities1.GetContext().Product.ToList();
            }
            
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddEditProduct((sender as System.Windows.Controls.Button).DataContext as Product));
        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {
            var productDelete = listview.SelectedItems.Cast<Product>().ToList();
            if(MessageBox.Show($"Вы дейстиветльно хотите удалить эти {productDelete.Count()} элемента!?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZooBdEntities1.GetContext().Product.RemoveRange(productDelete);
                    ZooBdEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Удаление прошло успешно");
                    listview.ItemsSource = ZooBdEntities1.GetContext().Product.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void UpdateProduct()
        {
            var curProduct = ZooBdEntities1.GetContext().Product.ToList();
           

            curProduct = curProduct.Where(p => p.NameProduct.ToLower().Contains(TboxSerch.Text.ToLower())).ToList();
            listview.ItemsSource = curProduct.OrderBy(p => p.Count).ToList();

        }
       

        private void Tbox_Search(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
