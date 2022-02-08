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
using WpfProjectCinema.Views;

namespace WpfProjectCinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ChangeProfile(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Uid)
            {
                case "0":
                    controlZone.Children.Clear();
                    controlZone.Children.Add(new ContentControl() { Content = new FirstProfile() });
                    break;
                case "1":
                    controlZone.Children.Clear();
                    controlZone.Children.Add(new ContentControl() { Content = new SecondProfile() });
                    break;
                case "2":
                    controlZone.Children.Clear();
                    controlZone.Children.Add(new ContentControl() { Content = new ThirdProfile() });
                    break;
                case "3":
                    controlZone.Children.Clear();
                    controlZone.Children.Add(new ContentControl() { Content = new FourthProfile() });
                    break;
            }
        }
    }
}
