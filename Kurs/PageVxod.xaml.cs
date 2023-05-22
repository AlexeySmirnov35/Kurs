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

            /* if (tbLogin.Text.Length > 0) // проверяем введён ли логин     
             {
                 if (Ppasword.Password.Length > 0) // проверяем введён ли пароль         
                 {             // ищем в базе данных пользователя с такими данными         
                     DataTable dt_user = pageBD.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + tbLogin.Text + "' AND [password] = '" + Ppasword.Password + "'");
                     if (dt_user.Rows.Count > 0) // если такая запись существует       
                     {
                         MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался         
                     }
                     else MessageBox.Show("Пользователя не найден"); // выводим ошибку  
                 }
                 else MessageBox.Show("Введите пароль"); // выводим ошибку    
             }
             else MessageBox.Show("Введите логин"); // выводим ошибку */
            //   NavigationService.Navigate(new Uri("Vxod.xaml",UriKind.Relative));
            try
            {
                var sotrObj  = AppConnect.zooBd.Sotrudnik.FirstOrDefault(x => x.Email == tbLogin.Text && x.Password == Ppasword.Password);
                var userObj = AppConnect.zooBd.Client.FirstOrDefault(x => x.Email == tbLogin.Text && x.Password == Ppasword.Password);
                if (userObj == null && sotrObj == null)
                {
                    MessageBox.Show("Takogo net", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (sotrObj == null) 
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Hello adminclient" + userObj.Name + "!", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Uri("PageReg.xaml", UriKind.Relative));
                            break;
                        case 2:
                            MessageBox.Show("Hello ckient " + userObj.Name + "!", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Uri("PageReg.xaml", UriKind.Relative));
                            break;
                        default: MessageBox.Show("Ne onraz", "uved", MessageBoxButton.OK, MessageBoxImage.Warning); break;

                    }
                }
                else
                {
                    switch ( sotrObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Hello admin" + sotrObj.Name + "!", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Uri("PageVxod.xaml", UriKind.Relative));
                            break;
                        case 2:
                            MessageBox.Show("Hello sotr " + sotrObj.Name + "!", "uvced", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Uri("PageVxod.xaml", UriKind.Relative));
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
            NavigationService.Navigate(new Uri("PageReg.xaml", UriKind.Relative));
        }
    }
}
