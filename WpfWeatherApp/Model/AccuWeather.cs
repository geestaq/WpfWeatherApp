using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfWeatherApp.Model
{
    public class Range : INotifyPropertyChanged
    {
        private double value;

        public double Value
        {
            get { return value; }
            set
            {
                if(value != this.value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }

        private string unit;

        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        private int unitType;

        public int UnitType
        {
            get { return unitType; }
            set
            {
                unitType = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Temperature : INotifyPropertyChanged
    {
        private Range minimum;

        public Range Minimum
        {
            get { return minimum; }
            set
            {
                minimum = value;
                OnPropertyChanged();
            }
        }

        private Range maximum;

        public Range Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TimeOfDay : INotifyPropertyChanged
    {
        private int icon;

        public int Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }

        private string iconPhrase;

        public string IconPhrase
        {
            get { return iconPhrase; }
            set
            {
                iconPhrase = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DailyForecast : INotifyPropertyChanged
    {
        public List<string> Sources { get; set; }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        private Temperature temperature;

        public Temperature Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged();
            }
        }

        private TimeOfDay day;

        public TimeOfDay Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged();
            }
        }

        private TimeOfDay night;

        public TimeOfDay Night
        {
            get { return night; }
            set
            {
                night = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccuWeather
    {
        public ObservableCollection<DailyForecast> DailyForecasts { get; set; }

        public AccuWeather()
        {
            DailyForecasts = new ObservableCollection<DailyForecast>();

            /*
            for (int i = 0; i < 3; i++)
            {
                DailyForecast dailyForecast = new DailyForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    Temperature = new Temperature
                    {
                        Maximum = new Range
                        {
                            Value = 21 + i
                        },
                        Minimum = new Range
                        {
                            Value = 5 - i
                        }
                    }
                };
                DailyForecasts.Add(dailyForecast);
            }
            */
        }
    }

}
