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
    /// Логика взаимодействия для MaterialsPage2.xaml
    /// </summary>
    public partial class MaterialsPage2 : Page
    {
        string login { get; set; }
        string password { get; set; }
        public MaterialsPage2()
        {
            InitializeComponent();


            var allTypes = delivery_sashaEntities.GetContext().Materials.Select(m => m.Type_material).Distinct().ToList();

            allTypes.Insert(0, "Все типы");
            //allTypes.Insert(0, "Все типы");


            ComboType.ItemsSource = allTypes;

            ComboType.SelectedIndex = 0;




            //var allTypes = delivery_sashaEntities.GetContext().Materials.ToList();
            //allTypes.Insert(0, new Material
            //{
            //    Type_material = "Все типы"
            //});
            //ComboType.ItemsSource = allTypes;
            //CheckActual.IsChecked = true;
            //ComboType.SelectedIndex = 0;


            UpdateTours();
        }
        private void UpdateTours()
        {
            var currentTours = delivery_sashaEntities.GetContext().Materials.ToList();


            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type_material.Contains(ComboType.SelectedItem as string)).ToList();

            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            LViewTours.ItemsSource = currentTours.OrderBy(p => p.Count).ToList();
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UpdateTours();
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Material, login, password));
        }
    }
}
