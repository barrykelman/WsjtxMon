using Newtonsoft.Json;

namespace WsjtxMon
{
    public class WsjtxResource
    {
        public string Callsign { get; set; } = string.Empty;
        public string AdifPath { get; set; } = string.Empty;
        public string QrzApiKey { get; set; } = string.Empty;
        public string QrzUser { get; set; } = string.Empty;
        public string QrzPassword { get; set; } = string.Empty;
        public string TqslDirectory { get; set; } = string.Empty;
        public string TqslUser { get; set; } = string.Empty;
        public string TqslPassword { get; set; } = string.Empty;
        public Point Location { get; set; } = new Point(10, 10);
        public Size Size { get; set; } = new Size(717, 624);
        public Version Version { get; set; } = new Version(1, 2);

        public WsjtxResource? Load()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsPath = Path.Combine(appDataPath, "local", "WsjtxMon", "settings.json");
            if (File.Exists(settingsPath))
            { 
                string settingsJson = File.ReadAllText(settingsPath);
                if (!string.IsNullOrWhiteSpace(settingsJson))
                {
                    return JsonConvert.DeserializeObject<WsjtxResource>(settingsJson);
                }
            }
            return new WsjtxResource();
        }

        public void Save()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsDir = Path.Combine(appDataPath, "local", "WsjtxMon");
            if (!Directory.Exists(settingsDir))
            {
                Directory.CreateDirectory(settingsDir);
            }
            string settingsPath = Path.Combine(appDataPath, "local", "WsjtxMon", "settings.json");
            string settingsJson = JsonConvert.SerializeObject(this);
            File.WriteAllText(settingsPath, settingsJson);
        }
    }
}
