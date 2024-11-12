using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Models
{
    public class LocationHistory
    {
        [Key]
        public int LocationID { get; set; }
        public int SoldierID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public Soldier Soldier { get; set; }
    }
}
