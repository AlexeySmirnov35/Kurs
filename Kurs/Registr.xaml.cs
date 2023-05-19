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
using System.Windows.Shapes;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
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
        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pascop.Password != tbPass.Password) /*&& !Regex.IsMatch(tbLogin.Text,@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")*/
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
