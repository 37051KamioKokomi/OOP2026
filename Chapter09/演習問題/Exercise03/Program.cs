namespace Exercise03 {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //var tw = new TimeWatch();
            //tw.Start();
            //TimeSpan duration = tw.Stop();
            //Console.WriteLine("èàóùéûä‘ÇÕ{0}É~ÉäïbÇ≈ÇµÇΩ", duration.TotalMicroseconds);

        }

       
    }
}