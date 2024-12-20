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

namespace WpfApp1_variant_1
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        
        public Autorization()
        {
            InitializeComponent();
        }

        //private void Registr_Click(object sender, RoutedEventArgs e)
        //{
        //    Manager.MainFrame.Navigate(new Registration());
        //}

        private void Autorized_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginText.Text;
            string password = PasswordBox.Password;
            

            // Проверка на правильность ввода и наличие пользователя
            if (IsValidAdmin(login, password))
            {
                MessageBox.Show("Успешная авторизация!");
                //User.login = login;
                Manager.MainFrame.Navigate(new MainPage(login,password));


            }
            else if (IsValidManager(login, password))
            {
                MessageBox.Show("Успешная авторизация!");
                //User.login = login;
                Manager.MainFrame.Navigate(new MainPage(login, password));


            }
            else if (IsValidUser(login, password))
            {
              MessageBox.Show("Успешная авторизация!");
              Manager.MainFrame.Navigate(new MainPage(login, password));

            }

            else
            {
                MessageBox.Show("Неправильный пароль или логин.");
            }
        }
        private bool IsValidAdmin(string login, string password)
        {

            return login == "admin" && password == "password";
        }
        private bool IsValidManager(string login, string password)
        {
            return login == "manager" && password == "321";
        }
        private bool IsValidUser(string login, string password)
        {

            return login == "user" && password == "123";
        }
    }
}
