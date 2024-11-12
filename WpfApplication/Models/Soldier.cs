using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Models
{
    public class Soldier
    {
        [Key]
        public int SoldierID { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Rank { get; set; }
        public string Country { get; set; }
        public string TrainingInfo { get; set; }
        public ICollection<LocationHistory> LocationHistories { get; set; }
    }
}
