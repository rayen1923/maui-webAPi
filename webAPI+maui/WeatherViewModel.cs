using SharedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace webAPI_maui
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly WeatherService _weatherService;
        public ObservableCollection<WeatherForecast> Forecasts { get; set; } = new();

        public WeatherViewModel()
        {
            _weatherService = new WeatherService();
            LoadWeatherData();
        }

        private async void LoadWeatherData()
        {
            var forecasts = await _weatherService.GetWeatherAsync("https://localhost:<port>");
            Forecasts.Clear();

            foreach (var forecast in forecasts)
            {
                Forecasts.Add(forecast);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
