using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWeatherApp.Model;
using WpfWeatherApp.ViewModel.Commands;

namespace WpfWeatherApp.ViewModel
{
    public class WeatherVM
    {
        public AccuWeather Weather { get; set; }

        private string cityQuery;

        public string CityQuery
        {
            get { return cityQuery; }
            set
            {
                cityQuery = value;

                if(cityQuery.Length >= 3)
                    GetCities();
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetWeather();
            }
        }

        public RefreshCommand RefreshCommand { get; set; }

        public WeatherVM()
        {
            Weather = new AccuWeather();
            Cities = new ObservableCollection<City>();
            SelectedCity = new City();
            RefreshCommand = new RefreshCommand(this);
        }

        private async void GetCities()
        {
            var cities = await WeatherAPI.GetAutocompleteAsync(CityQuery);
            
            //var cities = new List<City>
            //{
            //    new City()
            //    {
            //        AdministrativeArea = new Area(),
            //        Country = new Area(),
            //        Key = "111",
            //        LocalizedName = "Testowe miasto 1, Zimbabwe"
            //    },
            //    new City()
            //    {
            //        AdministrativeArea = new Area(),
            //        Country = new Area(),
            //        Key = "111",
            //        LocalizedName = "Testowe miasto 2, Zimbabwe"
            //    },
            //    new City()
            //    {
            //        AdministrativeArea = new Area(),
            //        Country = new Area(),
            //        Key = "111",
            //        LocalizedName = "Testowe miasto 3, Zimbabwe"
            //    }
            //};
            

            Cities.Clear();
            foreach (var item in cities)
            {
                Cities.Add(item);
            }
        }

        public async void GetWeather()
        {
            if(SelectedCity.Key != null)
            {
                var weather = await WeatherAPI.GetWeatherInformationAsync(SelectedCity.Key);

                Weather.DailyForecasts.Clear();
                foreach (var item in weather.DailyForecasts)
                {
                    Weather.DailyForecasts.Add(item);
                }
            }
        }

    }
}
