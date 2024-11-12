using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Database;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    public class SoldierService
    {
        private readonly AppDbContext _context;

        public SoldierService()
        {
            _context = new AppDbContext();
        }

        public SoldierService(AppDbContext context)
        {
            _context = context;
        }

        public virtual List<Soldier> GetAllSoldiers()
        {
            using (var context = new AppDbContext())
            { 
             try
              { 
                  return _context.Soldiers.ToList();
              }
              catch (Exception ex)
              {
                throw new Exception(ex.Message);
              }
            }
        }
    }
}
