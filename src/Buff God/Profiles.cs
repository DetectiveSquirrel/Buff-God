using System.Collections.Generic;
using System.IO;
using Buff_God.Structs;
using Newtonsoft.Json;

namespace Buff_God
{
    public partial class Core
    {
        public void SaveBuffSettings(Profile profile)
        {
            Json.SaveSettingFile(profile.JsonFile, profile.BuffSettings);
        }

        public void SaveActivationSettings(Profile profile)
        {
            Json.SaveSettingFile(profile.StatusFile, profile.Status);
        }

        private BuffData LoadBuffSettings(Profile profile)
        {
            if (!File.Exists(profile.JsonFile) || JsonConvert.DeserializeObject<BuffData>(File.ReadAllText(profile.JsonFile)) == null)
                return new BuffData();
            return JsonConvert.DeserializeObject<BuffData>(File.ReadAllText(profile.JsonFile));
        }

        private Status LoadActivationSettings(Profile profile)
        {
            if (!File.Exists(profile.StatusFile) || JsonConvert.DeserializeObject<Status>(File.ReadAllText(profile.StatusFile)) == null)
                return new Status();
            return JsonConvert.DeserializeObject<Status>(File.ReadAllText(profile.StatusFile));
        }

        public void ProfileCheck(Profile profile)
        {
            if (!Directory.Exists(profile.ImageFolder))
                Directory.CreateDirectory(profile.ImageFolder);
        }

        private List<string> GetProfileFolders()
        {
            return CustomSearcher.GetDirectories(ConfigFolder);
        }

        private List<Profile> GetProfiles()
        {
            var returnList = new List<Profile>();
            foreach (var directory in GetProfileFolders())
            {
                var newProfile = new Profile
                {
                    Name = Path.GetFileName(directory),
                    JsonFile = $@"{directory}\BuffData.json",
                    StatusFile = $@"{directory}\Status.json",
                    ImageFolder = $@"{directory}\images\",
                    Directory = directory
                };
                newProfile.BuffSettings = LoadBuffSettings(newProfile);
                newProfile.Status = LoadActivationSettings(newProfile);
                ProfileCheck(newProfile);

                returnList.Add(newProfile);
            }
            return returnList;
        }
    }
}