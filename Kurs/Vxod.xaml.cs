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
    /// Логика взаимодействия для Vxod.xaml
    /// </summary>
    public partial class Vxod : Window
    {
        public Vxod()
        {
            InitializeComponent();
            AppConnect.zooBd = new ZooBdEntities1();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {

           
            try
            {
                var userObj = AppConnect.zooBd.Client.FirstOrDefault(x => x.Email == tbLogin.Text && x.Password == Ppasword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Проверьте пароль или логин", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Hello admin " + userObj.Name + " !", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            break;
                        case 2:
                            MessageBox.Show("Hello user " + userObj.Name + " !", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                           
                            break;
                        default: MessageBox.Show("Ne onraz", "uved", MessageBoxButton.OK, MessageBoxImage.Warning); break;

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Dann net" + Ex.Message.ToString() + "ktit rab", "uved", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Btn_reg(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("PageReg.xaml", UriKind.Relative));
        }
    }
}
