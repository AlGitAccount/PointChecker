using PointChecker.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointChecker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DefineData();
            Application.Run(new MainForm());
        }

        static private void DefineData()
        {
            FileReader.ConfigReader configReader = new FileReader.ConfigReader();
            Deserializator.Deserializator deserializator = new Deserializator.Deserializator();
            DataRepository.SectionRepository.Context().AddConfiguration(deserializator.GetSectionList(configReader.GetConfig()));
        }
    }
}
