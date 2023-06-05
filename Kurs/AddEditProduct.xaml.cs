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
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Page
    {
        private Product _product = new Product();
        public AddEditProduct(Product selectGlavPage)
        {
            InitializeComponent();  
            if(selectGlavPage != null)
            {
                _product = selectGlavPage;
            }
            AppConnect.zooBd = new ZooBdEntities1();
            DataContext = _product;
            tbAmimal.ItemsSource = ZooBdEntities1.GetContext().TypeAnimals.ToList();
            tbProvider.ItemsSource = ZooBdEntities1.GetContext().Povider.ToList();
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_product.NameProduct))
                errors.AppendLine("Укажите название продукта");
            if (string.IsNullOrWhiteSpace(_product.Description))
                errors.AppendLine("Напишите описание");
            if (_product.PriceProd<1 && _product.PriceProd==null)
                errors.AppendLine("Укажите цену большу 1");
            if (_product.Count < 1 && _product.Count==null)
                errors.AppendLine("Укажите количество больше 1");
            if(_product.Povider==null)
                errors.AppendLine("Укажите производителя");
            if (_product.TypeAnimals == null)
                errors.AppendLine("Укажите категорию зверька");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            if (_product.Id_Prod == 0)
                ZooBdEntities1.GetContext().Product.Add(_product);

            try
            {
                ZooBdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Save");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
     


    }
}
