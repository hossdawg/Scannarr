using Newtonsoft.Json;
using System;
using System.IO;

namespace arr_scanner
{
    public class Settings
    {
        public static Settings Sonarr;
        public static Settings Radarr;
        public static Settings 4kSonarr;
        public static Settings 4kRadarr;
        public static Settings 3dRadarr;
        public string URL;
        public int Interval = 30;
        public bool ScanOnWake = true;
        public bool ScanOnInterval = false;
        public bool ScanOnStart = true;
        public bool ForceImport = false;
        public int ForceImportInterval = 1;
        public String ForceImportMode = "Copy"; // Copy or Move
        public string APIKey = "";
        private string filePath;
        private string fileName;
        private string name;

        public static readonly string NAME_RADARR = "Radarr";
        public static readonly string NAME_SONARR = "Sonarr";
        public static readonly string NAME_4KRADARR = "4kRadarr";
        public static readonly string NAME_SONARR = "4kSonarr";
        public static readonly string NAME_3DRADARR = "3dRadarr";

        [JsonConstructor]
        private Settings()
        {
        }


        public static void Init()
        {
            Sonarr = new Settings("settings_sonarr.json", NAME_SONARR);
            Radarr = new Settings("settings_radarr.json", NAME_RADARR);
            4kSonarr = new Settings("settings_4ksonarr.json", NAME_4KSONARR);
            4kRadarr = new Settings("settings_4kradarr.json", NAME_4KRADARR);
            3dRadarr = new Settings("settings_3dradarr.json", NAME_3DRADARR);
        }

        public string Provider()
        {
            return name;
        }

        public string FileName()
        {
            return fileName;
        }

        private Settings(string fileName, string name)
        {
            this.fileName = fileName;
            this.filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            this.name = name;
            Load();
            
            URL = URL ?? ((name == NAME_SONARR  || name == NAME_4KSONARR) ? "http://localhost:8989" : "http://localhost:7878");
        }


        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void Load()
        {
            try
            {
                JsonConvert.PopulateObject(File.ReadAllText(filePath), this);
            }
            catch (Exception)
            {
                Console.WriteLine($"Config file not found to {name}");
            }
        }
    }
}
