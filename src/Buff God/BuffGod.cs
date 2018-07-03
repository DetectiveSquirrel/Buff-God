using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ImGuiNET;
using Newtonsoft.Json;
using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using SharpDX;
using SharpDX.Direct3D9;
using ComponentBuff = PoeHUD.Poe.RemoteMemoryObjects.Buff;

namespace Buff_God
{
    public class BuffGod : BaseSettingsPlugin<PluginSettings>
    {
        public string ConfigFolder;
        public List<Profile> Profiles { get; set; }

        public override void Initialise()
        {
            ConfigFolder = $@"{PluginDirectory}\profiles\";
            Profiles = GetProfiles();
            LogMessage($"{GetCurrentMethod()}: Load Complete", 5, Color.LawnGreen);
        }

        #region Folder Things

        public void ProfileCheck(Profile profile)
        {
            if (!Directory.Exists(profile.ImageFolder))
                Directory.CreateDirectory(profile.ImageFolder);
        }
        public void SaveBuffSettings(Profile profile) => Json.SaveSettingFile(profile.JsonFile, profile.BuffSettings);
        public void SaveActivationSettings(Profile profile) => Json.SaveSettingFile(profile.StatusFile, profile.Status);

        private BuffData LoadBuffSettings(Profile profile)
        {
            if (!File.Exists(profile.JsonFile) || JsonConvert.DeserializeObject<BuffData>(File.ReadAllText(profile.JsonFile)) == null)
            {
                return new BuffData();
            }
            return JsonConvert.DeserializeObject<BuffData>(File.ReadAllText(profile.JsonFile));
        }

        private Status LoadActivationSettings(Profile profile)
        {
            if (!File.Exists(profile.StatusFile) || JsonConvert.DeserializeObject<Status>(File.ReadAllText(profile.StatusFile)) == null)
            {
                return new Status();
            }
            return JsonConvert.DeserializeObject<Status>(File.ReadAllText(profile.StatusFile));
        }

        private List<string> GetProfileFolders() => CustomSearcher.GetDirectories(ConfigFolder);

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

        #endregion

        public override void DrawSettingsMenu()
        {
            for (var index = 0; index < Profiles.Count; index++)
            {
                var profileEnabled = Profiles[index].Status.Enabled;
                if (ImGui.Checkbox($"##EnableProfile{Profiles[index].Name}", ref profileEnabled))
                {
                    Profiles[index].Status.Enabled = profileEnabled;
                    SaveActivationSettings(Profiles[index]);
                }
                ImGui.SameLine();
                if (ImGui.CollapsingHeader($"{Profiles[index].Name}##ProfileHeader{Profiles[index].Name}",
                    TreeNodeFlags.AllowItemOverlap))
                {
                    ImGuiNative.igIndent();
                    DrawProfilesTable(Profiles[index]);
                    ImGui.Spacing();
                    ImGui.Spacing();
                    ImGui.Spacing();
                    ImGuiNative.igUnindent();
                }
            }
        }

        public void DrawProfilesTable(Profile profile)
        {
            var buffsToRemove = new List<int>();
            ImGui.Separator();
            ImGui.Columns(7, $"EditColums{profile.Name}", true);
            ImGui.Text("X / On / Inactive");
            ImGuiExtension.ToolTip("Remove / Status / Show Inactive", true);
            ImGui.NextColumn();
            ImGui.Text("Buff Name");
            ImGui.NextColumn();
            ImGui.Text("File Name");
            ImGui.NextColumn();
            ImGui.Text("Type");
            ImGui.NextColumn();
            ImGui.Text("Size");
            ImGui.NextColumn();
            ImGui.Text("X");
            ImGui.NextColumn();
            ImGui.Text("Y");
            ImGui.NextColumn();
            if (profile.BuffSettings.BuffList.Count != 0)
                ImGui.Separator();

            var typeSelector = new List<string>
            {
                "Duration",
                "Charge",
                "Count",
                "Duration + Charges",
                "Duration + Count",
                "Image Only"
            };

            for (var i = 0; i < profile.BuffSettings.BuffList.Count; i++)
            {
                if (ImGui.Button($"X##Delete{profile.Name}{i}")) buffsToRemove.Add(i);
                ImGuiExtension.ToolTip("Remove This Buff", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.Enabled = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##Status{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Enabled);
                ImGuiExtension.ToolTip("Enable This Buff", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.ShowInactive = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##ShowInactive{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.ShowInactive);
                ImGuiExtension.ToolTip("Show a dimmed verison if the buff is inactive", false, true);
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.BuffName = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##BuffName{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.BuffName, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Image = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##Image{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Image, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Type = (Buff.BuffType)ImGuiExtension.ComboBox($"##Type{profile.Name}{i}", (int)profile.BuffSettings.BuffList[i].Settings.Type, typeSelector);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Size = ImGuiExtension.IntDrag($"##Size{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Size, 1, 300);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Location.X = ImGuiExtension.IntDrag($"##X{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Location.X, 0, (int)GameController.Window.GetWindowRectangle().Width);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Location.Y = ImGuiExtension.IntDrag($"##Y{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Location.Y, 0, (int)GameController.Window.GetWindowRectangle().Height);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
            }

            // Remove items in deleteion queue
            foreach (var i in buffsToRemove)
                profile.BuffSettings.BuffList.Remove(profile.BuffSettings.BuffList[i]);

            ImGui.Separator();
            ImGui.Columns(1, "", false);

            // Make add new button
            if (ImGui.Button($"+##Add{profile.Name}"))
            {
                var newItem = new Buff.Base
                {
                    Settings = new Buff.Settings
                    {
                        Location = new Buff.Location { X = 200, Y = 200 },
                        Size = 64,
                        ShowInactive = false,
                        Image = "Image",
                        BuffName = "BuffName",
                        Type = Buff.BuffType.Duration,
                        Enabled = false
                    },
                    DisposableData = new Buff.DisposableData()
                };
                profile.BuffSettings.BuffList.Add(newItem);
            }
            ImGui.SameLine();
            if (ImGui.Button($"Save##{profile.Name}"))
            {
                SaveBuffSettings(profile);
            }
            ImGui.SameLine();
            if (ImGui.Button($"Reload##{profile.Name}"))
            {
                profile.BuffSettings = LoadBuffSettings(profile);
            }
            ImGui.Separator();
        }

        public override void Render()
        {
            if (!CanTick()) return; // skip render frame if information is bad

            DrawBuff();
        }

        #region Graphics

        public void DrawBuff()
        {
            /*
             * copy buffs to a new list so we can look at them 
             * without a buff being removed half way through
             */
            var currentBuffs = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Life>().Buffs.ToList();

            foreach (var profile in Profiles)
            {

                if (profile == null || !profile.Status.Enabled) continue;
                foreach (var buffBeingChecked in profile.BuffSettings.BuffList) // buff search defined by the user
                {
                    if (!buffBeingChecked.Settings.Enabled) continue; // Skipp buff if its disabled

                    buffBeingChecked.DisposableData = new Buff.DisposableData();

                    var duplicateBuffs = SearchForBuffs(buffBeingChecked, currentBuffs); // list of the buff we are searching for

                    if (duplicateBuffs.Count > 0) // let us know if we ever found the buff for later checks
                        buffBeingChecked.DisposableData.WasFound = true;

                    if (buffBeingChecked.DisposableData.WasFound || buffBeingChecked.Settings.ShowInactive) // continue if list has any items OR if we want it shown inactive
                    {
                        switch (buffBeingChecked.Settings.Type) // sort user defined buff by type and apply correct logic
                        {
                            case Buff.BuffType.Duration: // if setting is a duration timer
                                buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.Charge:  // if setting is a charge count
                                buffBeingChecked.DisposableData.ChargeData = new Buff.ChargeData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.BuffCount:   // if setting is a count of the buff the user is searching for
                                buffBeingChecked.DisposableData.BuffCountData = new Buff.BuffCountData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.DurationAndCharge:
                                buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                                buffBeingChecked.DisposableData.ChargeData = new Buff.ChargeData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.DurationAndCount:
                                buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                                buffBeingChecked.DisposableData.BuffCountData = new Buff.BuffCountData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.ImageOnly:
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                        }
                    }

                    buffBeingChecked.DisposableData = null;
                }
            }
        }

        public void DrawBuffIcon(Profile profile, Buff.Base buffToDraw)
        {
            var profilePath = $"{profile.ImageFolder}{buffToDraw.Settings.Image}.png";
            var backUpPath = $@"{PluginDirectory}\images\{buffToDraw.Settings.Image}.png";
            var imageFile = string.Empty;

            if (File.Exists(profilePath))
                imageFile = profilePath;
            if (imageFile == string.Empty && File.Exists(backUpPath))
                imageFile = backUpPath;

            if (imageFile == string.Empty) return;

            var readyImage = new RectangleF(buffToDraw.Settings.Location.X, buffToDraw.Settings.Location.Y, buffToDraw.Settings.Size, buffToDraw.Settings.Size);

            switch (buffToDraw.DisposableData.WasFound)
            {
                case true:
                    Graphics.DrawPluginImage(imageFile, readyImage);

                    // Start the text drawing process
                    switch (buffToDraw.Settings.Type) // have seperate draw logic per type, more types can easily be added this way
                    {
                        case Buff.BuffType.Duration: // Draw above the icon
                            DrawAboveImage(buffToDraw, buffToDraw.DisposableData.DurationData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.Charge:   // Draw top left of the icon
                            DrawInsideImage(buffToDraw, buffToDraw.DisposableData.ChargeData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.BuffCount:// Draw top left of the icon
                            DrawInsideImage(buffToDraw, buffToDraw.DisposableData.BuffCountData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.DurationAndCharge:
                            DrawAboveImage(buffToDraw, buffToDraw.DisposableData.DurationData.DisplayText, readyImage);
                            DrawInsideImage(buffToDraw, buffToDraw.DisposableData.ChargeData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.DurationAndCount:
                            DrawAboveImage(buffToDraw, buffToDraw.DisposableData.DurationData.DisplayText, readyImage);
                            DrawInsideImage(buffToDraw, buffToDraw.DisposableData.BuffCountData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.ImageOnly:
                            // Do nothing, we only want the image
                            break;
                    }

                    break;
                case false:
                    // TODO: Learn how to change the images saturation to black & white
                    // Define the image and draw it - INACTIVE
                    Graphics.DrawPluginImage($"{profile.ImageFolder}{buffToDraw.Settings.Image}.png", readyImage, new Color(255, 255, 255, 201));
                    Graphics.DrawBox(readyImage, new Color(0, 0, 0, 201)); // drawing a black box over the imagewith 201 transperency
                    break;
            }
        }

        public void DrawAboveImage(Buff.Base baseInfo, string displayText, RectangleF imageRec)
        {
            // TODO: Fix this issue
            // Bandaid fix for int.MaxValue problem from permanent duration buffs
            if (displayText == "-2147483648" || displayText == "2147483648")
                displayText = "∞";

            var textSize = UpperBuffSize(baseInfo.Settings.Size);
            var measureText = Graphics.MeasureText(displayText, textSize);
            var newBox = new RectangleF(imageRec.X, imageRec.Y, imageRec.Width, -measureText.Height);
            var position = new Vector2(newBox.Center.X, newBox.Center.Y);
            Graphics.DrawText(displayText, textSize, position, Color.White, FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
            Graphics.DrawBox(newBox, new Color(0, 0, 0, 220));
        }

        public void DrawInsideImage(Buff.Base baseInfo, string displayText, RectangleF imageRec)
        {
            // TODO: Fix this issue
            // Bandaid fix for int.MaxValue problem from permanent duration buffs
            if (displayText == "-2147483648" || displayText == "2147483648")
                displayText = "∞";

            var textSize = InnerToBuffSize(baseInfo.Settings.Size);
            var measureText = Graphics.MeasureText(displayText, textSize);
            var minimumTextWidth = Graphics.MeasureText("00", textSize).Width;
            if (measureText.Width < minimumTextWidth) // set a minim box size of 2 characters
                measureText.Width = minimumTextWidth;
            var newBox = new RectangleF(imageRec.X, imageRec.Y, measureText.Width * 1.07f, measureText.Height * 1.02f);
            var position = new Vector2(newBox.Center.X, newBox.Center.Y);
            Graphics.DrawText(displayText, textSize, position, Color.White, FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
            Graphics.DrawBox(newBox, new Color(0, 0, 0, 220));
        }

        // Scale text size according to image size chosen by the user
        public int InnerToBuffSize(int buffSize)
        {
            var buffTextPercent2 = buffSize / 100.00;
            var hardTextSize2 = 28.00 * buffTextPercent2;
            var textSize2 = (int)Math.Floor(hardTextSize2);
            return textSize2;
        }

        public int UpperBuffSize(int buffSize)
        {
            var buffTextPercent = buffSize / 100.00;
            var hardTextSize = 32.00 * buffTextPercent;
            return (int)Math.Floor(hardTextSize);
        }

        #endregion

        public List<ComponentBuff> SearchForBuffs(Buff.Base wantedBuff, List<ComponentBuff> currentBuffs)
        {
            return currentBuffs.Where(buff =>
                string.Equals(buff.Name, wantedBuff.Settings.BuffName, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        #region Logging

        public void MethodLog(string message)
        {
            LogMessage($"{GetCurrentMethod()}{message}", 5, Color.LawnGreen);
        }

        public void MethodLog(string message, int time)
        {
            LogMessage($"{GetCurrentMethod()}{message}", time, Color.LawnGreen);
        }

        public void MethodLog(string message, Color color)
        {
            LogMessage($"{GetCurrentMethod()}{message}", 5, color);
        }

        public void MethodLog(string message, int time, Color color)
        {
            LogMessage($"{GetCurrentMethod()}{message}", time, color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return $"{GetType().Name}.{sf.GetMethod().Name}";
        }

        #endregion

        public bool CanTick()
        {
            if (GameController.IsLoading)
                return false;
            if (!GameController.Game.IngameState.ServerData.IsInGame)
                return false;
            if (GameController.Player == null || GameController.Player.Address == 0 || !GameController.Player.IsValid)
                return false;
            if (GameController.Game.IngameState.IngameUi.AtlasPanel.IsVisible)
                return false;
            if (GameController.Game.IngameState.IngameUi.TreePanel.IsVisible)
                return false;
            return true;
        }
    }

    public class Profile
    {
        public string Name { get; set; }
        public string JsonFile { get; set; }
        public string StatusFile { get; set; }
        public BuffData BuffSettings { get; set; } = new BuffData();
        public string Directory { get; set; }
        public string ImageFolder { get; set; }
        public Status Status { get; set; } = new Status();
    }


    public class Status
    {
        public bool Enabled { get; set; } = true;
    }

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

    public class PluginSettings : SettingsBase
    {
    }

    public class BuffData
    {
        public List<Buff.Base> BuffList { get; set; } = new List<Buff.Base>();
    }

    public class Buff
    {
        public enum BuffType
        {
            Duration,
            Charge,
            BuffCount,
            DurationAndCharge,
            DurationAndCount,
            ImageOnly
        }

        public class Base
        {
            public Settings Settings { get; set; } // Settings for how to draw the buff - Size, Color and Location
            public DisposableData DisposableData { get; set; } = new DisposableData(); // Data that gets used every render and has no use to be kept
        }

        public class Settings
        {
            public string BuffName { get; set; } // BuffName of the buff - "new_new_blade_vortex"
            public string Image { get; set; } // File BuffName
            public bool Enabled { get; set; } // Is this buff enabled?
            public bool Show { get; set; } // Show the buff
            public int Size { get; set; }
            public Location Location { get; set; }
            public bool ShowInactive { get; set; }
            public BuffType Type { get; set; } // set type of buff type to apply correct logic
        }

        public class Location
        {
            public int X { get; set; } = 200;
            public int Y { get; set; } = 200;
        }

        public class DisposableData
        {
            public string DisplayText { get; set; } = string.Empty; // Display to show on the buff, this is defined by the BuffType logic applied
            public bool WasFound { get; set; } = false; // Was the buff ever found?
            public DurationData DurationData { get; set; }
            public ChargeData ChargeData { get; set; }
            public BuffCountData BuffCountData { get; set; }
        }

        // class for BuffType.Duration
        public class DurationData
        {
            public DurationData(List<ComponentBuff> list)
            {
                var buffList = list.ToList();

                if (buffList.Count > 0)
                {
                    buffList.OrderBy(buff => buff.Timer); // order by time left
                    buffList.Reverse(); // reverse ordering to highest -> lowest
                    Duration = (int)Math.Ceiling(buffList.FirstOrDefault().Timer);
                    MaxDuration = (int)Math.Ceiling(buffList.FirstOrDefault().MaxTime);
                    Name = buffList.FirstOrDefault().Name;
                    DisplayText = Duration.ToString();
                }
            }

            public string Name { get; set; } = string.Empty;
            public int Duration { get; set; } // Time Left
            public int MaxDuration { get; set; } // Time buff starts with
            public string DisplayText { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"Buff: {Name}, Duration: {Duration}, MaxDuration: {MaxDuration}";
            }
        }

        // class for BuffType.Charge
        public class ChargeData
        {
            public ChargeData(List<ComponentBuff> list)
            {
                var buffList = list.ToList();

                if (buffList.Count > 0)
                {
                    ChargeCount = buffList.FirstOrDefault().Charges;
                    Name = buffList.FirstOrDefault().Name;
                    DisplayText = ChargeCount.ToString();
                }
            }

            public string Name { get; set; } = string.Empty;
            public int ChargeCount { get; set; } // Total count of this buff
            public string DisplayText { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"Buff: {Name}, ChargeCount: {ChargeCount}";
            }
        }

        // class for BuffType.BuffCount
        public class BuffCountData
        {
            public BuffCountData(List<ComponentBuff> list)
            {
                var buffList = list.ToList();

                if (buffList.Count > 0)
                {
                    BuffCount = buffList.Count;
                    Name = buffList.FirstOrDefault().Name;
                    DisplayText = BuffCount.ToString();
                }
            }

            public string Name { get; set; } = string.Empty;
            public int BuffCount { get; set; }
            public string DisplayText { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"Buff: {Name}, BuffCount: {BuffCount}";
            }
        }
    }

    public class CustomSearcher
    {
        public static List<string> GetDirectories(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }

            var directories = new List<string>(GetDirectories(path, searchPattern));

            foreach (var directory in directories)
            {
                directories.AddRange(GetDirectories(directory, searchPattern));
            }

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }
    }
}