using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<LocationHistory> LocationHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=MAN;Database=ArmyDB;integrated security=True; TrustServerCertificate=True;");
    }
}
