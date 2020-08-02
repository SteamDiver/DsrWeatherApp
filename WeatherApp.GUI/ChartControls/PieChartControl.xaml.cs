using System.Windows;
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
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("PieSeriesCollection", typeof(SeriesCollection),
                typeof(PieChartControl), new FrameworkPropertyMetadata(null));

        public PieChartControl()
        {
            InitializeComponent();
        }

        public SeriesCollection PieSeriesCollection
        {
            get => (SeriesCollection) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }


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