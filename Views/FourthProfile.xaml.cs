using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfProjectCinema.Models;

namespace WpfProjectCinema.Views
{
    /// <summary>
    /// Логика взаимодействия для FourthProfile.xaml
    /// </summary>
    public partial class FourthProfile : UserControl
    {
        private Model1Container db;
        private ObservableCollection<BossGridModel> dataList;

        public FourthProfile()
        {
            InitializeComponent();
            db = new Model1Container();
            var cinemaTittle = db.CinemasSet.Select(t => t.Name).ToList();
            foreach (var item in cinemaTittle)
            {
                boxCinema.Items.Add(item);
            }
            dataList = new ObservableCollection<BossGridModel>();
            dataGrid.ItemsSource = dataList;
        }

        private void ComboBox_SelectionCinema(object sender, SelectionChangedEventArgs e)
        {
            dataList.Clear();
            List<string> film = new List<string>();
            List<double> rating = new List<double>();
            List<int> SessionTime = new List<int>();
            List<int> price = new List<int>();

            var selected = boxCinema.SelectedItem.ToString();
            var cinemaId = db.CinemasSet
                .Where(c => c.Name == selected)
                .Select(c => c.Id).FirstOrDefault();
            var filmId = db.CinemaSessionSet
                .Where(x => x.idCinema == cinemaId)
                .Select(x => x.idFilm)
                .ToList();
            var hallId = db.CinemaSessionSet.
                Where(x => x.idCinema == cinemaId).Select(x => x.idHall).ToList();
            foreach (var item in hallId)
            {
                
                SessionTime.AddRange(db.HallsSet
                    .Where(x => x.Id == (int)item).Select(x => x.Size - x.FreeSeats).ToList());

            }

            foreach (var item in filmId)
            {
                
                film.AddRange(db.FilmsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Name)
                    .Distinct());
                rating.AddRange(db.FilmsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Rating)
                    .Distinct());
                price.Add(db.CinemaSessionSet
                    .Where(x => x.idFilm == item)
                    .Select(x => x.Price).Sum());
            }
            
            for (int i = 0; i < film.Count; i++)
            {

                var data = new BossGridModel()
                {
                    Cinema = selected,
                    Film = film[i],
                    Price = price[i],
                    Rating = rating[i],
                    SessionCount = SessionTime[i],
                    TotalPrice = price[i] * SessionTime[i]
                };
                dataList.Add(data);
            }
            TotalPriceText.Text = "";
            TotalPriceText.Text = "Итого: " + dataList.Select(x => x.TotalPrice).Sum().ToString() + "р";
        }
    }
}
