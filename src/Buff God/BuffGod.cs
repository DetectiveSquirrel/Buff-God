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

namespace Buff_God
{
    public class BuffGod : BaseSettingsPlugin<PluginSettings>
    {
        public string ImageFolder;
        public string ConfigFolder;
        public string ConfigFile;
        public List<Buff.Base> BuffList { get; set; }

        public override void Initialise()
        {
            ImageFolder = $@"{PluginDirectory}\images\";
            ConfigFolder = $@"{PluginDirectory}\config\";
            ConfigFile = $"{ConfigFolder}BuffData.json";
            BuffList = new List<Buff.Base>();

            if (!Directory.Exists(ImageFolder))
                Directory.CreateDirectory(ImageFolder);
            if (!Directory.Exists(ConfigFolder))
                Directory.CreateDirectory(ConfigFolder);

            LoadSettings();

            LogMessage($"{GetCurrentMethod()}: Load Complete", 5, Color.LawnGreen);
        }

        private void LoadSettings()
        {
            try
            {
                BuffList = Json.LoadSettingFile<List<Buff.Base>>(ConfigFile);
            }
            finally
            {
                if (BuffList == null)
                {
                    BuffList = new List<Buff.Base>();
                }
                SaveSettings();
            }
        }

        public override void DrawSettingsMenu()
        {
            var buffsToRemove = new List<int>();
            ImGui.Separator();
            ImGui.Columns(7, "EditColums", true);
            ImGui.Text("X / On / Inactive");
            ImGuiExtension.ToolTip("Remove / Enabled / Show Inactive", true);
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
            if (BuffList.Count != 0)
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

            for (var i = 0; i < BuffList.Count; i++)
            {
                if (ImGui.Button($"X##Delete{i}")) buffsToRemove.Add(i);
                ImGuiExtension.ToolTip("Remove This Buff", false, true);
                ImGui.SameLine();
                BuffList[i].Settings.Enabled = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##Enabled{i}", BuffList[i].Settings.Enabled);
                ImGuiExtension.ToolTip("Enable This Buff", false, true);
                ImGui.SameLine();
                BuffList[i].Settings.ShowInactive = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##ShowInactive{i}", BuffList[i].Settings.ShowInactive);
                ImGuiExtension.ToolTip("Show a dimmed verison if the buff is inactive", false, true);
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.BuffName = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##BuffName{i}", BuffList[i].Settings.BuffName, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.Image = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##Image{i}", BuffList[i].Settings.Image, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.Type = (Buff.BuffType)ImGuiExtension.ComboBox($"##Type{i}", (int)BuffList[i].Settings.Type, typeSelector);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.Size = ImGuiExtension.IntDrag($"##Size{i}", BuffList[i].Settings.Size, 1, 300);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.Location.X = ImGuiExtension.IntDrag($"##X{i}", BuffList[i].Settings.Location.X, 0, (int)GameController.Window.GetWindowRectangle().Width);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                BuffList[i].Settings.Location.Y = ImGuiExtension.IntDrag($"##Y{i}", BuffList[i].Settings.Location.Y, 0, (int)GameController.Window.GetWindowRectangle().Height);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
            }

            // Remove items in deleteion queue
            foreach (var i in buffsToRemove)
                BuffList.Remove(BuffList[i]);

            ImGui.Separator();
            ImGui.Columns(1, "", false);

            // Make add new button
            if (ImGui.Button($"+##Add"))
            {
                var newItem = new Buff.Base
                {
                    Settings = new Buff.Settings
                    {
                        Location = new Buff.Location { X = 200, Y = 200 },
                        Size = 64,
                        ShowInactive = false,
                        Image = "",
                        BuffName = "",
                        Type = Buff.BuffType.Duration,
                        Enabled = false
                    },
                    DisposableData = new Buff.DisposableData()
                };
                BuffList.Add(newItem);
            }
            ImGui.Separator();

            if (ImGui.Button("Save These Settings"))
            {
                SaveSettings();
            }
            if (ImGui.Button("Reload These Settings"))
            {
                LoadSettings();
            }
        }

        public void SaveSettings() => Json.SaveSettingFile(ConfigFile, BuffList);

        public override void Render()
        {
            if (!CanTick()) return; // skip render frame if information is bad

            DrawBuff();
        }

        public void DrawBuff()
        {
            /*
             * copy buffs to a new list so we can look at them 
             * without a buff being removed half way through
             */
            var currentBuffs = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Life>().Buffs.ToList();

            foreach (var buffBeingChecked in BuffList) // buff search defined by the user
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
                            DrawBuffIcon(buffBeingChecked);
                            break;
                        case Buff.BuffType.Charge:  // if setting is a charge count
                            buffBeingChecked.DisposableData.ChargeData = new Buff.ChargeData(duplicateBuffs);
                            DrawBuffIcon(buffBeingChecked);
                            break;
                        case Buff.BuffType.BuffCount:   // if setting is a count of the buff the user is searching for
                            buffBeingChecked.DisposableData.BuffCountData = new Buff.BuffCountData(duplicateBuffs);
                            DrawBuffIcon(buffBeingChecked);
                            break;
                        case Buff.BuffType.DurationAndCharge:
                            buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                            buffBeingChecked.DisposableData.ChargeData = new Buff.ChargeData(duplicateBuffs);
                            DrawBuffIcon(buffBeingChecked);
                            break;
                        case Buff.BuffType.DurationAndCount:
                            buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                            buffBeingChecked.DisposableData.BuffCountData = new Buff.BuffCountData(duplicateBuffs);
                            DrawBuffIcon(buffBeingChecked);
                            break;
                        case Buff.BuffType.ImageOnly:
                            DrawBuffIcon(buffBeingChecked);
                            break;
                    }
                }

                buffBeingChecked.DisposableData = null;
            }
        }

        public void DrawBuffIcon(Buff.Base buffToDraw)
        {
            // If the image file doesnt exist, we need to stop this function and produce an error message
            if (!File.Exists($"{ImageFolder}{buffToDraw.Settings.Image}.png"))
            {
                MethodLog($"File: {ImageFolder}{buffToDraw.Settings.Image}.png Not Found!", Color.Red);
                return;
            }

            var readyImage = new RectangleF(buffToDraw.Settings.Location.X, buffToDraw.Settings.Location.Y, buffToDraw.Settings.Size, buffToDraw.Settings.Size);

            switch (buffToDraw.DisposableData.WasFound)
            {
                case true:
                    Graphics.DrawPluginImage($"{ImageFolder}{buffToDraw.Settings.Image}.png", readyImage);

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
                    Graphics.DrawPluginImage($"{ImageFolder}{buffToDraw.Settings.Image}.png", readyImage, new Color(255, 255, 255, 201));
                    Graphics.DrawBox(readyImage, new Color(0, 0, 0, 201)); // drawing a black box over the imagewith 201 transperency
                    break;
            }
        }

        public void DrawAboveImage(Buff.Base baseInfo, string displayText, RectangleF imageRec)
        {
            var textSize = UpperBuffSize(baseInfo.Settings.Size);
            var measureText = Graphics.MeasureText(displayText, textSize);
            var newBox = new RectangleF(imageRec.X, imageRec.Y, imageRec.Width, -measureText.Height);
            var position = new Vector2(newBox.Center.X, newBox.Center.Y);
            Graphics.DrawText(displayText, textSize, position, Color.White, FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
            Graphics.DrawBox(newBox, new Color(0, 0, 0, 220));
        }

        public void DrawInsideImage(Buff.Base baseInfo, string displayText, RectangleF imageRec)
        {
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

        public List<PoeHUD.Poe.RemoteMemoryObjects.Buff> SearchForBuffs(Buff.Base wantedBuff,
            List<PoeHUD.Poe.RemoteMemoryObjects.Buff> currentBuffs)
        {
            return currentBuffs.Where(buff =>
                string.Equals(buff.Name, wantedBuff.Settings.BuffName, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

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

    public class Json
    {
        public static TSettingType LoadSettingFile<TSettingType>(string fileName)
        {
            return !File.Exists(fileName)
                ? default(TSettingType)
                : JsonConvert.DeserializeObject<TSettingType>(File.ReadAllText(fileName));
        }

        public static void SaveSettingFile<TSettingType>(string fileName, TSettingType setting)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(setting, Formatting.Indented));
        }
    }

    public class PluginSettings : SettingsBase
    {
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
            public DurationData(List<PoeHUD.Poe.RemoteMemoryObjects.Buff> list)
            {
                var buffList = list.ToList();

                if (buffList.Count > 0)
                {
                    buffList.OrderBy(buff => buff.Timer); // order by time left
                    buffList.Reverse(); // reverse ordering to highest -> lowest

                    Duration = Convert.ToInt32(Math.Ceiling(buffList.FirstOrDefault().Timer));
                    MaxDuration = Convert.ToInt32(Math.Ceiling(buffList.FirstOrDefault().MaxTime));
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
            public ChargeData(List<PoeHUD.Poe.RemoteMemoryObjects.Buff> list)
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
            public BuffCountData(List<PoeHUD.Poe.RemoteMemoryObjects.Buff> list)
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
}