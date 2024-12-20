using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1_variant_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Autorization());
            Manager.MainFrame = MainFrame;
            //ImportMaterials();
        }
        private void ImportMaterials()
        {
            var fileData = File.ReadAllLines(@"C:\mater\materials.txt");
            var Images = Directory.GetFiles(@"C:\materials");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempTour = new Material
                {
                    Name = Convert.ToString(data[0]),//.Replace("\"", "")
                    Type_material = Convert.ToString(data[1]),

                    Price = int.Parse(data[3]),
                    Count = int.Parse(data[4]),
                    MinCount = int.Parse(data[5]),
                    CountInPack = int.Parse(data[6]),
                    Unit = Convert.ToString(data[7]),
                };
                //foreach (var tourType in data[5].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    var currentType = .GetContext().Type.ToList().FirstOrDefault(p => p.Name == tourType);
                //    if (currentType != null)
                //        tempTour.Type.Add(currentType);
                //}
                try
                {
                    tempTour.Image = File.ReadAllBytes(Images.FirstOrDefault(p => p.Contains(Convert.ToString(data[2]))));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                delivery_sashaEntities.GetContext().Materials.Add(tempTour);
                delivery_sashaEntities.GetContext().SaveChanges();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                Manager.MainFrame.GoBack();
            }
        }


    }
}
