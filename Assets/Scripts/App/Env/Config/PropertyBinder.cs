using Newtonsoft.Json;

namespace App.Env.Config
{
    public class PropertyBinder
    {
        public static T Bind<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}