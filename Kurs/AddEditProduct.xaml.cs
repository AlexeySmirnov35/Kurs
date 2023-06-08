using Kurs.AppData;
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
using System.Windows.Markup;
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
        private byte[] img = null;
        private Product _product = new Product();
        
      /*  public AddEditProduct()
        {
            InitializeComponent();
        }*/
        public AddEditProduct(Product selectGlavPage)
        {
            InitializeComponent();
            if (selectGlavPage != null)
            {
                _product = selectGlavPage;
            }
            
          
            AppConnect.zooBd = new ZooBdEntities1();
            DataContext = _product;
            tbAmimal.ItemsSource = ZooBdEntities1.GetContext().TypeAnimals.ToList();
            tbProvider.ItemsSource = ZooBdEntities1.GetContext().Povider.ToList();
            tbCat.ItemsSource = ZooBdEntities1.GetContext().Category.ToList();
        }
        OpenFileDialog fileOpen = new OpenFileDialog();
        private void Image_Load(object sender, RoutedEventArgs e)
        {


            fileOpen.Title = "imgSele";
            fileOpen.Multiselect = false;
            fileOpen.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (fileOpen.ShowDialog() == true)
            {

                img = File.ReadAllBytes(fileOpen.FileName);
                ImageSerice.Source = new ImageSourceConverter()
                   .ConvertFrom(img) as ImageSource;
            }
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_product.NameProduct))
                errors.AppendLine("Укажите название продукта!");
            if (string.IsNullOrWhiteSpace(_product.Description))
                errors.AppendLine("Напишите описание!");
            if (_product.PriceProd < 1)
                errors.AppendLine("Цену должна быть больше 1!");
            if (_product.Count < 1 )
                errors.AppendLine("Количество должно быть больше 1!");
            if ( _product.PriceProd == null)
                errors.AppendLine("Укажите цену!");
            if (_product.Count == null)
                errors.AppendLine("Укажите количество!");
            if (_product.Povider == null)
                errors.AppendLine("Укажите производителя!");
            if (_product.TypeAnimals == null)
                errors.AppendLine("Укажите категорию зверька!");
            if ( _product.Massa == null)
                errors.AppendLine("Укажите массу!");
            if (_product.Massa < 1)
                errors.AppendLine("Масса должна быть больше 1!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_product.Id_Prod == 0)
            {
                var anim = tbAmimal.SelectedItem as TypeAnimals;
                
                var prov = tbProvider.SelectedItem as Povider;
               //var animal=ZooBdEntities1.GetContext().TypeAnimals.Where(x=>x.NameType==tbAmimal.SelectedItem.ToString()).FirstOrDefault;
                var prod = new Product
                {
                    NameProduct=tbName.Text,
                    Count=Convert.ToInt32(tbCount.Text),
                    PriceProd=Convert.ToInt32(tbPrice.Text),
                   Id_TypeAnim=anim.Id_Anim ,
                    Id_Provid=prov.Id_Provider,
                    PhotoProduct=img,
                    Description=tbDesc.Text,
                    Massa=Convert.ToInt32(tbMassa.Text)
                };
                ZooBdEntities1.GetContext().Product.Add(prod);
                
            }
                

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

        private void Btn_back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }
    }   
}
