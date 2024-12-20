using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string login {  get; set; }
        string password { get; set; }
        public MainPage(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            if (this.login == "admin")
            {
                BtnProvider.Visibility = Visibility.Visible;
            }
            else if (this.login == "manager")
            {
                BtnProvider.Visibility = Visibility.Visible;
            }
            else
            {
                BtnProvider.Visibility = Visibility.Collapsed;
            }

        }



        private void BtnProvider_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMaterials_Click(object sender, RoutedEventArgs e)
        {
            if (login == "admin")
            {
                Manager.MainFrame.Navigate(new MaterialsPage(login, password));
            }
            else if (login == "manager")
            {
                Manager.MainFrame.Navigate(new MaterialsPage(login,password));
            }
            else
            {
                Manager.MainFrame.Navigate(new MaterialsPage2());
            }
        }
    }
}
