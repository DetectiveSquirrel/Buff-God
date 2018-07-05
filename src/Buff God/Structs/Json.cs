using System.IO;
using Newtonsoft.Json;

namespace Buff_God.Structs
{
    public class Json
    {
        public static TSettingType LoadSettingFile<TSettingType>(string fileName)
        {
            return !File.Exists(fileName) ? default(TSettingType) : JsonConvert.DeserializeObject<TSettingType>(File.ReadAllText(fileName));
        }

        public static void SaveSettingFile<TSettingType>(string fileName, TSettingType setting)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(setting, Formatting.Indented));
        }
    }
}