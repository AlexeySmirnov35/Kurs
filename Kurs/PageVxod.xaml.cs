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
    /// Логика взаимодействия для PageVxod.xaml
    /// </summary>
    public partial class PageVxod : Page
    {
        public PageVxod()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sotrObj  = AppConnect.zooBd.Sotrudnik.FirstOrDefault(x => x.Email == tbLogin.Text && x.Password == Ppasword.Password);
                var userObj = AppConnect.zooBd.Client.FirstOrDefault(x => x.Email == tbLogin.Text && x.Password == Ppasword.Password);
                if (userObj == null && sotrObj == null)
                {
                    MessageBox.Show("Похоже что вы не зарегистрированы, пожалуйста, зарегистрируйтесь ", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (sotrObj == null) 
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Приветсвуем Вас, " + userObj.Name + "!", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            ProductsClient productsClient=new ProductsClient();
                            productsClient.Show();
                            break;
                    }
                }
                else
                {
                    switch ( sotrObj.IdRole)
                    {
                       
                        case 2:
                            MessageBox.Show("Приветсвуем Вас " + sotrObj.Name + "!", "Вы вошли как соотрудник", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            this.Content = null;
                            MainProduct mainProduct = new MainProduct();
                            mainProduct.Show();
                           
                            break;
                        default: MessageBox.Show("Не обнужерен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); break;

                    }

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Нет данных" + Ex.Message.ToString() + "Критическая ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Btn_reg(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("PageReg.xaml", UriKind.Relative));
        }
    }
}
