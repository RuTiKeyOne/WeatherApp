using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weather.View.JsonApi;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для DataAboutWeather.xaml
    /// </summary>
    public partial class DataAboutWeather : Window
    {
        public DataAboutWeather()
        {
                InitializeComponent();
                TextBlockCity.Text = $"{JsonWeatherApi.Wr.Name}";
                TextBlockTemperature.Text = $"{JsonWeatherApi.Wr.Main.Temp} °С";
                TextBlockHumidity.Text = $"{JsonWeatherApi.Wr.Main.Humidity}%";
                TextBlockPressure.Text = $"{JsonWeatherApi.Wr.Main.Pressure}";
                TextBlockWind.Text = $"{JsonWeatherApi.Wr.Wind.Speed} m/s";
        }

        
        private void CloseDataAboutWeather(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindowObject = new MainWindow();
            MainWindowObject.Show();
            this.Close();
        }
           
    }
}
