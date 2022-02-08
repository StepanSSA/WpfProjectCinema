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
using System.Windows.Shapes;
using WpfProjectCinema.Models;

namespace WpfProjectCinema.Views
{
    /// <summary>
    /// Логика взаимодействия для PurchaseConfirmation.xaml
    /// </summary>
    public partial class PurchaseConfirmation : Window
    {

        public DataGridModel DataModel { get; set; }
        private bool accept;

        public bool Accept
        {
            get { return accept; }
        }


        public PurchaseConfirmation()
        {
            InitializeComponent();
        }

        public void WindowFilling()
        {
            InfoPanel.Children.Add(new TextBlock() { Text = DataModel.Cinema });
            InfoPanel.Children.Add(new TextBlock() { Text = DataModel.Film });
            InfoPanel.Children.Add(new TextBlock() { Text = DataModel.HallNumber.ToString() });
            InfoPanel.Children.Add(new TextBlock() { Text = DataModel.SessionTime.ToString() });
        }


        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            var db = new Model1Container();
            var cinemaId = db.CinemasSet.Where(x => x.Name == DataModel.Cinema).Select(x => x.Id).FirstOrDefault();
            var filmId = db.FilmsSet.Where(x => x.Name == DataModel.Film).Select(x => x.Id);
            var hallId = db.HallsSet.Where(x => x.Number == DataModel.HallNumber).Select(x => x.Id).ToList();
            var key = db.HallsSet
                .Where(x => x.idCinema == cinemaId && hallId.Contains(x.Id) && x.Number == DataModel.HallNumber).FirstOrDefault();
            if (key == null || key.FreeSeats < 1)
            {
                var error = new WindowError();
                error.Show();
                accept = false;
                Close();
                return;
            }
            key.FreeSeats -= 1;
            accept = true;
            db.SaveChanges();
            Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            accept = false;
            Close();
        }
    }
}
