using System;
using System.Windows.Media;

namespace WeatherApp.GUI.Helpers
{
    public static class ColorHelper
    {
        public static SolidColorBrush GetWeatherRowColor(decimal minVal, decimal maxVal, decimal val)
        {
            var hue = (maxVal - val) / (maxVal - minVal);

            return new SolidColorBrush(ColorFromHsv(270 * (double) hue, 1, 1));
        }

        private static Color ColorFromHsv(double hue, double saturation, double value)
        {
            var hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            var f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            var v = Convert.ToByte(value);
            var p = Convert.ToByte(value * (1 - saturation));
            var q = Convert.ToByte(value * (1 - f * saturation));
            var t = Convert.ToByte(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            return Color.FromArgb(255, v, p, q);
        }
    }
}