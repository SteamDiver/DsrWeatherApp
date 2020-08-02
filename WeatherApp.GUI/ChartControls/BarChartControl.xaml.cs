using System;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;

namespace WeatherApp.GUI.ChartControls
{
    /// <summary>
    ///     Логика взаимодействия для BarChart.xaml
    /// </summary>
    public partial class BarChartControl : UserControl
    {
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("BarSeriesCollection", typeof(SeriesCollection),
                typeof(BarChartControl), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty LabelsProperty =
            DependencyProperty.Register("BarLabels", typeof(string[]),
                typeof(BarChartControl), new FrameworkPropertyMetadata(null));

        public BarChartControl()
        {
            InitializeComponent();
            Formatter = value => value.ToString("N");
        }

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