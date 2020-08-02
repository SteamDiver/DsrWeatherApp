using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace WeatherApp.GUI.ChartControls
{
    /// <summary>
    ///     Логика взаимодействия для BarChart.xaml
    /// </summary>
    public partial class BarChartControl : UserControl
    {
        public BarChartControl()
        {
            InitializeComponent();
            Formatter = value => value.ToString("N");
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("BarSeriesCollection", typeof(SeriesCollection),
                typeof(BarChartControl), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty LabelsProperty =
            DependencyProperty.Register("BarLabels", typeof(string[]),
                typeof(BarChartControl), new FrameworkPropertyMetadata(null));

        public SeriesCollection BarSeriesCollection
        {
            get => (SeriesCollection) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public string[] BarLabels
        {
            get => (string[]) GetValue(LabelsProperty);
            set => SetValue(LabelsProperty, value);
        }

        public Func<double, string> Formatter { get; set; }

    }
}