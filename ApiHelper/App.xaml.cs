using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ApiHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
        }

        public void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow(System.Configuration.ConfigurationSettings.AppSettings);
            this.MainWindow = window;
            window.Show();
        }

        //<summary>
        //Entry point class to handle single instance of the application
        //</summary>
        public static class EntryPoint
        {
            [STAThread]
            public static void Main(string[] args)
            {
                Console.WriteLine("Main");
                Console.ReadLine();

                App app = new App();
                app.Run();
            }
        }
    }
}
