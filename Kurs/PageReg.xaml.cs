using Kurs.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
        }
        private void Btn_save(object sender, RoutedEventArgs e)
        {

            if (AppConnect.zooBd.Client.Count(x => x.Email == tbLogin.Text) > 0)
            {
                MessageBox.Show("Такой уже есть", "uved", MessageBoxButton.OK, MessageBoxImage.Information); return;
            }
            try
            {
                Client sotrrud = new Client()
                {
                    Email = tbLogin.Text,
                    Password = tbPass.Password,
                    Name = tbName.Text,
                    Surname = tbLast.Text,
                    IdRole = 2,
                    Birthday = ddata.SelectedDate,
                     
                };
                AppConnect.zooBd.Client.Add(sotrrud);
                AppConnect.zooBd.SaveChanges();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {

            }
        }
        private static bool IsEmailAllowed(string text)
        {
            bool blnValidEmail = false;
            Regex regEMail = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            if (text.Length > 0)
            {
                blnValidEmail = regEMail.IsMatch(text);
            }

            return blnValidEmail;
        }
        private static bool IsPasswordAllowed(string text)
        {
            bool blnValidPassword = false;
            Regex regPassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
            if (text.Length > 0)
            {
                blnValidPassword = regPassword.IsMatch(text);
            }

            return blnValidPassword;
        }
        private void PasswordChanged(object sender, RoutedEventArgs e)
        {

            if ( IsPasswordAllowed(tbPass.Password.Trim()) == false)
            {
                BtnSave.IsEnabled = false;
                tbPass.Background = Brushes.Red;
               

            }
            else
            {
                tbPass.Background = Brushes.Blue;
                BtnSave.IsEnabled = true;


            }
            if (Pascop.Password != tbPass.Password )
            {
                BtnSave.IsEnabled = false;
                
                Pascop.Background = Brushes.LightCoral;
                Pascop.BorderBrush = Brushes.Red;

            }
            else
            {
                
                BtnSave.IsEnabled = true;
                Pascop.Background = Brushes.LightGreen;
                Pascop.BorderBrush = Brushes.Green;

            }
        }

        private void EmailCor(object sender, TextChangedEventArgs e)
        {
            if (IsEmailAllowed(tbLogin.Text.Trim()) == false)
            {

                BtnSave.IsEnabled = false;
                tbLogin.Background = Brushes.LightCoral;
                tbLogin.BorderBrush = Brushes.Red;

            }
            else
            {
                BtnSave.IsEnabled = true;
                tbLogin.Background = Brushes.LightGreen;
                tbLogin.BorderBrush = Brushes.Green;

            }
        }
    }
}
