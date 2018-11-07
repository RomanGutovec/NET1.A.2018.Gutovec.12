using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport
    {
        private List<WeatherEventArgs> historyWeather;

        public StatisticReport()
        {
            historyWeather = new List<WeatherEventArgs>();
        }

        public void Register(WeatherData data)
        {
            data.WeatherChanged += Message;
        }

        public void Unregister(WeatherData data)
        {
            data.WeatherChanged -= Message;
        }

        private void Message(object sender, WeatherEventArgs eventArgs)
        {
            Console.WriteLine("Statistic report message:");
            historyWeather.Add(eventArgs);
            WeatherEventArgs newWeather = CalculateWeatherData(eventArgs);
            Console.WriteLine("Temperature = {0}, Humidity = {1}, Pressure = {2}", newWeather.Temperature, newWeather.Humidity, newWeather.Pressure);
        }

        private WeatherEventArgs CalculateWeatherData(WeatherEventArgs info)
        {
            int averageTemperature = 0;
            int averageHumidity = 0;
            int averagePressure = 0;

            foreach (var weather in historyWeather)
            {
                averageTemperature += weather.Temperature;
                averageHumidity += weather.Humidity;
                averagePressure += weather.Pressure;
            }

            averageTemperature /= historyWeather.Count;
            averageHumidity /= historyWeather.Count;
            averagePressure /= historyWeather.Count;
            WeatherEventArgs averageData = new WeatherEventArgs()
            {
                Temperature = averageTemperature,
                Humidity = averageHumidity,
                Pressure = averagePressure
            };
            return averageData;
        }
    }
}
