﻿using Kurs.AppData;
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
        public AddEditProduct()
        {
            InitializeComponent();  
            AppConnect.zooBd = new ZooBdEntities1();
            DataContext = _product;
            tbAmimal.ItemsSource = ZooBdEntities1.GetContext().TypeAnimals.ToList();
            tbProvider.ItemsSource = ZooBdEntities1.GetContext().Povider.ToList();
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_product.Id_Prod == 0)
            {
                ZooBdEntities1.GetContext().Product.Add(_product);
            }
            try
            {
                ZooBdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
     

        private void Page_IsVis(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ZooBdEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
               // listview.ItemsSource=ZooBdEntities1.GetContext().Product.ToList();
            }
        }
    }
}