using PoeHUD.Controllers;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using PoeHUD.Hud.Settings;

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

            DrawBuffIcons();
        }

        public void DrawBuffIcons()
        {
            var Panels = GameController.Game.IngameState.IngameUi;

            if (_isTown || (Panels.AtlasPanel.IsVisible || Panels.OpenLeftPanel.IsVisible || Panels.TreePanel.IsVisible)) return;
            var x = GameController.Window.GetWindowRectangle().Width * 50 * .01f;
            var y = GameController.Window.GetWindowRectangle().Height * 50 * .01f;
            var position = new Vector2(x, y);

            /* TO-DO
             * Phase run - new_phase_run (new_phase_run_damage is presetn a fraction of a second before showing new_phase_run?)
             * Smoke Mine - smoke_mine_movement_speed
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
            // Others - Conflux
            object[] Conflux_Elemental = { false, "", "elementalist_all_damage_chills_shocks_ignites", "Elemental Conflux", "Elemental Conflux Inactive" };
            object[] Conflux_Chill = { false, "", "elementalist_all_damage_chills", "Chilling Conflux", "Elemental Conflux Inactive" };
            object[] Conflux_Shock = { false, "", "elementalist_all_damage_shocks", "Shocking Conflux", "Elemental Conflux Inactive" };
            object[] Conflux_Ignite = { false, "", "elementalist_all_damage_ignites", "Igniting Conflux", "Elemental Conflux Inactive" };

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

            // Curses
            object[] Curse_Poachers_Mark = { false, "", "curse_poachers_mark", "Poacher's Mark Active", "Poacher's Mark Inactive" };
            object[] Curse_Frostbite = { false, "", "curse_cold_weakness", "Frostbite Active", "Frostbite Inactive" };
            object[] Curse_Vulnerability = { false, "", "curse_vulnerability", "Vulnerability Active", "Vulnerability Inactive" };
            object[] Curse_Warlords_Mark = { false, "", "curse_warlords_mark", "Warlord's Mark Active", "Warlord's Mark Inactive" };
            object[] Curse_Flammability = { false, "", "curse_fire_weakness", "Flammability Active", "Flammability Inactive" };
            object[] Curse_Assassins_Mark = { false, "", "curse_assassins_mark", "Assassin's Mark Active", "Assassin's Mark Inactive" };
            object[] Curse_Elemental_Weakness = { false, "", "curse_elemental_weakness", "Elemental Weakness Active", "Elemental Weakness Inactive" };
            object[] Curse_Conductivity = { false, "", "curse_lightning_weakness", "Conductivity Active", "Conductivity Inactive" };
            object[] Curse_Enfeeble = { false, "", "curse_enfeeble", "Enfeeble Active", "Enfeeble Inactive" };
            object[] Curse_Punishment = { false, "", "curse_newpunishment", "Punishment Active", "Punishment Inactive" };
            object[] Curse_Projectile_Weakness = { false, "", "curse_projectile_weakness", "Projectile Weakness Active", "Projectile Weakness Inactive" };
            object[] Curse_Temporal_Chains = { false, "", "curse_temporal_chains", "Temporal Chains Active", "Temporal Chains Inactive" };


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
            object[] Power_Charges = { false, "", "power_charge", "Power Charges Active", "Power Charges Inactive", "" };
            object[] Frenzy_Charges = { false, "", "frenzy_charge", "Frenzy Charges Active", "Frenzy Charges Inactive", "" };
            object[] Endurance_Charges = { false, "", "endurance_charge", "Endurance Charges Active", "Endurance Charges Inactive", "" };
            object[] Blade_Vortex_Stacks = { false, "", "blade_vortex_counter", "Blade Vortex Active", "Blade Vortex Inactive", "" };
            object[] Reave_Stacks = { false, "", "reave_counter", "Reave Active", "Reave Inactive", "" };

            // Leeching
            object[] Leeching_Life = { false, "", "life_leech", "Life Leech Active", "Leech Inactive", };
            object[] Leeching_Mana = { false, "", "mana_leech", "Mana Leech Active", "Leech Inactive", };
            List<float> Leeching_Life_Buff_Durations = new List<float>();
            List<float> Leeching_Mana_Buff_Durations = new List<float>();


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
                if (ThisBuff.Equals((string)Conflux_Elemental[2]))
                {
                    Conflux_Elemental[0] = true;
                    Conflux_Elemental[1] = BuffText;
                }
                if (ThisBuff.Equals((string)Conflux_Chill[2]))
                {
                    Conflux_Chill[0] = true;
                    Conflux_Chill[1] = BuffText;
                }
                if (ThisBuff.Equals((string)Conflux_Shock[2]))
                {
                    Conflux_Shock[0] = true;
                    Conflux_Shock[1] = BuffText;
                }
                if (ThisBuff.Equals((string)Conflux_Ignite[2]))
                {
                    Conflux_Ignite[0] = true;
                    Conflux_Ignite[1] = BuffText;
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
                else if (ThisBuff.Equals((string)Blade_Vortex_Stacks[2]))
                {
                    Blade_Vortex_Stacks[0] = true;
                    Blade_Vortex_Stacks[1] = BuffText;
                    Blade_Vortex_Stacks[5] = Charges;
                }
                else if (ThisBuff.Equals((string)Reave_Stacks[2]))
                {
                    Reave_Stacks[0] = true;
                    Reave_Stacks[1] = BuffText;
                    Reave_Stacks[5] = Charges;
                }
                #endregion
                #region Curses
                else if (ThisBuff.Equals((string)Curse_Poachers_Mark[2]))
                {
                    Curse_Poachers_Mark[0] = true;
                    Curse_Poachers_Mark[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Frostbite[2]))
                {
                    Curse_Frostbite[0] = true;
                    Curse_Frostbite[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Vulnerability[2]))
                {
                    Curse_Vulnerability[0] = true;
                    Curse_Vulnerability[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Warlords_Mark[2]))
                {
                    Curse_Warlords_Mark[0] = true;
                    Curse_Warlords_Mark[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Flammability[2]))
                {
                    Curse_Flammability[0] = true;
                    Curse_Flammability[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Assassins_Mark[2]))
                {
                    Curse_Assassins_Mark[0] = true;
                    Curse_Assassins_Mark[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Elemental_Weakness[2]))
                {
                    Curse_Elemental_Weakness[0] = true;
                    Curse_Elemental_Weakness[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Conductivity[2]))
                {
                    Curse_Conductivity[0] = true;
                    Curse_Conductivity[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Enfeeble[2]))
                {
                    Curse_Enfeeble[0] = true;
                    Curse_Enfeeble[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Punishment[2]))
                {
                    Curse_Punishment[0] = true;
                    Curse_Punishment[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Projectile_Weakness[2]))
                {
                    Curse_Projectile_Weakness[0] = true;
                    Curse_Projectile_Weakness[1] = BuffText;
                }
                else if (ThisBuff.Equals((string)Curse_Temporal_Chains[2]))
                {
                    Curse_Temporal_Chains[0] = true;
                    Curse_Temporal_Chains[1] = BuffText;
                }
                #endregion
                #region Leeching
                else if (ThisBuff.Equals((string)Leeching_Life[2]))
                {
                    Leeching_Life[0] = true;
                    Leeching_Life_Buff_Durations.Add(buff.Timer);
                }
                else if (ThisBuff.Equals((string)Leeching_Mana[2]))
                {
                    Leeching_Mana[0] = true;
                    Leeching_Mana_Buff_Durations.Add(buff.Timer);
                }
                #endregion
            }
            #region Others
            if (Settings.Others)
            {
                #region Arcane Surge
                Try_Draw_Buff(Settings.Arcane_Surge, (bool)Arcane_Surge[0], Settings.Arcane_Surge_ShowInactive, true,
                    Settings.Arcane_Surge_X,
                    Settings.Arcane_Surge_Y,
                    Settings.Arcane_Surge_Size,
                    (string)Arcane_Surge[1], (string)Arcane_Surge[3], (string)Arcane_Surge[4]);
                #endregion
                #region Blood_Rage
                Try_Draw_Buff(Settings.Blood_Rage, (bool)Blood_Rage[0], Settings.Blood_Rage_ShowInactive, true,
                    Settings.Blood_Rage_X,
                    Settings.Blood_Rage_Y,
                    Settings.Blood_Rage_Size,
                    (string)Blood_Rage[1], (string)Blood_Rage[3], (string)Blood_Rage[4]);
                #endregion
                #region Elemental_Conflux
                if (Settings.Elemental_Conflux)
                {
                    if (Settings.Force_Icons_On)
                    {
                        DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, "99", (string)Conflux_Elemental[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Conflux_Elemental[0])
                            DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, (string)Conflux_Elemental[1], (string)Conflux_Elemental[3]);
                        else if ((bool)Conflux_Chill[0])
                            DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, (string)Conflux_Chill[1], (string)Conflux_Chill[3]);
                        else if ((bool)Conflux_Shock[0])
                            DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, (string)Conflux_Shock[1], (string)Conflux_Shock[3]);
                        else if ((bool)Conflux_Ignite[0])
                            DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, (string)Conflux_Ignite[1], (string)Conflux_Ignite[3]);
                        else if (Settings.Elemental_Conflux_ShowInactive)
                            DrawBuff(Settings.Elemental_Conflux_X, Settings.Elemental_Conflux_Y, Settings.Elemental_Conflux_Size, (string)Conflux_Elemental[1], (string)Conflux_Elemental[4]);
                    }
                }
                #endregion 
            }
            #endregion
            #region Vaal Skills
            if (Settings.Vaal_Skills)
            {
                #region Vaal_Haste
                Try_Draw_Buff(Settings.Vaal_Haste, (bool)Vaal_Haste[0], Settings.Vaal_Haste_ShowInactive, true,
                    Settings.Vaal_Haste_X,
                    Settings.Vaal_Haste_Y,
                    Settings.Vaal_Haste_Size,
                    (string)Vaal_Haste[1], (string)Vaal_Haste[3], (string)Vaal_Haste[4]);
                #endregion 
                #region Vaal_Grace
                Try_Draw_Buff(Settings.Vaal_Grace, (bool)Vaal_Grace[0], Settings.Vaal_Grace_ShowInactive, true,
                    Settings.Vaal_Grace_X,
                    Settings.Vaal_Grace_Y,
                    Settings.Vaal_Grace_Size,
                    (string)Vaal_Grace[1], (string)Vaal_Grace[3], (string)Vaal_Grace[4]);
                #endregion 
                #region Vaal_Clarity
                Try_Draw_Buff(Settings.Vaal_Clarity, (bool)Vaal_Clarity[0], Settings.Vaal_Clarity_ShowInactive, true,
                    Settings.Vaal_Clarity_X,
                    Settings.Vaal_Clarity_Y,
                    Settings.Vaal_Clarity_Size,
                    (string)Vaal_Clarity[1], (string)Vaal_Clarity[3], (string)Vaal_Clarity[4]);
                #endregion 
                #region Vaal_Discipline
                Try_Draw_Buff(Settings.Vaal_Discipline, (bool)Vaal_Discipline[0], Settings.Vaal_Discipline_ShowInactive, true,
                    Settings.Vaal_Discipline_X,
                    Settings.Vaal_Discipline_Y,
                    Settings.Vaal_Discipline_Size,
                    (string)Vaal_Discipline[1], (string)Vaal_Discipline[3], (string)Vaal_Discipline[4]);
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
                        DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, "", (string)Flesh_Offering[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool)Flesh_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, (string)Flesh_Offering[1], (string)Flesh_Offering[3]);
                        else if ((bool)Bone_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, (string)Bone_Offering[1], (string)Bone_Offering[3]);
                        else if ((bool)Spirit_Offering[0])
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, (string)Spirit_Offering[1], (string)Spirit_Offering[3]);
                        else if (Settings.Offering_Effect_ShowInactive)
                            DrawBuff(Settings.Offering_Effect_X, Settings.Offering_Effect_Y, Settings.Offering_Effect_Size, (string)Flesh_Offering[1], (string)Flesh_Offering[4]);
                    }
                }
                #endregion 
            }
            #endregion
            #region Golems
            if (Settings.Golems)
            {
                #region Fire Golem
                Try_Draw_Buff(Settings.Fire_Golem, (bool)Fire_Golem[0], Settings.Fire_Golem_ShowInactive, false,
                    Settings.Fire_Golem_X,
                    Settings.Fire_Golem_Y,
                    Settings.Fire_Golem_Size,
                    (string)Fire_Golem[1], (string)Fire_Golem[3], (string)Fire_Golem[4]);
                #endregion
                #region Ice Golem
                Try_Draw_Buff(Settings.Ice_Golem, (bool)Ice_Golem[0], Settings.Ice_Golem_ShowInactive, false,
                    Settings.Ice_Golem_X,
                    Settings.Ice_Golem_Y,
                    Settings.Ice_Golem_Size,
                    (string)Ice_Golem[1], (string)Ice_Golem[3], (string)Ice_Golem[4]);
                #endregion
                #region Lightning Golem
                Try_Draw_Buff(Settings.Lightning_Golem, (bool)Lightning_Golem[0], Settings.Lightning_Golem_ShowInactive, false,
                    Settings.Lightning_Golem_X,
                    Settings.Lightning_Golem_Y,
                    Settings.Lightning_Golem_Size,
                    (string)Lightning_Golem[1], (string)Lightning_Golem[3], (string)Lightning_Golem[4]);
                #endregion
                #region Chaos Golem
                Try_Draw_Buff(Settings.Chaos_Golem, (bool)Chaos_Golem[0], Settings.Chaos_Golem_ShowInactive, false,
                    Settings.Chaos_Golem_X,
                    Settings.Chaos_Golem_Y,
                    Settings.Chaos_Golem_Size,
                    (string)Chaos_Golem[1], (string)Chaos_Golem[3], (string)Chaos_Golem[4]);
                #endregion
                #region Stone Golem
                Try_Draw_Buff(Settings.Stone_Golem, (bool)Stone_Golem[0], Settings.Stone_Golem_ShowInactive, false,
                    Settings.Stone_Golem_X,
                    Settings.Stone_Golem_Y,
                    Settings.Stone_Golem_Size,
                    (string)Stone_Golem[1], (string)Stone_Golem[3], (string)Stone_Golem[4]);
                #endregion
            }
            #endregion
            #region Offensive Auras
            if (Settings.Offensive_Aura)
            {
                #region Anger
                Try_Draw_Buff(Settings.Anger, (bool)Anger[0], Settings.Anger_ShowInactive, false,
                    Settings.Anger_X,
                    Settings.Anger_Y,
                    Settings.Anger_Size,
                    (string)Anger[1], (string)Anger[3], (string)Anger[4]);
                #endregion 
                #region Hatred
                Try_Draw_Buff(Settings.Hatred, (bool)Hatred[0], Settings.Hatred_ShowInactive, false,
                    Settings.Hatred_X,
                    Settings.Hatred_Y,
                    Settings.Hatred_Size,
                    (string)Hatred[1], (string)Hatred[3], (string)Hatred[4]);
                #endregion 
                #region Wrath
                Try_Draw_Buff(Settings.Wrath, (bool)Wrath[0], Settings.Wrath_ShowInactive, false,
                    Settings.Wrath_X,
                    Settings.Wrath_Y,
                    Settings.Wrath_Size,
                    (string)Wrath[1], (string)Wrath[3], (string)Wrath[4]);
                #endregion 
                #region Herald_of_Ash
                Try_Draw_Buff(Settings.Herald_of_Ash, (bool)Herald_of_Ash[0], Settings.Herald_of_Ash_ShowInactive, false,
                    Settings.Herald_of_Ash_X,
                    Settings.Herald_of_Ash_Y,
                    Settings.Herald_of_Ash_Size,
                    (string)Herald_of_Ash[1], (string)Herald_of_Ash[3], (string)Herald_of_Ash[4]);
                #endregion 
                #region Herald_of_Ice
                Try_Draw_Buff(Settings.Herald_of_Ice, (bool)Herald_of_Ice[0], Settings.Herald_of_Ice_ShowInactive, false,
                    Settings.Herald_of_Ice_X,
                    Settings.Herald_of_Ice_Y,
                    Settings.Herald_of_Ice_Size,
                    (string)Herald_of_Ice[1], (string)Herald_of_Ice[3], (string)Herald_of_Ice[4]);
                #endregion 
                #region Herald_of_Thunder
                Try_Draw_Buff(Settings.Herald_of_Thunder, (bool)Herald_of_Thunder[0], Settings.Herald_of_Thunder_ShowInactive, false,
                    Settings.Herald_of_Thunder_X,
                    Settings.Herald_of_Thunder_Y,
                    Settings.Herald_of_Thunder_Size,
                    (string)Herald_of_Thunder[1], (string)Herald_of_Thunder[3], (string)Herald_of_Thunder[4]);
                #endregion 
                #region Haste
                Try_Draw_Buff(Settings.Haste, (bool)Haste[0], Settings.Haste_ShowInactive, false,
                    Settings.Haste_X,
                    Settings.Haste_Y,
                    Settings.Haste_Size,
                    (string)Haste[1], (string)Haste[3], (string)Haste[4]);
                #endregion 
            }
            #endregion
            #region Defensive Auras
            if (Settings.Defenseive_Aura)
            {
                #region Purity_of_Fire
                Try_Draw_Buff(Settings.Purity_of_Fire, (bool)Purity_of_Fire[0], Settings.Purity_of_Fire_ShowInactive, false,
                    Settings.Purity_of_Fire_X,
                    Settings.Purity_of_Fire_Y,
                    Settings.Purity_of_Fire_Size,
                    (string)Purity_of_Fire[1], (string)Purity_of_Fire[3], (string)Purity_of_Fire[4]);
                #endregion 
                #region Purity_of_Ice
                Try_Draw_Buff(Settings.Purity_of_Ice, (bool)Purity_of_Ice[0], Settings.Purity_of_Ice_ShowInactive, false,
                    Settings.Purity_of_Ice_X,
                    Settings.Purity_of_Ice_Y,
                    Settings.Purity_of_Ice_Size,
                    (string)Purity_of_Ice[1], (string)Purity_of_Ice[3], (string)Purity_of_Ice[4]);
                #endregion 
                #region Purity_of_Lightning
                Try_Draw_Buff(Settings.Purity_of_Lightning, (bool)Purity_of_Lightning[0], Settings.Purity_of_Lightning_ShowInactive, false,
                    Settings.Purity_of_Lightning_X,
                    Settings.Purity_of_Lightning_Y,
                    Settings.Purity_of_Lightning_Size,
                    (string)Purity_of_Lightning[1], (string)Purity_of_Lightning[3], (string)Purity_of_Lightning[4]);
                #endregion 
                #region Purity_of_Elements
                Try_Draw_Buff(Settings.Purity_of_Elements, (bool)Purity_of_Elements[0], Settings.Purity_of_Elements_ShowInactive, false,
                    Settings.Purity_of_Elements_X,
                    Settings.Purity_of_Elements_Y,
                    Settings.Purity_of_Elements_Size,
                    (string)Purity_of_Elements[1], (string)Purity_of_Elements[3], (string)Purity_of_Elements[4]);
                #endregion 
                #region Vitality
                Try_Draw_Buff(Settings.Vitality, (bool)Vitality[0], Settings.Vitality_ShowInactive, false,
                    Settings.Vitality_X,
                    Settings.Vitality_Y,
                    Settings.Vitality_Size,
                    (string)Vitality[1], (string)Vitality[3], (string)Vitality[4]);
                #endregion 
                #region Discipline
                Try_Draw_Buff(Settings.Discipline, (bool)Discipline[0], Settings.Discipline_ShowInactive, false,
                    Settings.Discipline_X,
                    Settings.Discipline_Y,
                    Settings.Discipline_Size,
                    (string)Discipline[1], (string)Discipline[3], (string)Discipline[4]);
                #endregion 
                #region Determination
                Try_Draw_Buff(Settings.Determination, (bool)Determination[0], Settings.Determination_ShowInactive, false,
                    Settings.Determination_X,
                    Settings.Determination_Y,
                    Settings.Determination_Size,
                    (string)Determination[1], (string)Determination[3], (string)Determination[4]);
                #endregion 
                #region Grace
                Try_Draw_Buff(Settings.Grace, (bool)Grace[0], Settings.Grace_ShowInactive, false,
                    Settings.Grace_X,
                    Settings.Grace_Y,
                    Settings.Grace_Size,
                    (string)Grace[1], (string)Grace[3], (string)Grace[4]);
                #endregion
                #region Clarity
                Try_Draw_Buff(Settings.Clarity, (bool)Clarity[0], Settings.Clarity_ShowInactive, false,
                    Settings.Clarity_X,
                    Settings.Clarity_Y,
                    Settings.Clarity_Size,
                    (string)Clarity[1], (string)Clarity[3], (string)Clarity[4]);
                #endregion
            }
            #endregion
            #region Charges
            if (Settings.Others)
            {
                #region Power_Charges
                Try_Draw_Buff(Settings.Power_Charges, (bool)Power_Charges[0], Settings.Power_Charges_ShowInactive, true,
                    Settings.Power_Charges_X,
                    Settings.Power_Charges_Y,
                    Settings.Power_Charges_Size,
                    (string)Power_Charges[1], (string)Power_Charges[3], (string)Power_Charges[4], (string)Power_Charges[5]);
                #endregion
                #region Frenzy_Charges
                Try_Draw_Buff(Settings.Frenzy_Charges, (bool)Frenzy_Charges[0], Settings.Frenzy_Charges_ShowInactive, true,
                    Settings.Frenzy_Charges_X,
                    Settings.Frenzy_Charges_Y,
                    Settings.Frenzy_Charges_Size,
                    (string)Frenzy_Charges[1], (string)Frenzy_Charges[3], (string)Frenzy_Charges[4], (string)Frenzy_Charges[5]);
                #endregion
                #region Endurance_Charges
                Try_Draw_Buff(Settings.Endurance_Charges, (bool)Endurance_Charges[0], Settings.Endurance_Charges_ShowInactive, true,
                    Settings.Endurance_Charges_X,
                    Settings.Endurance_Charges_Y,
                    Settings.Endurance_Charges_Size,
                    (string)Endurance_Charges[1], (string)Endurance_Charges[3], (string)Endurance_Charges[4], (string)Endurance_Charges[5]);
                #endregion
                #region Blade_Vortex_Stacks
                Try_Draw_Buff(Settings.Blade_Vortex_Stacks, (bool)Blade_Vortex_Stacks[0], Settings.Blade_Vortex_Stacks_ShowInactive, true,
                    Settings.Blade_Vortex_Stacks_X,
                    Settings.Blade_Vortex_Stacks_Y,
                    Settings.Blade_Vortex_Stacks_Size,
                    (string)Blade_Vortex_Stacks[1], (string)Blade_Vortex_Stacks[3], (string)Blade_Vortex_Stacks[4], (string)Blade_Vortex_Stacks[5]);
                #endregion
                #region Reave_Stacks
                Try_Draw_Buff(Settings.Reave_Stacks, (bool)Reave_Stacks[0], Settings.Reave_Stacks_ShowInactive, true,
                    Settings.Reave_Stacks_X,
                    Settings.Reave_Stacks_Y,
                    Settings.Reave_Stacks_Size,
                    (string)Reave_Stacks[1], (string)Reave_Stacks[3], (string)Reave_Stacks[4], (string)Reave_Stacks[5]);
                #endregion
            }
            #endregion
            #region Curses
            if (Settings.Curses)
            {
                #region Curse_Poachers_Mark
                Try_Draw_Buff(Settings.Curse_Poachers_Mark, (bool)Curse_Poachers_Mark[0], Settings.Curse_Poachers_Mark_ShowInactive, true,
                    Settings.Curse_Poachers_Mark_X,
                    Settings.Curse_Poachers_Mark_Y,
                    Settings.Curse_Poachers_Mark_Size,
                    (string)Curse_Poachers_Mark[1], (string)Curse_Poachers_Mark[3], (string)Curse_Poachers_Mark[4]);
                #endregion
                #region Curse_Frostbite
                Try_Draw_Buff(Settings.Curse_Frostbite, (bool)Curse_Frostbite[0], Settings.Curse_Frostbite_ShowInactive, true,
                    Settings.Curse_Frostbite_X,
                    Settings.Curse_Frostbite_Y,
                    Settings.Curse_Frostbite_Size,
                    (string)Curse_Frostbite[1], (string)Curse_Frostbite[3], (string)Curse_Frostbite[4]);
                #endregion
                #region Curse_Vulnerability
                Try_Draw_Buff(Settings.Curse_Vulnerability, (bool)Curse_Vulnerability[0], Settings.Curse_Vulnerability_ShowInactive, true,
                    Settings.Curse_Vulnerability_X,
                    Settings.Curse_Vulnerability_Y,
                    Settings.Curse_Vulnerability_Size,
                    (string)Curse_Vulnerability[1], (string)Curse_Vulnerability[3], (string)Curse_Vulnerability[4]);
                #endregion
                #region Curse_Warlords_Mark
                Try_Draw_Buff(Settings.Curse_Warlords_Mark, (bool)Curse_Warlords_Mark[0], Settings.Curse_Warlords_Mark_ShowInactive, true,
                    Settings.Curse_Warlords_Mark_X,
                    Settings.Curse_Warlords_Mark_Y,
                    Settings.Curse_Warlords_Mark_Size,
                    (string)Curse_Warlords_Mark[1], (string)Curse_Warlords_Mark[3], (string)Curse_Warlords_Mark[4]);
                #endregion
                #region Curse_Flammability
                Try_Draw_Buff(Settings.Curse_Flammability, (bool)Curse_Flammability[0], Settings.Curse_Flammability_ShowInactive, true,
                    Settings.Curse_Flammability_X,
                    Settings.Curse_Flammability_Y,
                    Settings.Curse_Flammability_Size,
                    (string)Curse_Flammability[1], (string)Curse_Flammability[3], (string)Curse_Flammability[4]);
                #endregion
                #region Curse_Assassins_Mark
                Try_Draw_Buff(Settings.Curse_Assassins_Mark, (bool)Curse_Assassins_Mark[0], Settings.Curse_Assassins_Mark_ShowInactive, true,
                    Settings.Curse_Assassins_Mark_X,
                    Settings.Curse_Assassins_Mark_Y,
                    Settings.Curse_Assassins_Mark_Size,
                    (string)Curse_Assassins_Mark[1], (string)Curse_Assassins_Mark[3], (string)Curse_Assassins_Mark[4]);
                #endregion
                #region Curse_Elemental_Weakness
                Try_Draw_Buff(Settings.Curse_Elemental_Weakness, (bool)Curse_Elemental_Weakness[0], Settings.Curse_Elemental_Weakness_ShowInactive, true,
                    Settings.Curse_Elemental_Weakness_X,
                    Settings.Curse_Elemental_Weakness_Y,
                    Settings.Curse_Elemental_Weakness_Size,
                    (string)Curse_Elemental_Weakness[1], (string)Curse_Elemental_Weakness[3], (string)Curse_Elemental_Weakness[4]);
                #endregion
                #region Curse_Conductivity
                Try_Draw_Buff(Settings.Curse_Conductivity, (bool)Curse_Conductivity[0], Settings.Curse_Conductivity_ShowInactive, true,
                    Settings.Curse_Conductivity_X,
                    Settings.Curse_Conductivity_Y,
                    Settings.Curse_Conductivity_Size,
                    (string)Curse_Conductivity[1], (string)Curse_Conductivity[3], (string)Curse_Conductivity[4]);
                #endregion
                #region Curse_Enfeeble
                Try_Draw_Buff(Settings.Curse_Enfeeble, (bool)Curse_Enfeeble[0], Settings.Curse_Enfeeble_ShowInactive, true,
                    Settings.Curse_Enfeeble_X,
                    Settings.Curse_Enfeeble_Y,
                    Settings.Curse_Enfeeble_Size,
                    (string)Curse_Enfeeble[1], (string)Curse_Enfeeble[3], (string)Curse_Enfeeble[4]);
                #endregion
                #region Curse_Punishment
                Try_Draw_Buff(Settings.Curse_Punishment, (bool)Curse_Punishment[0], Settings.Curse_Punishment_ShowInactive, true,
                    Settings.Curse_Punishment_X,
                    Settings.Curse_Punishment_Y,
                    Settings.Curse_Punishment_Size,
                    (string)Curse_Punishment[1], (string)Curse_Punishment[3], (string)Curse_Punishment[4]);
                #endregion
                #region Curse_Projectile_Weakness
                Try_Draw_Buff(Settings.Curse_Projectile_Weakness, (bool)Curse_Projectile_Weakness[0], Settings.Curse_Projectile_Weakness_ShowInactive, true,
                    Settings.Curse_Projectile_Weakness_X,
                    Settings.Curse_Projectile_Weakness_Y,
                    Settings.Curse_Projectile_Weakness_Size,
                    (string)Curse_Projectile_Weakness[1], (string)Curse_Projectile_Weakness[3], (string)Curse_Projectile_Weakness[4]);
                #endregion
                #region Curse_Temporal_Chains
                Try_Draw_Buff(Settings.Curse_Temporal_Chains, (bool)Curse_Temporal_Chains[0], Settings.Curse_Temporal_Chains_ShowInactive, true,
                    Settings.Curse_Temporal_Chains_X,
                    Settings.Curse_Temporal_Chains_Y,
                    Settings.Curse_Temporal_Chains_Size,
                    (string)Curse_Temporal_Chains[1], (string)Curse_Temporal_Chains[3], (string)Curse_Temporal_Chains[4]);
                #endregion
            }
            #endregion
            #region Leeching
            if (Settings.Leeching)
            {
                #region Leeching_Life
                if ((bool)Leeching_Life[0])
                {
                    // Sort life leech buff timers Highest -> Lowest
                    Leeching_Life_Buff_Durations.Sort();
                    Leeching_Life_Buff_Durations.Reverse();
                    Leeching_Life[1] = Math.Ceiling(Leeching_Life_Buff_Durations.First()).ToString();
                }

                Try_Draw_Buff(Settings.Leeching_Life, (bool)Leeching_Life[0], Settings.Leeching_Life_ShowInactive, true,
                    Settings.Leeching_Life_X,
                    Settings.Leeching_Life_Y,
                    Settings.Leeching_Life_Size,
                    (string)Leeching_Life[1], (string)Leeching_Life[3], (string)Leeching_Life[4], Leeching_Life_Buff_Durations.Count.ToString());
                #endregion
                #region Leeching_Mana
                if ((bool)Leeching_Mana[0])
                {
                    // Sort life leech buff timers Highest -> Lowest
                    Leeching_Mana_Buff_Durations.Sort();
                    Leeching_Mana_Buff_Durations.Reverse();
                    Leeching_Mana[1] = Math.Ceiling(Leeching_Mana_Buff_Durations.First()).ToString();
                }

                Try_Draw_Buff(Settings.Leeching_Mana, (bool)Leeching_Mana[0], Settings.Leeching_Mana_ShowInactive, true,
                    Settings.Leeching_Mana_X,
                    Settings.Leeching_Mana_Y,
                    Settings.Leeching_Mana_Size,
                    (string)Leeching_Mana[1], (string)Leeching_Mana[3], (string)Leeching_Mana[4], Leeching_Mana_Buff_Durations.Count.ToString());
                #endregion
            }
            #endregion
        }

        private void Try_Draw_Buff(ToggleNode isOn, bool gotBuff, ToggleNode showFade, bool CouldHaveTimer, RangeNode<float> X, RangeNode<float> Y, RangeNode<int> Size, string Timer, string FileActive, string FileInactive)
        {
            if (isOn)
            {
                // Icon Forced On
                if (Settings.Force_Icons_On)
                {
                    if (CouldHaveTimer)
                     DrawBuff(X, Y, Size, "99", FileActive);
                    else
                        DrawBuff(X, Y, Size, "", FileActive);
                }
                // Icon Not Forced On
                else
                {
                    if (gotBuff)
                        DrawBuff(X, Y, Size, Timer, FileActive);
                    else if (showFade)
                        DrawBuff(X, Y, Size, Timer, FileInactive);
                }
            }
        }

        private void Try_Draw_Buff(ToggleNode isOn, bool gotBuff, ToggleNode showFade, bool CouldHaveTimer, RangeNode<float> X, RangeNode<float> Y, RangeNode<int> Size, string Timer, string FileActive, string FileInactive, string Charges)
        {
            if (isOn)
            {
                // Icon Forced On
                if (Settings.Force_Icons_On)
                {
                    if (CouldHaveTimer)
                        DrawBuff(X, Y, Size, "99", FileActive);
                    else
                        DrawBuff(X, Y, Size, "", FileActive);
                }
                // Icon Not Forced On
                else
                {
                    if (gotBuff)
                        DrawBuff(X, Y, Size, Timer, FileActive, Charges);
                    else if (showFade)
                        DrawBuff(X, Y, Size, Timer, FileInactive);
                }
            }
        }

        private void DrawBuff(float Buff_X, float Buff_Y, int Buff_Size, string Buff_Timer, string Buff_FileName)
        {
            int Timer_Size = TimerToBuffSize(Buff_Size);

            RectangleF rect, Icon;
            DrawBuffIcon(Buff_X, Buff_Y, Buff_Size, Buff_FileName, out rect, out Icon);
            Icon = DrawBuffTimer(Buff_X, Timer_Size, Buff_Timer, rect, Icon);
        }

        private void DrawBuff(float Buff_X, float Buff_Y, int Buff_Size, string Buff_Timer, string Buff_FileName, string Buff_Charges)
        {
            int Timer_Size = TimerToBuffSize(Buff_Size);
            int Charge_Size = ChargeToBuffSize(Buff_Size);

            RectangleF rect, Icon;
            DrawBuffIcon(Buff_X, Buff_Y, Buff_Size, Buff_FileName, out rect, out Icon);
            Icon = DrawBuffTimer(Buff_X, Timer_Size, Buff_Timer, rect, Icon);
            DrawCharge(Buff_Charges, Charge_Size, Icon);
        }

        private void DrawBuffIcon(float BuffX, float BuffY, int BuffSize, string BuffFile, out RectangleF Window, out RectangleF Icon)
        {
            Window = GameController.Window.GetWindowRectangle();
            Icon = new RectangleF(Window.Width * BuffX * .01f - BuffSize / 2, Window.Height * BuffY * .01f, BuffSize, BuffSize);
            Graphics.DrawPluginImage(PluginDirectory + $"/images/{BuffFile}.png", Icon);
        }

        private static int ChargeToBuffSize(int BuffSize)
        {
            double buffTextPercent2 = BuffSize / 100.00;
            double HardTextSize2 = 28.00 * buffTextPercent2;
            int TextSize2 = (int)Math.Floor(HardTextSize2);
            return TextSize2;
        }

        private static int TimerToBuffSize(int BuffSize)
        {
            int TextSize;
            double buffTextPercent = BuffSize / 100.00;
            double HardTextSize = 32.00 * buffTextPercent;
            TextSize = (int)Math.Floor(HardTextSize);
            return TextSize;
        }

        private RectangleF DrawBuffTimer(float BuffX, int TextSize, string BuffTimerText, RectangleF rect, RectangleF TestBuffWindow)
        {
            if (BuffTimerText != "")
            {
                // Buff Timer Text
                int textYOffset = -1;
                //var BuffTimer = Graphics.DrawText(BuffTimerText, TextSize, new Vector2(rect.Width * BuffX * .01f, rect.Height * BuffY * .01f - TextSize), Color.White, SharpDX.Direct3D9.FontDrawFlags.Center);
                var BuffTimer = Graphics.DrawText(BuffTimerText, TextSize, new Vector2(rect.Width * BuffX * .01f, TestBuffWindow.Top - TextSize + textYOffset), Color.White, SharpDX.Direct3D9.FontDrawFlags.Center);
                var TimerBackground = new RectangleF(TestBuffWindow.X, TestBuffWindow.Y, TestBuffWindow.Width, -BuffTimer.Height + textYOffset + 1);
                Graphics.DrawImage("lightBackground.png", TimerBackground);
            }

            return TestBuffWindow;
        }

        private void DrawCharge(string charges, int TextSize2, RectangleF TestBuffWindow)
        {
            var ChargeText = Graphics.DrawText(charges, TextSize2, new Vector2(TestBuffWindow.Left + 3, TestBuffWindow.Top + 1), Color.White, SharpDX.Direct3D9.FontDrawFlags.Left);
            var background = new RectangleF(TestBuffWindow.X, TestBuffWindow.Y, ChargeText.Width + 6, ChargeText.Height + 2);
            Graphics.DrawImage("lightBackground.png", background);
        }

        private void OnAreaChange(AreaController area)
        {
            _isTown = area.CurrentArea.IsTown;
        }
    }
}
