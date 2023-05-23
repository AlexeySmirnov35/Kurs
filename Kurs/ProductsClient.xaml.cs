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
using System.Windows.Shapes;

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
            listview.ItemsSource = ZooBdEntities1.GetContext().Product.ToList();
        }
    }
}