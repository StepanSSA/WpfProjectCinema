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
    /// Логика взаимодействия для FirstProfile.xaml
    /// </summary>
    public partial class FirstProfile : UserControl
    {
        private Model1Container db;
        private ObservableCollection<DataGridModel> dataList;

        public FirstProfile()
        {
            InitializeComponent();
            db = new Model1Container();
            var cinemaTittle = db.CinemasSet.Select(t => t.Name).ToList();
            foreach (var item in cinemaTittle)
            {
                boxCinema.Items.Add(item);
            }
            dataList = new ObservableCollection<DataGridModel>();
            dataGrid.ItemsSource = dataList;
        }

        private void ComboBox_SelectionCinema(object sender, SelectionChangedEventArgs e)
        {
            dataList.Clear();
            List<string> film = new List<string>();
            List<double> rating = new List<double>();
            List<TimeSpan> time = new List<TimeSpan>();
            List<int> hallNumber = new List<int>();
            List<int> freeSeats = new List<int>();
            List<DateTime> SessionTime = new List<DateTime>();

            var selected = boxCinema.SelectedItem.ToString();
            var cinemaId = db.CinemasSet
                .Where(c => c.Name == selected)
                .Select(c => c.Id).FirstOrDefault();
            var filmId = db.CinemaSessionSet
                .Where(x => x.idCinema == cinemaId)
                .Select(x => x.idFilm)
                .ToList();
            var hallId = db.CinemaSessionSet
                .Where(x => x.idCinema == cinemaId)
                .Select(x => x.idHall)
                .ToList();
            foreach (var item in filmId)
            {
                film.AddRange(db.FilmsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Name)
                    .ToList());
                rating.AddRange(db.FilmsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Rating)
                    .ToList());
                time.AddRange(db.FilmsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Time)
                    .ToList());
                SessionTime.AddRange(db.CinemaSessionSet
                    .Where(x => x.idCinema == cinemaId)
                    .Select(x => x.sessionTime)
                    .ToList());
            }
            foreach (var item in hallId)
            {
                hallNumber.AddRange(db.HallsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.Number)
                    .ToList());
                freeSeats.AddRange(db.HallsSet
                    .Where(x => x.Id == item)
                    .Select(x => x.FreeSeats)
                    .ToList());
            }
            var price = db.CinemaSessionSet
                .Where(x => x.idCinema == cinemaId)
                .Select(x => x.Price)
                .ToList();

            for (int i = 0; i < hallNumber.Count; i++)
            {
                var data = new DataGridModel()
                {
                    Cinema = selected,
                    Film = film[i],
                    HallNumber = hallNumber[i],
                    Price = price[i],
                    Rating = rating[i],
                    Time = time[i],
                    SessionTime = SessionTime[i],
                    FreeSeats = freeSeats[i]
                };
                dataList.Add(data);
            }

            boxHals.Items.Clear();
            foreach (var item in hallNumber.Distinct())
            {
                boxHals.Items.Add(item);
            }
            boxFilms.Items.Clear();
            foreach (var item in film.Distinct())
            {
                boxFilms.Items.Add(item);
            }

            dataGrid.ItemsSource = dataList;
        }

        private void ComboBox_SelectionHals(object sender, SelectionChangedEventArgs e)
        {
            var data = dataList.Where(x => x.HallNumber == Convert.ToInt32(boxHals.SelectedItem)).ToList();
            dataGrid.ItemsSource = data;
        }

        private void ComboBox_SelectionFilms(object sender, SelectionChangedEventArgs e)
        {   
            var data = dataList.Where(x => x.Film == boxFilms.SelectedItem as string).ToList();
            dataGrid.ItemsSource = data;
        }
    }
}
