using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace WeatherApp.GUI.ChartControls
{
    /// <summary>
    ///     Логика взаимодействия для PieChartControl.xaml
    /// </summary>
    public partial class PieChartControl : UserControl
    {
        public PieChartControl()
        {
            InitializeComponent();

            PointLabel = chartPoint =>
                $"{chartPoint.Y} ({chartPoint.Participation:P})";

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (PieChart) chartpoint.ChartView;

            //clear selected slice.
            foreach (var seriesView in chart.Series)
            {
                var series = (PieSeries) seriesView;
                series.PushOut = 0;
            }

            var selectedSeries = (PieSeries) chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}