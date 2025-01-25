using System;
using System.IO;
using System.Reflection;

namespace PointChecker.FileReader
{
    class ConfigReader
    {
        public string GetConfig()
        {
            string appName = Assembly.GetExecutingAssembly().GetName().Name;
            var projPath = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);

            while (projPath.Name != appName)
            {
                projPath = Directory.GetParent(projPath.FullName);
            }

            string filePath = projPath.FullName + @"\conf.json";

            if (!File.Exists(filePath))
            {
                throw new Exception("Incorrect file name: " + filePath);
            }

            return File.ReadAllText(filePath);
        }
    }
}
