using System;
using System.IO;
using System.Linq;
using Buff_God.Structs;
using PoeHUD.Poe.Components;
using SharpDX;
using SharpDX.Direct3D9;

namespace Buff_God
{
    public partial class Core
    {
        public override void Render()
        {
            if (!CanTick()) return; // skip render frame if information is bad

            DrawBuff();
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
                        switch (buffBeingChecked.Settings.Type) // sort user defined buff by type and apply correct logic
                        {
                            case Buff.BuffType.Duration: // if setting is a duration timer
                                buffBeingChecked.DisposableData.DurationData = new Buff.DurationData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.Charge: // if setting is a charge count
                                buffBeingChecked.DisposableData.ChargeData = new Buff.ChargeData(duplicateBuffs);
                                DrawBuffIcon(profile, buffBeingChecked);
                                break;
                            case Buff.BuffType.BuffCount: // if setting is a count of the buff the user is searching for
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

                    switch (buffToDraw.Settings.ShowImage)
                    {
                        case true:
                            Graphics.DrawPluginImage(imageFile, readyImage);
                            break;
                        case false:
                            break;
                    }

                    // Start the text drawing process
                    switch (buffToDraw.Settings.Type) // have seperate draw logic per type, more types can easily be added this way
                    {
                        case Buff.BuffType.Duration: // Draw above the icon
                            DrawAboveImage(buffToDraw, buffToDraw.DisposableData.DurationData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.Charge: // Draw top left of the icon
                            DrawInsideImage(buffToDraw, buffToDraw.DisposableData.ChargeData.DisplayText, readyImage);
                            break;
                        case Buff.BuffType.BuffCount: // Draw top left of the icon
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

                    switch (buffToDraw.Settings.ShowImage)
                    {
                        case true:
                            Graphics.DrawPluginImage($"{profile.ImageFolder}{buffToDraw.Settings.Image}.png", readyImage, new Color(255, 255, 255, 201));
                            Graphics.DrawBox(readyImage, new Color(0, 0, 0, 201)); // drawing a black box over the imagewith 201 transperency
                            break;
                        case false:
                            break;
                    }
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
            if (baseInfo.Settings.Colors.Text.A > 0)
                Graphics.DrawText(displayText, textSize, position, baseInfo.Settings.Colors.Text, FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
            if (baseInfo.Settings.Colors.TextBackground.A > 0)
                Graphics.DrawBox(newBox, baseInfo.Settings.Colors.TextBackground);
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
            Graphics.DrawText(displayText, textSize, position, baseInfo.Settings.Colors.Text, FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
            Graphics.DrawBox(newBox, baseInfo.Settings.Colors.TextBackground);
        }

        // Scale text size according to image size chosen by the user
        public int InnerToBuffSize(int buffSize)
        {
            var buffTextPercent2 = buffSize / 100.00;
            var hardTextSize2 = 28.00 * buffTextPercent2;
            var textSize2 = (int) Math.Floor(hardTextSize2);
            return textSize2;
        }

        public int UpperBuffSize(int buffSize)
        {
            var buffTextPercent = buffSize / 100.00;
            var hardTextSize = 32.00 * buffTextPercent;
            return (int) Math.Floor(hardTextSize);
        }
    }
}