using System.Text.Json;
using AcimaDosOnze_Oficial.WeatherSector.Models;

namespace AcimaDosOnze_Oficial.Services.WeatherServices.Methods
{
    public class SerializeMetar
    {
        private GetDate Gdate = new GetDate();
        private GetHour Ghour = new GetHour();
        private GetDirectionWind Gdirection = new GetDirectionWind();
        private GetWindSpeed Gspeed = new GetWindSpeed();
        private GetVisibility Gvisibility = new GetVisibility();
        private GetWeather Gweather = new GetWeather();
        private GetTemperature Gtemperature = new GetTemperature();
        private GetDewPoint GdewPoint = new GetDewPoint();
        private GetPression Gpression = new GetPression();

        public string GetJson(string Metar)
        {
            string hour, windDirection, windSpeed, visibility, temperature, dewPoint, pression;
            string[] date, weather;

            date = Gdate.ConvertDateMetar(Metar);
            hour = Ghour.ConvertHourMetar(Metar);
            windDirection = Gdirection.GetWindDirection(Metar);
            windSpeed = Gspeed.GetSpeedWind(Metar);
            visibility = Gvisibility.GetVisibilityMetar(Metar);
            weather = Gweather.GetWeatherMetar(Metar);
            temperature = Gtemperature.GetTemperatureMetar(Metar);
            dewPoint = GdewPoint.GetDewPointMetar(Metar);
            pression = Gpression.GetPressionMetar(Metar);

            var obj = new JsonModel()
            {
                Date = date,
                Hour = hour,
                WindDirection = windDirection,
                WindSpeed = windSpeed,
                Visibility = visibility,
                Weather = weather,
                Temperature = temperature,
                DewPoint = dewPoint,
                Pression = pression
            };

            string jsonString = JsonSerializer.Serialize(obj);

            return jsonString;
        }
    }
}