using PoeHUD.Controllers;
using PoeHUD.Hud.Menu;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_God
{
    public class PluginBase : BaseSettingsPlugin<PluginSettings>
    {
        public PluginBase()
        {
            PluginName = "Buff God";
        }

        private bool _isTown;

        public override void Initialise()
        {
            GameController.Area.OnAreaChange += OnAreaChange;
        }

        public override void Render()
        {
            base.Render();

            BuffUi();
        }

        public void BuffUi()
        {
            var Panels = GameController.Game.IngameState.IngameUi;

            if (_isTown || (Panels.AtlasPanel.IsVisible || Panels.OpenLeftPanel.IsVisible || Panels.TreePanel.IsVisible)) return;
            var x = GameController.Window.GetWindowRectangle().Width * 50 * .01f;
            var y = GameController.Window.GetWindowRectangle().Height * 50 * .01f;
            var position = new Vector2(x, y);

            /* TO-DO
             * charges ? 
            */

            /* Buff Array[]
             * 
             * Enable Buff,
             * Text over Icon,
             * Buff Name,
             * Active Icon,
             * Inactive Icon
            */

            // Golems
            object[] Fire_Golem = { false, "", "fire_elemental_buff", "Fire Golem Active", "Fire Golem Inactive" };
            object[] Ice_Golem = { false, "", "ice_elemental_buff", "Ice Golem Active", "Ice Golem Inactive" };
            object[] Lightning_Golem = { false, "", "lightning_elemental_buff", "Lightning Golem Active", "Lightning Golem Inactive" };
            object[] Chaos_Golem = { false, "", "chaos_elemental_buff", "Chaos Golem Active", "Chaos Golem Inactive" };
            object[] Stone_Golem = { false, "", "rock_golem_buff", "Stone Golem Active", "Stone Golem Inactive" };

            //Offerings
            object[] Flesh_Offering = { false, "", "offering_offensive", "Flesh Offering Active", "Offering Inactive" };
            object[] Bone_Offering = { false, "", "offering_defensive", "Bone Offering Active", "Offering Inactive" };
            object[] Spirit_Offering = { false, "", "offering_spirit", "Spirit Offering Active", "Offering Inactive" };

            // Vaal Skills
            object[] Vaal_Haste = { false, "", "vaal_aura_speed", "Vaal Haste Active", "Vaal Haste Inactive" };
            object[] Vaal_Grace = { false, "", "vaal_aura_dodge", "Vaal Grace Active", "Vaal Grace Inactive" };
            object[] Vaal_Clarity = { false, "", "vaal_aura_no_mana_cost", "Vaal Clarity Active", "Vaal Clarity Inactive" };
            object[] Vaal_Discipline = { false, "", "vaal_aura_energy_shield", "Vaal Discipline Active", "Vaal Discipline Inactive" };

            // Others
            object[] Arcane_Surge = { false, "", "arcane_surge", "Arcane Surge Active", "Arcane Surge Inactive" };
            object[] Blood_Rage = { false, "", "blood_rage", "Blood Rage Active", "Blood Rage Inactive" };

            //Offensive Auras
            object[] Anger = { false, "", "player_aura_fire_damage", "Anger Active", "Anger Inactive" };
            object[] Hatred = { false, "", "player_aura_cold_damage", "Hatred Active", "Hatred Inactive" };
            object[] Wrath = { false, "", "player_aura_lightning_damage", "Wrath Active", "Wrath Inactive" };
            object[] Herald_of_Ash = { false, "", "herald_of_ash", "Herald of Ash Active", "Herald of Ash Inactive" };
            object[] Herald_of_Ice = { false, "", "herald_of_ice", "Herald of Ice Active", "Herald of Ice Inactive" };
            object[] Herald_of_Thunder = { false, "", "herald_of_thunder", "Herald of Thunder Active", "Herald of Thunder Inactive" };
            object[] Haste = { false, "", "player_aura_speed", "Haste Active", "Haste Inactive" };

            //Defensive Auras
            object[] Purity_of_Fire = { false, "", "player_aura_fire_resist", "Purity of Fire Active", "Purity of Fire Inactive" };
            object[] Purity_of_Ice = { false, "", "player_aura_cold_resist", "Purity of Ice Active", "Purity of Ice Inactive" };
            object[] Purity_of_Lightning = { false, "", "player_aura_lightning_resist", "Purity of Lightning Active", "Purity of Lightning Inactive" };
            object[] Purity_of_Elements = { false, "", "player_aura_resists", "Purity of Elements Active", "Purity of Elements Inactive" };
            object[] Vitality = { false, "", "player_aura_life_regen", "Vitality Active", "Vitality Inactive" };
            object[] Discipline = { false, "", "player_aura_energy_shield", "Discipline Active", "Discipline Inactive" };
            object[] Determination = { false, "", "player_aura_armour", "Determination Active", "Determination Inactive" };
            object[] Grace = { false, "", "player_aura_evasion", "Grace Active", "Grace Inactive" };
            object[] Clarity = { false, "", "player_aura_mana_regen", "Clarity Active", "Clarity Inactive" };


            /* Buff Array[]
             * 
             * Enable Buff,
             * Text over Icon,
             * Buff Name,
             * Active Icon,
             * Inactive Icon
             * Charges
            */
            // Charges
            object[] Power_Charges = { false, "", "power_charge", "\\Charges\\Power Charges", "\\Charges\\Power Charges Inactive", "" };
            object[] Frenzy_Charges = { false, "", "frenzy_charge", "\\Charges\\Frenzy Charges", "\\Charges\\Frenzy Charges Inactive", "" };
            object[] Endurance_Charges = { false, "", "endurance_charge", "\\Charges\\Endurance Charges", "\\Charges\\Endurance Charges Inactive", "" };


            // Loop through all buffs on me
            foreach (var buff in GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Life>().Buffs)
            {
                var isInfinity = float.IsInfinity(buff.Timer);
                var BuffText = isInfinity ? "" : Math.Ceiling(buff.Timer).ToString();
                var ThisBuff = buff.Name.ToLower();
                var Charges = buff.Charges < 0 ? "" : buff.Charges.ToString();

                #region Others
                if (ThisBuff.Equals((string)Arcane_Surge[2]))
                {
                    Arcane_Surge[0] = true;
                    Arcane_Surge[1] = BuffText;
                }
                if (ThisBuff.Equals((string)Blood_Rage[2]))
                {
                    Blood_Rage[0] = true;
                    Blood_Rage[1] = BuffText;
                }
                #endregion
                #region Vaal Skills
                else if (ThisBuff.Equals((string)Vaal_Haste[2]))
                {
                    Vaal_Haste[0] = true;
                    Vaal_Haste[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Vaal_Grace[2]))
                {
                    Vaal_Grace[0] = true;
                    Vaal_Grace[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Vaal_Clarity[2]))
                {
                    Vaal_Clarity[0] = true;
                    Vaal_Clarity[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Vaal_Discipline[2]))
                {
                    Vaal_Discipline[0] = true;
                    Vaal_Discipline[1] = BuffText;
                }
                #endregion
                #region Offerings
                else if (ThisBuff.Equals((string)Flesh_Offering[2]))
                {
                    Flesh_Offering[0] = true;
                    Flesh_Offering[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Bone_Offering[2]))
                {
                    Bone_Offering[0] = true;
                    Bone_Offering[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Spirit_Offering[2]))
                {
                    Spirit_Offering[0] = true;
                    Spirit_Offering[1] = BuffText;
                }
                #endregion
                #region Golems
                else if (ThisBuff.Equals((string)Fire_Golem[2]))
                {
                    Fire_Golem[0] = true;
                    Fire_Golem[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Ice_Golem[2]))
                {
                    Ice_Golem[0] = true;
                    Ice_Golem[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Lightning_Golem[2]))
                {
                    Lightning_Golem[0] = true;
                    Lightning_Golem[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Chaos_Golem[2]))
                {
                    Chaos_Golem[0] = true;
                    Chaos_Golem[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Stone_Golem[2]))
                {
                    Stone_Golem[0] = true;
                    Stone_Golem[1] = BuffText;
                }
                #endregion
                #region Offensive Auras
                else if (ThisBuff.Equals((string)Anger[2]))
                {
                    Anger[0] = true;
                    Anger[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Hatred[2]))
                {
                    Hatred[0] = true;
                    Hatred[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Wrath[2]))
                {
                    Wrath[0] = true;
                    Wrath[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Herald_of_Ash[2]))
                {
                    Herald_of_Ash[0] = true;
                    Herald_of_Ash[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Herald_of_Ice[2]))
                {
                    Herald_of_Ice[0] = true;
                    Herald_of_Ice[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Herald_of_Thunder[2]))
                {
                    Herald_of_Thunder[0] = true;
                    Herald_of_Thunder[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Haste[2]))
                {
                    Haste[0] = true;
                    Haste[1] = BuffText;
                }
                #endregion
                #region Defensive Auras
                else if (ThisBuff.Equals((string)Purity_of_Fire[2]))
                {
                    Purity_of_Fire[0] = true;
                    Purity_of_Fire[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Purity_of_Ice[2]))
                {
                    Purity_of_Ice[0] = true;
                    Purity_of_Ice[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Purity_of_Lightning[2]))
                {
                    Purity_of_Lightning[0] = true;
                    Purity_of_Lightning[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Purity_of_Elements[2]))
                {
                    Purity_of_Elements[0] = true;
                    Purity_of_Elements[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Vitality[2]))
                {
                    Vitality[0] = true;
                    Vitality[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Discipline[2]))
                {
                    Discipline[0] = true;
                    Discipline[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Determination[2]))
                {
                    Determination[0] = true;
                    Determination[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Grace[2]))
                {
                    Grace[0] = true;
                    Grace[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Clarity[2]))
                {
                    Clarity[0] = true;
                    Clarity[1] = BuffText;
                }
                #endregion
                #region Charges
                else if (ThisBuff.Equals((string)Power_Charges[2]))
                {
                    Power_Charges[0] = true;
                    Power_Charges[1] = BuffText;
                    Power_Charges[5] = Charges;
                }
                else if (ThisBuff.Equals((string)Frenzy_Charges[2]))
                {
                    Frenzy_Charges[0] = true;
                    Frenzy_Charges[1] = BuffText;
                    Frenzy_Charges[5] = Charges;
                }
                else if (ThisBuff.Equals((string)Endurance_Charges[2]))
                {
                    Endurance_Charges[0] = true;
                    Endurance_Charges[1] = BuffText;
                    Endurance_Charges[5] = Charges;
                }
                #endregion

            }
            #region Others
            if (Settings.Others)
            {
                #region Arcane Surge
                if (Settings.Arcane_Surge)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Arcane_Surge_X, Settings.Arcane_Surge_Y, Settings.Arcane_Surge_Size, 30, (string)Arcane_Surge[1], (string)Arcane_Surge[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Arcane_Surge[0])
                            DrawBuff(Settings.Arcane_Surge_X, Settings.Arcane_Surge_Y, Settings.Arcane_Surge_Size, 30, (string)Arcane_Surge[1], (string)Arcane_Surge[3]);
                        else if (Settings.Arcane_Surge_ShowInactive)
                            DrawBuff(Settings.Arcane_Surge_X, Settings.Arcane_Surge_Y, Settings.Arcane_Surge_Size, 30, (string)Arcane_Surge[1], (string)Arcane_Surge[4]);
                    }
                }
                #endregion
                #region Blood_Rage
                if (Settings.Blood_Rage)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Blood_Rage_X, Settings.Blood_Rage_Y, Settings.Blood_Rage_Size, 30, (string)Blood_Rage[1], (string)Blood_Rage[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Blood_Rage[0])
                            DrawBuff(Settings.Blood_Rage_X, Settings.Blood_Rage_Y, Settings.Blood_Rage_Size, 30, (string)Blood_Rage[1], (string)Blood_Rage[3]);
                        else if (Settings.Blood_Rage_ShowInactive)
                            DrawBuff(Settings.Blood_Rage_X, Settings.Blood_Rage_Y, Settings.Blood_Rage_Size, 30, (string)Blood_Rage[1], (string)Blood_Rage[4]);
                    }
                }
                #endregion
            }
            #endregion
            #region Vaal Skills
            if (Settings.Vaal_Skills)
            {
                #region Vaal_Haste
                if (Settings.Vaal_Haste)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Vaal_Haste_X, Settings.Vaal_Haste_Y, Settings.Vaal_Haste_Size, 30, (string)Vaal_Haste[1], (string)Vaal_Haste[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Vaal_Haste[0])
                            DrawBuff(Settings.Vaal_Haste_X, Settings.Vaal_Haste_Y, Settings.Vaal_Haste_Size, 30, (string)Vaal_Haste[1], (string)Vaal_Haste[3]);
                        else if (Settings.Vaal_Haste_ShowInactive)
                            DrawBuff(Settings.Vaal_Haste_X, Settings.Vaal_Haste_Y, Settings.Vaal_Haste_Size, 30, (string)Vaal_Haste[1], (string)Vaal_Haste[4]);
                    }
                }
                #endregion 
                #region Vaal_Grace
                if (Settings.Vaal_Grace)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Vaal_Grace_X, Settings.Vaal_Grace_Y, Settings.Vaal_Grace_Size, 30, (string)Vaal_Grace[1], (string)Vaal_Grace[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Vaal_Grace[0])
                            DrawBuff(Settings.Vaal_Grace_X, Settings.Vaal_Grace_Y, Settings.Vaal_Grace_Size, 30, (string)Vaal_Grace[1], (string)Vaal_Grace[3]);
                        else if (Settings.Vaal_Grace_ShowInactive)
                            DrawBuff(Settings.Vaal_Grace_X, Settings.Vaal_Grace_Y, Settings.Vaal_Grace_Size, 30, (string)Vaal_Grace[1], (string)Vaal_Grace[4]);
                    }
                }
                #endregion 
                #region Vaal_Clarity
                if (Settings.Vaal_Clarity)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Vaal_Clarity_X, Settings.Vaal_Clarity_Y, Settings.Vaal_Clarity_Size, 30, (string)Vaal_Clarity[1], (string)Vaal_Clarity[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Vaal_Clarity[0])
                            DrawBuff(Settings.Vaal_Clarity_X, Settings.Vaal_Clarity_Y, Settings.Vaal_Clarity_Size, 30, (string)Vaal_Clarity[1], (string)Vaal_Clarity[3]);
                        else if (Settings.Vaal_Clarity_ShowInactive)
                            DrawBuff(Settings.Vaal_Clarity_X, Settings.Vaal_Clarity_Y, Settings.Vaal_Clarity_Size, 30, (string)Vaal_Clarity[1], (string)Vaal_Clarity[4]);
                    }
                }
                #endregion 
                #region Vaal_Discipline
                if (Settings.Vaal_Discipline)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Vaal_Discipline_X, Settings.Vaal_Discipline_Y, Settings.Vaal_Discipline_Size, 30, (string)Vaal_Discipline[1], (string)Vaal_Discipline[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Vaal_Discipline[0])
                            DrawBuff(Settings.Vaal_Discipline_X, Settings.Vaal_Discipline_Y, Settings.Vaal_Discipline_Size, 30, (string)Vaal_Discipline[1], (string)Vaal_Discipline[3]);
                        else if (Settings.Vaal_Discipline_ShowInactive)
                            DrawBuff(Settings.Vaal_Discipline_X, Settings.Vaal_Discipline_Y, Settings.Vaal_Discipline_Size, 30, (string)Vaal_Discipline[1], (string)Vaal_Discipline[4]);
                    }
                }
                #endregion 
            }
            #endregion
            #region Offerings
            if (Settings.Offerings)
            {
                #region Spirit Offerings
                if (Settings.Offering_Effect)
                {
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, 30, (string)Flesh_Offering[1], (string)Flesh_Offering[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Flesh_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, 30, (string)Flesh_Offering[1], (string)Flesh_Offering[3]);
                        else if ((bool)Bone_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, 30, (string)Bone_Offering[1], (string)Bone_Offering[3]);
                        else if ((bool)Spirit_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, 30, (string)Spirit_Offering[1], (string)Spirit_Offering[3]);
                        else if (Settings.Offering_Effect_ShowInactive)
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, 30, (string)Flesh_Offering[1], (string)Flesh_Offering[4]);
                    }
                }
                #endregion 
            }
            #endregion
            #region Golems
            if (Settings.Golems)
            {
                #region Fire Golem
                if (Settings.Fire_Golem)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Fire_Golem_X, Settings.Fire_Golem_Y, Settings.Fire_Golem_Size, 30, (string)Fire_Golem[1], (string)Fire_Golem[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Fire_Golem[0])
                            DrawBuff(Settings.Fire_Golem_X, Settings.Fire_Golem_Y, Settings.Fire_Golem_Size, 30, (string)Fire_Golem[1], (string)Fire_Golem[3]);
                        else if (Settings.Fire_Golem_ShowInactive)
                            DrawBuff(Settings.Fire_Golem_X, Settings.Fire_Golem_Y, Settings.Fire_Golem_Size, 30, (string)Fire_Golem[1], (string)Fire_Golem[4]);
                    }
                }
                #endregion
                #region Ice Golem
                if (Settings.Ice_Golem)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Ice_Golem_X, Settings.Ice_Golem_Y, Settings.Ice_Golem_Size, 30, (string)Ice_Golem[1], (string)Ice_Golem[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Ice_Golem[0])
                            DrawBuff(Settings.Ice_Golem_X, Settings.Ice_Golem_Y, Settings.Ice_Golem_Size, 30, (string)Ice_Golem[1], (string)Ice_Golem[3]);
                        else if (Settings.Ice_Golem_ShowInactive)
                            DrawBuff(Settings.Ice_Golem_X, Settings.Ice_Golem_Y, Settings.Ice_Golem_Size, 30, (string)Ice_Golem[1], (string)Ice_Golem[4]);
                    }
                }
                #endregion
                #region Lightning Golem
                if (Settings.Lightning_Golem)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Lightning_Golem_X, Settings.Lightning_Golem_Y, Settings.Lightning_Golem_Size, 30, (string)Lightning_Golem[1], (string)Lightning_Golem[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Lightning_Golem[0])
                            DrawBuff(Settings.Lightning_Golem_X, Settings.Lightning_Golem_Y, Settings.Lightning_Golem_Size, 30, (string)Lightning_Golem[1], (string)Lightning_Golem[3]);
                        else if (Settings.Lightning_Golem_ShowInactive)
                            DrawBuff(Settings.Lightning_Golem_X, Settings.Lightning_Golem_Y, Settings.Lightning_Golem_Size, 30, (string)Lightning_Golem[1], (string)Lightning_Golem[4]);
                    }
                }
                #endregion
                #region Chaos Golem
                if (Settings.Chaos_Golem)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Chaos_Golem_X, Settings.Chaos_Golem_Y, Settings.Chaos_Golem_Size, 30, (string)Chaos_Golem[1], (string)Chaos_Golem[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Chaos_Golem[0])
                            DrawBuff(Settings.Chaos_Golem_X, Settings.Chaos_Golem_Y, Settings.Chaos_Golem_Size, 30, (string)Chaos_Golem[1], (string)Chaos_Golem[3]);
                        else if (Settings.Chaos_Golem_ShowInactive)
                            DrawBuff(Settings.Chaos_Golem_X, Settings.Chaos_Golem_Y, Settings.Chaos_Golem_Size, 30, (string)Chaos_Golem[1], (string)Chaos_Golem[4]);
                    }
                }
                #endregion
                #region Stone Golem
                if (Settings.Stone_Golem)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Stone_Golem_X, Settings.Stone_Golem_Y, Settings.Stone_Golem_Size, 30, (string)Stone_Golem[1], (string)Stone_Golem[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Stone_Golem[0])
                            DrawBuff(Settings.Stone_Golem_X, Settings.Stone_Golem_Y, Settings.Stone_Golem_Size, 30, (string)Stone_Golem[1], (string)Stone_Golem[3]);
                        else if (Settings.Stone_Golem_ShowInactive)
                            DrawBuff(Settings.Stone_Golem_X, Settings.Stone_Golem_Y, Settings.Stone_Golem_Size, 30, (string)Stone_Golem[1], (string)Stone_Golem[4]);
                    }
                }
                #endregion
            }
            #endregion
            #region Offensive Auras
            if (Settings.Offensive_Aura)
            {
                #region Anger
                if (Settings.Anger)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Anger_X, Settings.Anger_Y, Settings.Anger_Size, 30, (string)Anger[1], (string)Anger[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Anger[0])
                            DrawBuff(Settings.Anger_X, Settings.Anger_Y, Settings.Anger_Size, 30, (string)Anger[1], (string)Anger[3]);
                        else if (Settings.Anger_ShowInactive)
                            DrawBuff(Settings.Anger_X, Settings.Anger_Y, Settings.Anger_Size, 30, (string)Anger[1], (string)Anger[4]);
                    }
                }
                #endregion 
                #region Hatred
                if (Settings.Hatred)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Hatred_X, Settings.Hatred_Y, Settings.Hatred_Size, 30, (string)Hatred[1], (string)Hatred[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Hatred[0])
                            DrawBuff(Settings.Hatred_X, Settings.Hatred_Y, Settings.Hatred_Size, 30, (string)Hatred[1], (string)Hatred[3]);
                        else if (Settings.Hatred_ShowInactive)
                            DrawBuff(Settings.Hatred_X, Settings.Hatred_Y, Settings.Hatred_Size, 30, (string)Hatred[1], (string)Hatred[4]);
                    }
                }
                #endregion 
                #region Wrath
                if (Settings.Wrath)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Wrath_X, Settings.Wrath_Y, Settings.Wrath_Size, 30, (string)Wrath[1], (string)Wrath[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Wrath[0])
                            DrawBuff(Settings.Wrath_X, Settings.Wrath_Y, Settings.Wrath_Size, 30, (string)Wrath[1], (string)Wrath[3]);
                        else if (Settings.Wrath_ShowInactive)
                            DrawBuff(Settings.Wrath_X, Settings.Wrath_Y, Settings.Wrath_Size, 30, (string)Wrath[1], (string)Wrath[4]);
                    }
                }
                #endregion 
                #region Herald_of_Ash
                if (Settings.Herald_of_Ash)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Herald_of_Ash_X, Settings.Herald_of_Ash_Y, Settings.Herald_of_Ash_Size, 30, (string)Herald_of_Ash[1], (string)Herald_of_Ash[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Herald_of_Ash[0])
                            DrawBuff(Settings.Herald_of_Ash_X, Settings.Herald_of_Ash_Y, Settings.Herald_of_Ash_Size, 30, (string)Herald_of_Ash[1], (string)Herald_of_Ash[3]);
                        else if (Settings.Herald_of_Ash_ShowInactive)
                            DrawBuff(Settings.Herald_of_Ash_X, Settings.Herald_of_Ash_Y, Settings.Herald_of_Ash_Size, 30, (string)Herald_of_Ash[1], (string)Herald_of_Ash[4]);
                    }
                }
                #endregion 
                #region Herald_of_Ice
                if (Settings.Herald_of_Ice)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Herald_of_Ice_X, Settings.Herald_of_Ice_Y, Settings.Herald_of_Ice_Size, 30, (string)Herald_of_Ice[1], (string)Herald_of_Ice[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Herald_of_Ice[0])
                            DrawBuff(Settings.Herald_of_Ice_X, Settings.Herald_of_Ice_Y, Settings.Herald_of_Ice_Size, 30, (string)Herald_of_Ice[1], (string)Herald_of_Ice[3]);
                        else if (Settings.Herald_of_Ice_ShowInactive)
                            DrawBuff(Settings.Herald_of_Ice_X, Settings.Herald_of_Ice_Y, Settings.Herald_of_Ice_Size, 30, (string)Herald_of_Ice[1], (string)Herald_of_Ice[4]);
                    }
                }
                #endregion 
                #region Herald_of_Thunder
                if (Settings.Herald_of_Thunder)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Herald_of_Thunder_X, Settings.Herald_of_Thunder_Y, Settings.Herald_of_Thunder_Size, 30, (string)Herald_of_Thunder[1], (string)Herald_of_Thunder[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Herald_of_Thunder[0])
                            DrawBuff(Settings.Herald_of_Thunder_X, Settings.Herald_of_Thunder_Y, Settings.Herald_of_Thunder_Size, 30, (string)Herald_of_Thunder[1], (string)Herald_of_Thunder[3]);
                        else if (Settings.Herald_of_Thunder_ShowInactive)
                            DrawBuff(Settings.Herald_of_Thunder_X, Settings.Herald_of_Thunder_Y, Settings.Herald_of_Thunder_Size, 30, (string)Herald_of_Thunder[1], (string)Herald_of_Thunder[4]);
                    }
                }
                #endregion 
                #region Haste
                if (Settings.Haste)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Haste_X, Settings.Haste_Y, Settings.Haste_Size, 30, (string)Haste[1], (string)Haste[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Haste[0])
                            DrawBuff(Settings.Haste_X, Settings.Haste_Y, Settings.Haste_Size, 30, (string)Haste[1], (string)Haste[3]);
                        else if (Settings.Haste_ShowInactive)
                            DrawBuff(Settings.Haste_X, Settings.Haste_Y, Settings.Haste_Size, 30, (string)Haste[1], (string)Haste[4]);
                    }
                }
                #endregion 
            }
            #endregion
            #region Defensive Auras
            if (Settings.Defenseive_Aura)
            {
                #region Purity_of_Fire
                if (Settings.Purity_of_Fire)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Purity_of_Fire_X, Settings.Purity_of_Fire_Y, Settings.Purity_of_Fire_Size, 30, (string)Purity_of_Fire[1], (string)Purity_of_Fire[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Purity_of_Fire[0])
                            DrawBuff(Settings.Purity_of_Fire_X, Settings.Purity_of_Fire_Y, Settings.Purity_of_Fire_Size, 30, (string)Purity_of_Fire[1], (string)Purity_of_Fire[3]);
                        else if (Settings.Purity_of_Fire_ShowInactive)
                            DrawBuff(Settings.Purity_of_Fire_X, Settings.Purity_of_Fire_Y, Settings.Purity_of_Fire_Size, 30, (string)Purity_of_Fire[1], (string)Purity_of_Fire[4]);
                    }
                }
                #endregion 
                #region Purity_of_Ice
                if (Settings.Purity_of_Ice)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Purity_of_Ice_X, Settings.Purity_of_Ice_Y, Settings.Purity_of_Ice_Size, 30, (string)Purity_of_Ice[1], (string)Purity_of_Ice[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Purity_of_Ice[0])
                            DrawBuff(Settings.Purity_of_Ice_X, Settings.Purity_of_Ice_Y, Settings.Purity_of_Ice_Size, 30, (string)Purity_of_Ice[1], (string)Purity_of_Ice[3]);
                        else if (Settings.Purity_of_Ice_ShowInactive)
                            DrawBuff(Settings.Purity_of_Ice_X, Settings.Purity_of_Ice_Y, Settings.Purity_of_Ice_Size, 30, (string)Purity_of_Ice[1], (string)Purity_of_Ice[4]);
                    }
                }
                #endregion 
                #region Purity_of_Lightning
                if (Settings.Purity_of_Lightning)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Purity_of_Lightning_X, Settings.Purity_of_Lightning_Y, Settings.Purity_of_Lightning_Size, 30, (string)Purity_of_Lightning[1], (string)Purity_of_Lightning[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Purity_of_Lightning[0])
                            DrawBuff(Settings.Purity_of_Lightning_X, Settings.Purity_of_Lightning_Y, Settings.Purity_of_Lightning_Size, 30, (string)Purity_of_Lightning[1], (string)Purity_of_Lightning[3]);
                        else if (Settings.Purity_of_Lightning_ShowInactive)
                            DrawBuff(Settings.Purity_of_Lightning_X, Settings.Purity_of_Lightning_Y, Settings.Purity_of_Lightning_Size, 30, (string)Purity_of_Lightning[1], (string)Purity_of_Lightning[4]);
                    }
                }
                #endregion 
                #region Purity_of_Elements
                if (Settings.Purity_of_Elements)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Purity_of_Elements_X, Settings.Purity_of_Elements_Y, Settings.Purity_of_Elements_Size, 30, (string)Purity_of_Elements[1], (string)Purity_of_Elements[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Purity_of_Elements[0])
                            DrawBuff(Settings.Purity_of_Elements_X, Settings.Purity_of_Elements_Y, Settings.Purity_of_Elements_Size, 30, (string)Purity_of_Elements[1], (string)Purity_of_Elements[3]);
                        else if (Settings.Purity_of_Elements_ShowInactive)
                            DrawBuff(Settings.Purity_of_Elements_X, Settings.Purity_of_Elements_Y, Settings.Purity_of_Elements_Size, 30, (string)Purity_of_Elements[1], (string)Purity_of_Elements[4]);
                    }
                }
                #endregion 
                #region Vitality
                if (Settings.Vitality)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Vitality_X, Settings.Vitality_Y, Settings.Vitality_Size, 30, (string)Vitality[1], (string)Vitality[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Vitality[0])
                            DrawBuff(Settings.Vitality_X, Settings.Vitality_Y, Settings.Vitality_Size, 30, (string)Vitality[1], (string)Vitality[3]);
                        else if (Settings.Vitality_ShowInactive)
                            DrawBuff(Settings.Vitality_X, Settings.Vitality_Y, Settings.Vitality_Size, 30, (string)Vitality[1], (string)Vitality[4]);
                    }
                }
                #endregion 
                #region Discipline
                if (Settings.Discipline)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Discipline_X, Settings.Discipline_Y, Settings.Discipline_Size, 30, (string)Discipline[1], (string)Discipline[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Discipline[0])
                            DrawBuff(Settings.Discipline_X, Settings.Discipline_Y, Settings.Discipline_Size, 30, (string)Discipline[1], (string)Discipline[3]);
                        else if (Settings.Discipline_ShowInactive)
                            DrawBuff(Settings.Discipline_X, Settings.Discipline_Y, Settings.Discipline_Size, 30, (string)Discipline[1], (string)Discipline[4]);
                    }
                }
                #endregion 
                #region Determination
                if (Settings.Determination)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Determination_X, Settings.Determination_Y, Settings.Determination_Size, 30, (string)Determination[1], (string)Determination[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Determination[0])
                            DrawBuff(Settings.Determination_X, Settings.Determination_Y, Settings.Determination_Size, 30, (string)Determination[1], (string)Determination[3]);
                        else if (Settings.Determination_ShowInactive)
                            DrawBuff(Settings.Determination_X, Settings.Determination_Y, Settings.Determination_Size, 30, (string)Determination[1], (string)Determination[4]);
                    }
                }
                #endregion 
                #region Grace
                if (Settings.Grace)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Grace_X, Settings.Grace_Y, Settings.Grace_Size, 30, (string)Grace[1], (string)Grace[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Grace[0])
                            DrawBuff(Settings.Grace_X, Settings.Grace_Y, Settings.Grace_Size, 30, (string)Grace[1], (string)Grace[3]);
                        else if (Settings.Grace_ShowInactive)
                            DrawBuff(Settings.Grace_X, Settings.Grace_Y, Settings.Grace_Size, 30, (string)Grace[1], (string)Grace[4]);
                    }
                }
                #endregion
                #region Clarity
                if (Settings.Clarity)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Clarity_X, Settings.Clarity_Y, Settings.Clarity_Size, 30, (string)Clarity[1], (string)Clarity[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Clarity[0])
                            DrawBuff(Settings.Clarity_X, Settings.Clarity_Y, Settings.Clarity_Size, 30, (string)Clarity[1], (string)Clarity[3]);
                        else if (Settings.Clarity_ShowInactive)
                            DrawBuff(Settings.Clarity_X, Settings.Clarity_Y, Settings.Clarity_Size, 30, (string)Clarity[1], (string)Clarity[4]);
                    }
                }
                #endregion
            }
            #endregion
            #region Charges
            if (Settings.Others)
            {
                #region Power_Charges
                if (Settings.Power_Charges)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Power_Charges_X, Settings.Power_Charges_Y, Settings.Power_Charges_Size, 30, (string)Power_Charges[1], (string)Power_Charges[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Power_Charges[0])
                            DrawBuff(Settings.Power_Charges_X, Settings.Power_Charges_Y, Settings.Power_Charges_Size, 30, (string)Power_Charges[1], (string)Power_Charges[3] + " " + (string)Power_Charges[5]);
                        else if (Settings.Power_Charges_ShowInactive)
                            DrawBuff(Settings.Power_Charges_X, Settings.Power_Charges_Y, Settings.Power_Charges_Size, 30, (string)Power_Charges[1], (string)Power_Charges[4]);
                    }
                }
                #endregion
                #region Frenzy_Charges
                if (Settings.Frenzy_Charges)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Frenzy_Charges_X, Settings.Frenzy_Charges_Y, Settings.Frenzy_Charges_Size, 30, (string)Frenzy_Charges[1], (string)Frenzy_Charges[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Frenzy_Charges[0])
                            DrawBuff(Settings.Frenzy_Charges_X, Settings.Frenzy_Charges_Y, Settings.Frenzy_Charges_Size, 30, (string)Frenzy_Charges[1], (string)Frenzy_Charges[3] + " " + (string)Frenzy_Charges[5]);
                        else if (Settings.Frenzy_Charges_ShowInactive)
                            DrawBuff(Settings.Frenzy_Charges_X, Settings.Frenzy_Charges_Y, Settings.Frenzy_Charges_Size, 30, (string)Frenzy_Charges[1], (string)Frenzy_Charges[4]);
                    }
                }
                #endregion
                #region Endurance_Charges
                if (Settings.Endurance_Charges)
                {
                    // Icon Forced On
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Endurance_Charges_X, Settings.Endurance_Charges_Y, Settings.Endurance_Charges_Size, 30, (string)Endurance_Charges[1], (string)Endurance_Charges[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Endurance_Charges[0])
                            DrawBuff(Settings.Endurance_Charges_X, Settings.Endurance_Charges_Y, Settings.Endurance_Charges_Size, 30, (string)Endurance_Charges[1], (string)Endurance_Charges[3] + " " + (string)Endurance_Charges[5]);
                        else if (Settings.Endurance_Charges_ShowInactive)
                            DrawBuff(Settings.Endurance_Charges_X, Settings.Endurance_Charges_Y, Settings.Endurance_Charges_Size, 30, (string)Endurance_Charges[1], (string)Endurance_Charges[4]);
                    }
                }
                #endregion
            }
            #endregion
        }

        private void DrawBuff(float BuffX, float BuffY, int BuffSize, int TextSize, string BuffTimerText, string BuffFile)
        {
            RectangleF rect = GameController.Window.GetWindowRectangle();
            var TestBuffWindow = new RectangleF(rect.Width * BuffX * .01f - BuffSize / 2, rect.Height * BuffY * .01f, BuffSize, BuffSize);
            Graphics.DrawPluginImage(PluginDirectory + $"/images/{BuffFile}.png", TestBuffWindow);
            Graphics.DrawText(BuffTimerText, TextSize, new Vector2(rect.Width * BuffX * .01f, rect.Height * BuffY * .01f - TextSize), Color.White, SharpDX.Direct3D9.FontDrawFlags.Center);
        }

        private void OnAreaChange(AreaController area)
        {
            _isTown = area.CurrentArea.IsTown;
        }
    }
}
