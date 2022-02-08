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

namespace WpfProjectCinema.Views
{
    /// <summary>
    /// Логика взаимодействия для ThirdProfile.xaml
    /// </summary>
    public partial class ThirdProfile : UserControl
    {
        private Model1Container db;
        private ObservableCollection<object> dataList;
        private int index;

        public ThirdProfile()
        {
            InitializeComponent();
            db = new Model1Container();
            dataList = new ObservableCollection<object>();
        }

        private void ChangeTable(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Uid)
            {
                case "0": dataGrid.ItemsSource = db.FilmsSet.ToList();
                    index = 0;
                    break;
                case "1": dataGrid.ItemsSource = db.CinemasSet.ToList();
                    index = 1;
                    break;
                case "2": dataGrid.ItemsSource = db.HallsSet.ToList();
                    index = 2;
                    break;
                case "3": dataGrid.ItemsSource = db.CinemaSessionSet.ToList();
                    index = 3;
                    break;
            }
        }
        private bool flagfix = true;
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (flagfix)
            {
                switch (index)
                {
                    case 0:
                        var item = e.Row.Item as Films;
                        var t = db.FilmsSet.Where(x => x.Id == (int)item.Id).FirstOrDefault();
                        t = item;
                        db.SaveChanges();
                        break;
                    case 1:
                        var item1 = e.Row.Item as Cinemas;
                        var t1 = db.CinemasSet.Where(x => x.Id == (int)item1.Id).FirstOrDefault();
                        t1 = item1;
                        db.SaveChanges();
                        break;
                    case 2:
                        var item2 = e.Row.Item as Halls;
                        var t2 = db.HallsSet.Where(x => x.Id == (int)item2.Id).FirstOrDefault();
                        t2 = item2;
                        db.SaveChanges();
                        break;
                    case 3:
                        var item3 = e.Row.Item as CinemaSession;
                        var t3 = db.CinemaSessionSet.Where(x => x.Id == (int)item3.Id).FirstOrDefault();
                        t3 = item3;
                        db.SaveChanges();
                        break;
                }
                flagfix = false;
                dataGrid.CancelEdit();
                dataGrid.CancelEdit();
                flagfix = true;

            }
        }
    }
}
