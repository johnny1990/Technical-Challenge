using CefSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    public class SoldierViewModel : BaseViewModel
    {
        public ObservableCollection<Soldier> Soldiers { get; set; }
        public ObservableCollection<LocationHistory> collectionHis { get; set; }
        private DispatcherTimer _timer;
        private SoldierService _soldierService;

        public SoldierViewModel()
        {
            _soldierService = new SoldierService();
            Soldiers = new ObservableCollection<Soldier>();

            LoadSoldiers();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += UpdateSoldierPositions;
            _timer.Start();
        }

        public async void LoadSoldiers()
        {
            var soldiers = await Task.Run(() => _soldierService.GetAllSoldiers());

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (var soldier in soldiers)
                {
                    Soldiers.Add(soldier);
                }

                UpdateMapSoldiers();
            });
        }

        public void UpdateSoldierPositions(object sender, EventArgs e)
        {
            foreach (var soldier in Soldiers)
            {
                soldier.Latitude += 0.01;
                soldier.Longitude += 0.01;
            }

            UpdateMapSoldiers();
        }

        public void UpdateMapSoldiers()
        {
            try
            {
                var soldiersData = JsonConvert.SerializeObject(Soldiers.Select(s => new { s.SoldierID, s.Name, s.Longitude, s.Latitude, s.Country, s.Rank, s.TrainingInfo }));

                string script = $"updateSoldiersPositions({soldiersData})";

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    var window = System.Windows.Application.Current.Windows[0] as MainWindow;
                    if (window != null && window.MapControl != null)
                    {
                        window.MapControl.EvaluateScriptAsync(script);
                    }
                });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
    }
}
