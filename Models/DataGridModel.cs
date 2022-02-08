using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectCinema.Models
{
    public class DataGridModel
    {
        [Display(Name = "Номер зала")]
        public int HallNumber { get; set; }
        [Display(Name = "Кинотеатр")]
        public string Cinema { get; set; }
        [Display(Name = "Фильм")]
        public string Film { get; set; }
        [Display(Name = "Стоимость билета")]
        public int Price { get; set; }
        [Display(Name = "Длительность")]
        public TimeSpan Time { get; set; }
        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }
        [Display(Name = "Начало сеанса")]
        public DateTime SessionTime { get; set; }
        [Display(Name = "Свободных место")]
        public int FreeSeats { get; set; }
    }
}
