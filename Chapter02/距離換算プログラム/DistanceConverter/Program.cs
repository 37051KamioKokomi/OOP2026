using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (int.TryParse(args[1], out var height))
            {
                if (int.TryParse(args[2], out var heightt))
                {
                    if (args.Length  <= 3 && args.Length >= 1 && args[0] == "-tom")//コマンドライン引数 … -tom:メートルへの変換 -tof:フィートへの変換 
                    {
                        PrintFeetToMeterList(int.Parse(args[1]), int.Parse(args[2])); //メートルへの変換
                    }
                    else if (args.Length >= 1 && args[0] == "-tof")
                    {
                        PrintMeterToFeetList(int.Parse(args[1]), int.Parse(args[2])); //フィートへの変換
                    }
                    else
                    {
                        Console.WriteLine("引数エラー");
                    }
                }
                else
                {
                    Console.WriteLine("引数エラー");
                }
            }
            else
            {
                Console.WriteLine("引数エラー");
            }
        }

        private static void PrintMeterToFeetList(int start, int stop)
        {
            //メートルからフィートへの対応表を出力
            for (int meter = start; meter <= stop; meter++)
            {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

        private static void PrintFeetToMeterList(int start, int stop)
        {
            //フィートからメートルへの対応表を出力
            for (int feet = start; feet <= stop; feet++)
            {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet)
        {
            //feet * 0.3048
            return feet * 0.3048;
        }
        //メートルからフィートを求める
        static double MeterToFeet(int meter)
        {
            return meter / 0.3048;
        }
    }
}
