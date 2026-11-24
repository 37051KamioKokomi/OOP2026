using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;
public class WeatherService {

    // HTTP通信を行うためのクライアント
    private readonly HttpClient _httpClient = new HttpClient();

    // 東京の天気を取得する
    public async Task<WeatherData?> GetWeatherAsync() {
        //double latitude, double longitude
        string url =
                "https://api.open-meteo.com/v1/forecast" +
               "?latitude=35.6762" +
"&longitude=139.6503" +
                "&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m" +
                "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                "&forecast_days=7" +
                "&timezone=Asia/Tokyo";

        //$"?latitude={latitude}" +
        //$"&longitude={longitude}" +

                // APIにリクエストを送る
                var response = await _httpClient.GetAsync(url);

        // 通信エラーを確認する
        response.EnsureSuccessStatusCode();

        // JSONを取得する
        string json = await response.Content.ReadAsStringAsync();

        // JSONを解析する
        using JsonDocument document = JsonDocument.Parse(json);

        var current = document.RootElement.GetProperty("current");

        // WeatherDataにデータを格納する
        return new WeatherData {
            Temperature = current.GetProperty("temperature_2m").GetDouble(),
            Humidity = current.GetProperty("relative_humidity_2m").GetInt32(),
            WeatherCode = current.GetProperty("weather_code").GetInt32(),
            WindSpeed = current.GetProperty("wind_speed_10m").GetDouble()
        };
    }

    // 7日間の天気予報を取得する
    public async Task<List<DailyWeatherData>> GetWeeklyWeatherAsync() {
        //double latitude, double longitude
        string url =
            "https://api.open-meteo.com/v1/forecast" +
             "?latitude=35.6762" +
                "&longitude=139.6503" +
            "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
            "&forecast_days=7" +
            "&timezone=Asia/Tokyo";

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        using JsonDocument document = JsonDocument.Parse(json);

        var daily = document.RootElement.GetProperty("daily");

        var dates = daily.GetProperty("time");
        var codes = daily.GetProperty("weather_code");
        var maxTemps = daily.GetProperty("temperature_2m_max");
        var minTemps = daily.GetProperty("temperature_2m_min");
        var rainProbs = daily.GetProperty("precipitation_probability_max");

        var result = new List<DailyWeatherData>();

        for (int i = 0; i < dates.GetArrayLength(); i++) {
            result.Add(new DailyWeatherData {
                Date = dates[i].GetString() ?? "",
                WeatherCode = codes[i].GetInt32(),
                WeatherDescription = GetWeatherDescription(codes[i].GetInt32()),
                WeatherIcon = GetWeatherIcon(codes[i].GetInt32()),
                MaxTemperature = maxTemps[i].GetDouble(),
                MinTemperature = minTemps[i].GetDouble(),
                PrecipitationProbability = rainProbs[i].ValueKind == JsonValueKind.Null
                    ? 0
                    : rainProbs[i].GetInt32()
            });
        }

        return result;

    }

    // 天気コードを日本語に変換する
    private string GetWeatherDescription(int code) {
        return code switch {
            0 => "快晴",
            1 => "晴れ",
            2 => "晴れ時々曇り",
            3 => "曇り",
            45 or 48 => "霧",
            51 or 53 or 55 => "霧雨",
            61 or 63 or 65 => "雨",
            71 or 73 or 75 => "雪",
            80 or 81 or 82 => "にわか雨",
            95 or 96 or 99 => "雷雨",
            _ => "不明"
        };
    }

    // 天気コードからアイコンを取得する
    private string GetWeatherIcon(int code) {
        return code switch {
            0 => "☀️",
            1 => "🌤️",
            2 => "⛅",
            3 => "☁️",
            45 or 48 => "🌫️",
            51 or 53 or 55 => "🌦️",
            61 or 63 or 65 => "🌧️",
            71 or 73 or 75 => "❄️",
            80 or 81 or 82 => "🌧️",
            95 or 96 or 99 => "⛈️",
            _ => "🌈"
        };
    }
}
