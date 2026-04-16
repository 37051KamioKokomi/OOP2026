namespace sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            //入力(配列へ格納)
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + (i + 1) + "] = ");
                array[i] = int.Parse(Console.ReadLine());
            }

            //集計(配列の値を集計)
            //int sum = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum = sum + array[i];
            //}

            Console.WriteLine(); //改行
            //出力(配列の値を出力)
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + (i + 1) + "]:");
                //アスタリスク出力
                astOut(array[i]);
                //string? inputNum = Console.ReadLine();
                //array[i] = int.Parse(inputNum);
                //Console.WriteLine(array[i]);
                //Console.WriteLine("array[" + i + "]:" + array[i]);
            }
            //合計を出力
            Console.Write("合計:" + array.Where(n => n % 2 == 0).Sum()); //LINQ
        }
        static void astOut(int num)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine(); //改行
        }

    }
}
