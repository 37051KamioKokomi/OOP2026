using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WeatherApp.Models;
// 現在の天気
public class WeatherData {
    public double Temperature { get; set; }

    public int Humidity { get; set; }

    public int WeatherCode { get; set; }

    public double WindSpeed { get; set; }
}

// 1日分の天気予報
public class DailyWeatherData {
    public string Date { get; set; } = "";


    public int WeatherCode { get; set; }

    public string WeatherDescription { get; set; } = "";

    public string WeatherIcon { get; set; } = "";

    public double MaxTemperature { get; set; }

    public double MinTemperature { get; set; }

    public int PrecipitationProbability { get; set; }
}
