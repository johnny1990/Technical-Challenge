using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication.ViewModels;
using System;
using System.IO;
using CefSharp.Wpf;
using System.Windows.Forms;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SoldierViewModel();
            LoadMap();
        }

        private void LoadMap()
        {
            string mapPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SoldiersMap", "Map.html");
            if (File.Exists(mapPath))
            {
                MapControl.Load(mapPath);
            }
            else
            {
                System.Windows.MessageBox.Show($"File not found: {mapPath}");
            }
        }
    }
}