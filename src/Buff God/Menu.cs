using System.Collections.Generic;
using Buff_God.Helpers;
using Buff_God.Structs;
using ImGuiNET;
using SharpDX;

namespace Buff_God
{
    public partial class Core
    {
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
            ImGui.Columns(8, $"EditColums{profile.Name}", true);
            ImGui.Text("Toggles");
            ImGuiExtension.ToolTip("Remove / Status / Show Inactive / Draw an Image", true);
            ImGui.NextColumn();
            ImGui.Text("Colors");
            ImGuiExtension.ToolTip("Text / Text Background", true);
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
                // Remove / Status / Show Inactive
                if (ImGui.Button($"X##Delete{profile.Name}{i}")) buffsToRemove.Add(i);
                ImGuiExtension.ToolTip("Remove This Buff", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.Enabled = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##Status{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Enabled);
                ImGuiExtension.ToolTip("Enable This Buff", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.ShowInactive = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##ShowInactive{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.ShowInactive);
                ImGuiExtension.ToolTip("Show a dimmed verison if the buff is inactive", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.ShowImage = PoeHUD.Hud.UI.ImGuiExtension.Checkbox($"##ShowImage{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.ShowImage);
                ImGuiExtension.ToolTip("Draw an Image", false, true);
                ImGui.NextColumn();
                // Colors - Text / Text Background
                profile.BuffSettings.BuffList[i].Settings.Colors.Text = PoeHUD.Hud.UI.ImGuiExtension.ColorPicker($"##TextColor{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Colors.Text);
                ImGuiExtension.ToolTip("Text Color", false, true);
                ImGui.SameLine();
                profile.BuffSettings.BuffList[i].Settings.Colors.TextBackground = PoeHUD.Hud.UI.ImGuiExtension.ColorPicker($"##TextBackgroundColor{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Colors.TextBackground);
                ImGuiExtension.ToolTip("Text Background Color", false, true);
                ImGui.NextColumn();
                // Buff Name
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.BuffName = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##BuffName{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.BuffName, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                // Image File
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Image = PoeHUD.Hud.UI.ImGuiExtension.InputText($"##Image{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Image, 1000, InputTextFlags.EnterReturnsTrue);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                // Buff Type
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Type = (Buff.BuffType)ImGuiExtension.ComboBox($"##Type{profile.Name}{i}", (int)profile.BuffSettings.BuffList[i].Settings.Type, typeSelector);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                // Buff Size
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Size = ImGuiExtension.IntDrag($"##Size{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Size, 1, 300);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                // X Axis
                ImGui.PushItemWidth(ImGui.GetContentRegionAvailableWidth());
                profile.BuffSettings.BuffList[i].Settings.Location.X = ImGuiExtension.IntDrag($"##X{profile.Name}{i}", profile.BuffSettings.BuffList[i].Settings.Location.X, 0, (int)GameController.Window.GetWindowRectangle().Width);
                ImGui.PopItemWidth();
                ImGui.NextColumn();
                // Y Axis
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
                        Enabled = false,
                        Colors = new Colors { Text = Color.White, TextBackground = new Color(0, 0, 0, 220) }
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
    }
}
