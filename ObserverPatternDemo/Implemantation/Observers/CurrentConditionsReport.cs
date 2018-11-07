using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport 
    {
        private WeatherEventArgs currentWeather;

        public void Register(WeatherData data)
        {
            data.WeatherChanged += Message;
        }

        public void Unregister(WeatherData data)
        {
            data.WeatherChanged -= Message;
        }

        public override string ToString()
        {
            return "Current condition Report\n" +
                $"current Temperature: {currentWeather.Temperature}" +
                $"current Humidity: {currentWeather.Humidity}" +
                $"current Pressure: {currentWeather.Pressure}";
        }

        private void Message(object sender, WeatherEventArgs eventArgs)
        {
            currentWeather = eventArgs ?? throw new ArgumentNullException($"Incorrect data of {nameof(eventArgs)}");
            Console.WriteLine("Current report message:");
            Console.WriteLine("Temperture = {0}, Humidity = {1}, Pressure = {2}\n", eventArgs.Temperature, eventArgs.Humidity, eventArgs.Pressure);
        }
    }
}