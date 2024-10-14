namespace App.Common
{
    public struct Config
    {
        public string Environment { get; set; }
        public EnvironmentConfig Development { get; set; }
        public EnvironmentConfig Production { get; set; }
        
    }
}