namespace App.Env.Config
{
    public class Configuration
    {
        public string ActiveProfile { get; set; }
        public ConfigProperties Development { get; set; }
        public ConfigProperties Production { get; set; }
    }
}