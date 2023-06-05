using Kurs.AppData;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            var allTypes=ZooBdEntities1.GetContext().TypeAnimals.ToList();
            allTypes.Insert(0, new TypeAnimals
            {
                NameType="Все категории"
            });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;

            UpdateProduct();
        }
        private void UpdateProduct()
        {
            var curProduct=ZooBdEntities1.GetContext().Product.ToList();
            if (ComboType.SelectedIndex > 0) 
            { 
             //  curProduct=curProduct.Where(p => p.TypeAnimals.Contains(ComboType.SelectedItem as TypeAnimals)).ToList();
            }
                
            curProduct=curProduct.Where(p=>p.NameProduct.ToLower().Contains(TboxSerch.Text.ToLower())).ToList();
            LVieew.ItemsSource=curProduct.OrderBy(p=>p.Count).ToList();

        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void Tbox_Search(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
