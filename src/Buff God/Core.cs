using System.Collections.Generic;
using Buff_God.Structs;
using PoeHUD.Plugins;
using SharpDX;

namespace Buff_God
{
    public partial class Core : BaseSettingsPlugin<PluginSettings>
    {
        public string ConfigFolder;
        public List<Profile> Profiles { get; set; }

        public Core()
        {
            PluginName = "Buff God";
        }
        
        public override void Initialise()
        {
            ConfigFolder = $@"{PluginDirectory}\profiles\";
            Profiles = GetProfiles();
            LogMessage($"{GetCurrentMethod()}: Load Complete", 5, Color.LawnGreen);
        }
    }
}