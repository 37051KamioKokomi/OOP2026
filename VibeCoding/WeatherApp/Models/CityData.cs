using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models;
public class CityData {
    // 地域名
    public string Name { get; set; } = "";

    // 緯度
    public double Latitude { get; set; }

    // 経度
    public double Longitude { get; set; }
}
