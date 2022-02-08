using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectCinema.Models
{
    class BossGridModel
    {
        
        [Display(Name = "Кинотеатр")]
        public string Cinema { get; set; }
        [Display(Name = "Фильм")]
        public string Film { get; set; }
        [Display(Name = "Выручка")]
        public int Price { get; set; }
        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }
        [Display(Name = "Количество сеансов")]
        public int SessionCount { get; set; }
        public int TotalPrice { get; set; }
    }
}
