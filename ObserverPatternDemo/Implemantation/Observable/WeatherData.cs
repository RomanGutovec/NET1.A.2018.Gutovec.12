using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private WeatherInfo currentWeather;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            currentWeather = new WeatherInfo();
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            currentWeather = info;
            foreach (var observer in observers)
            {
                observer.Update(sender, currentWeather);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            observers.Remove(observer);
        }
    }
}
