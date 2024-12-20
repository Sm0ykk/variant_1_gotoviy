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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        string login { get; set; }
        string password { get; set; }
        private Material _currentMaterial = new Material();
        public AddEditPage(Material selectedMaterial, string login, string password)
        {

            InitializeComponent();
            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;
            DataContext = _currentMaterial;
            //ComboCountries.ItemsSource = delivery_sashaEntities.GetContext().Providers.ToList();

            this.login = login;
            this.password = password;
            if (this.login == "admin")
            {
                mincount.Visibility = Visibility.Visible;
            }
            if (this.login == "manager")
            {
                mincount.IsEnabled=false;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentMaterial.Name))
                errors.AppendLine("Укажите название отеля ");
            if (_currentMaterial.Count < 0)
                errors.AppendLine(" Укажите цену ");
            if (_currentMaterial.MinCount <0)
                errors.AppendLine("Укажите мин количество ");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentMaterial.id == 0)
                delivery_sashaEntities.GetContext().Materials.Add(_currentMaterial);

            try
            {
                delivery_sashaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена! ");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
