using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.Data;
using WeatherApp.Data.Models;

namespace WeatherApp.GUI
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }
    }
}