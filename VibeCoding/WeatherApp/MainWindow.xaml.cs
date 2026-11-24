using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Services;

namespace WeatherApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private readonly WeatherService _weatherService = new();

    public MainWindow() {
        InitializeComponent();

        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
        //MessageBox.Show("天気取得処理を開始しました！");

        try {
            var weather = await _weatherService.GetWeatherAsync();

            if (weather == null) {
                MessageBox.Show("天気情報を取得できませんでした。");
                return;
            }

            TemperatureText.Text = $"気温：{weather.Temperature}℃";
            WeatherText.Text = $"天気：{GetWeatherDescription(weather.WeatherCode)}";
            HumidityText.Text = $"湿度：{weather.Humidity}%";
            WindSpeedText.Text = $"風速：{weather.WindSpeed}m/s";

            // 7日間の天気予報を取得
            var weeklyWeather =
                await _weatherService.GetWeeklyWeatherAsync();

            foreach (var item in weeklyWeather) {
                if (DateTime.TryParse(item.Date, out var date)) {
                    item.Date = date.ToString("M月d日");
                }
            }

            // 画面に週間予報を表示
            WeeklyWeatherList.ItemsSource = weeklyWeather;
        }
        catch (Exception ex) {
            MessageBox.Show($"取得失敗：{ex.Message}");
        }
    }

    private string GetWeatherDescription(int code) {
        return code switch {
            0 => "快晴",
            1 or 2 => "晴れ",
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
}