using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData
    {
        private WeatherEventArgs currentWeather;
        private int measurePeriodSeconds;
        private int intervaMeasurelSeconds;

        public WeatherData(int measurePeriodSeconds, int intervalSeconds)
        {
            currentWeather = new WeatherEventArgs();
            IntervaMeasurelSeconds = intervalSeconds;
            MeasurePeriodSeconds = measurePeriodSeconds;
        }

        public event EventHandler<WeatherEventArgs> WeatherChanged = delegate { };

        public int MeasurePeriodSeconds
        {
            get
            {
                return measurePeriodSeconds;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Incorrect inputed value");
                }

                measurePeriodSeconds = value;
            }
        }

        public int IntervaMeasurelSeconds
        {
            get
            {
                return intervaMeasurelSeconds;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Incorrect inputed value");
                }

                intervaMeasurelSeconds = value;
            }
        }

        public void StartMeasure()
        {
            for (int i = 0; i < measurePeriodSeconds / IntervaMeasurelSeconds; i++)
            {
                Console.WriteLine($"\nNew weather data...\n");
                WeatherEventArgs newWeather = GetNewWeather();
                OnWeatherChanged(this, newWeather);
                Console.WriteLine(new string('-', 70));
                Thread.Sleep(IntervaMeasurelSeconds * 1000);
            }
        }

        protected virtual void OnWeatherChanged(object sender, WeatherEventArgs e)
        {
            WeatherChanged?.Invoke(this, e);
        }

        private WeatherEventArgs GetNewWeather()
        {
            Random random = new Random();
            WeatherEventArgs newWeather = new WeatherEventArgs()
            {
                Temperature = random.Next(10, 20),
                Humidity = random.Next(60, 100),
                Pressure = random.Next(600, 700)
            };

            return newWeather;
        }
    }
}
