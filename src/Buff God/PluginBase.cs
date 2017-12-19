using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PoeHUD.Controllers;
using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using SharpDX;
using SharpDX.Direct3D9;

namespace Buff_God
{
    public class PluginBase : BaseSettingsPlugin<PluginSettings>
    {
        private bool _isTown;

        public PluginBase()
        {
            PluginName = "Buff God";
        }

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
            var panels = GameController.Game.IngameState.IngameUi;

            if (_isTown || panels.AtlasPanel.IsVisible || panels.OpenLeftPanel.IsVisible ||
                panels.TreePanel.IsVisible) return;

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
            object[] fireGolem = {false, "", "fire_elemental_buff", "Fire Golem Active", "Fire Golem Inactive"};
            object[] iceGolem = {false, "", "ice_elemental_buff", "Ice Golem Active", "Ice Golem Inactive"};
            object[] lightningGolem =
                {false, "", "lightning_elemental_buff", "Lightning Golem Active", "Lightning Golem Inactive"};
            object[] chaosGolem = {false, "", "chaos_elemental_buff", "Chaos Golem Active", "Chaos Golem Inactive"};
            object[] stoneGolem = {false, "", "rock_golem_buff", "Stone Golem Active", "Stone Golem Inactive"};

            //Offerings
            object[] fleshOffering = {false, "", "offering_offensive", "Flesh Offering Active", "Offering Inactive"};
            object[] boneOffering = {false, "", "offering_defensive", "Bone Offering Active", "Offering Inactive"};
            object[] spiritOffering = {false, "", "offering_spirit", "Spirit Offering Active", "Offering Inactive"};

            // Vaal Skills
            object[] vaalHaste = {false, "", "vaal_aura_speed", "Vaal Haste Active", "Vaal Haste Inactive"};
            object[] vaalGrace = {false, "", "vaal_aura_dodge", "Vaal Grace Active", "Vaal Grace Inactive"};
            object[] vaalClarity =
                {false, "", "vaal_aura_no_mana_cost", "Vaal Clarity Active", "Vaal Clarity Inactive"};
            object[] vaalDiscipline =
                {false, "", "vaal_aura_energy_shield", "Vaal Discipline Active", "Vaal Discipline Inactive"};

            // Others
            object[] arcaneSurge = {false, "", "arcane_surge", "Arcane Surge Active", "Arcane Surge Inactive"};
            object[] bloodRage = { false, "", "blood_rage", "Blood Rage Active", "Blood Rage Inactive" };
            object[] elementalOverload = { false, "", "elemental_overload", "Elemental Overload Active", "Elemental Overload Inactive" };
            // Others - Conflux
            object[] confluxElemental =
            {
                false, "", "elementalist_all_damage_chills_shocks_ignites", "Elemental Conflux",
                "Elemental Conflux Inactive"
            };
            object[] confluxChill =
                {false, "", "elementalist_all_damage_chills", "Chilling Conflux", "Elemental Conflux Inactive"};
            object[] confluxShock =
                {false, "", "elementalist_all_damage_shocks", "Shocking Conflux", "Elemental Conflux Inactive"};
            object[] confluxIgnite =
                {false, "", "elementalist_all_damage_ignites", "Igniting Conflux", "Elemental Conflux Inactive"};

            //Offensive Auras
            object[] anger = {false, "", "player_aura_fire_damage", "Anger Active", "Anger Inactive"};
            object[] hatred = {false, "", "player_aura_cold_damage", "Hatred Active", "Hatred Inactive"};
            object[] wrath = {false, "", "player_aura_lightning_damage", "Wrath Active", "Wrath Inactive"};
            object[] heraldOfAsh = {false, "", "herald_of_ash", "Herald of Ash Active", "Herald of Ash Inactive"};
            object[] heraldOfIce = {false, "", "herald_of_ice", "Herald of Ice Active", "Herald of Ice Inactive"};
            object[] heraldOfThunder =
                {false, "", "herald_of_thunder", "Herald of Thunder Active", "Herald of Thunder Inactive"};
            object[] haste = {false, "", "player_aura_speed", "Haste Active", "Haste Inactive"};

            //Defensive Auras
            object[] purityOfFire =
                {false, "", "player_aura_fire_resist", "Purity of Fire Active", "Purity of Fire Inactive"};
            object[] purityOfIce =
                {false, "", "player_aura_cold_resist", "Purity of Ice Active", "Purity of Ice Inactive"};
            object[] purityOfLightning =
            {
                false, "", "player_aura_lightning_resist", "Purity of Lightning Active", "Purity of Lightning Inactive"
            };
            object[] purityOfElements =
                {false, "", "player_aura_resists", "Purity of Elements Active", "Purity of Elements Inactive"};
            object[] vitality = {false, "", "player_aura_life_regen", "Vitality Active", "Vitality Inactive"};
            object[] discipline = {false, "", "player_aura_energy_shield", "Discipline Active", "Discipline Inactive"};
            object[] determination =
                {false, "", "player_aura_armour", "Determination Active", "Determination Inactive"};
            object[] grace = {false, "", "player_aura_evasion", "Grace Active", "Grace Inactive"};
            object[] clarity = {false, "", "player_aura_mana_regen", "Clarity Active", "Clarity Inactive"};

            // Curses
            object[] cursePoachersMark =
                {false, "", "curse_poachers_mark", "Poacher's Mark Active", "Poacher's Mark Inactive"};
            object[] curseFrostbite = {false, "", "curse_cold_weakness", "Frostbite Active", "Frostbite Inactive"};
            object[] curseVulnerability =
                {false, "", "curse_vulnerability", "Vulnerability Active", "Vulnerability Inactive"};
            object[] curseWarlordsMark =
                {false, "", "curse_warlords_mark", "Warlord's Mark Active", "Warlord's Mark Inactive"};
            object[] curseFlammability =
                {false, "", "curse_fire_weakness", "Flammability Active", "Flammability Inactive"};
            object[] curseAssassinsMark =
                {false, "", "curse_assassins_mark", "Assassin's Mark Active", "Assassin's Mark Inactive"};
            object[] curseElementalWeakness =
                {false, "", "curse_elemental_weakness", "Elemental Weakness Active", "Elemental Weakness Inactive"};
            object[] curseConductivity =
                {false, "", "curse_lightning_weakness", "Conductivity Active", "Conductivity Inactive"};
            object[] curseEnfeeble = {false, "", "curse_enfeeble", "Enfeeble Active", "Enfeeble Inactive"};
            object[] cursePunishment = {false, "", "curse_newpunishment", "Punishment Active", "Punishment Inactive"};
            object[] curseProjectileWeakness =
                {false, "", "curse_projectile_weakness", "Projectile Weakness Active", "Projectile Weakness Inactive"};
            object[] curseTemporalChains =
                {false, "", "curse_temporal_chains", "Temporal Chains Active", "Temporal Chains Inactive"};


            /* Buff Array[]
             * 
             * Enable Buff,
             * Text over Icon,
             * Buff Name,
             * Active Icon,
             * Inactive Icon
             * charges
            */
            // charges
            object[] powerCharges = {false, "", "power_charge", "Power charges Active", "Power charges Inactive", ""};
            object[] frenzyCharges =
                {false, "", "frenzy_charge", "Frenzy charges Active", "Frenzy charges Inactive", ""};
            object[] enduranceCharges =
                {false, "", "endurance_charge", "Endurance charges Active", "Endurance charges Inactive", ""};
            object[] bladeVortexStacks =
                {false, "", "blade_vortex_counter", "Blade Vortex Active", "Blade Vortex Inactive", ""};
            object[] reaveStacks = {false, "", "reave_counter", "Reave Active", "Reave Inactive", ""};

            // Leeching
            object[] leechingLife = {false, "", "life_leech", "Life Leech Active", "Leech Inactive"};
            object[] leechingMana = {false, "", "mana_leech", "Mana Leech Active", "Leech Inactive"};
            var leechingLifeBuffDurations = new List<float>();
            var leechingManaBuffDurations = new List<float>();


            // Loop through all buffs on me
            foreach (var buff in GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Life>().Buffs)
            {
                var isInfinity = float.IsInfinity(buff.Timer);
                var buffText = isInfinity ? "" : Math.Ceiling(buff.Timer).ToString(CultureInfo.InvariantCulture);
                var thisBuff = buff.Name.ToLower();
                var charges = buff.Charges < 1 ? "" : buff.Charges.ToString();

                #region Others

                if (thisBuff.Equals((string) arcaneSurge[2]))
                {
                    arcaneSurge[0] = true;
                    arcaneSurge[1] = buffText;
                }
                if (thisBuff.Equals((string)bloodRage[2]))
                {
                    bloodRage[0] = true;
                    bloodRage[1] = buffText;
                }
                if (thisBuff.Equals((string)elementalOverload[2]))
                {
                    elementalOverload[0] = true;
                    elementalOverload[1] = buffText;
                }
                if (thisBuff.Equals((string) confluxElemental[2]))
                {
                    confluxElemental[0] = true;
                    confluxElemental[1] = buffText;
                }
                if (thisBuff.Equals((string) confluxChill[2]))
                {
                    confluxChill[0] = true;
                    confluxChill[1] = buffText;
                }
                if (thisBuff.Equals((string) confluxShock[2]))
                {
                    confluxShock[0] = true;
                    confluxShock[1] = buffText;
                }
                if (thisBuff.Equals((string) confluxIgnite[2]))
                {
                    confluxIgnite[0] = true;
                    confluxIgnite[1] = buffText;
                }

                #endregion

                #region Vaal Skills

                else if (thisBuff.Equals((string) vaalHaste[2]))
                {
                    vaalHaste[0] = true;
                    vaalHaste[1] = buffText;
                }
                else if (thisBuff.Equals((string) vaalGrace[2]))
                {
                    vaalGrace[0] = true;
                    vaalGrace[1] = buffText;
                }
                else if (thisBuff.Equals((string) vaalClarity[2]))
                {
                    vaalClarity[0] = true;
                    vaalClarity[1] = buffText;
                }
                else if (thisBuff.Equals((string) vaalDiscipline[2]))
                {
                    vaalDiscipline[0] = true;
                    vaalDiscipline[1] = buffText;
                }

                #endregion

                #region Offerings

                else if (thisBuff.Equals((string) fleshOffering[2]))
                {
                    fleshOffering[0] = true;
                    fleshOffering[1] = buffText;
                }
                else if (thisBuff.Equals((string) boneOffering[2]))
                {
                    boneOffering[0] = true;
                    boneOffering[1] = buffText;
                }
                else if (thisBuff.Equals((string) spiritOffering[2]))
                {
                    spiritOffering[0] = true;
                    spiritOffering[1] = buffText;
                }

                #endregion

                #region Golems

                else if (thisBuff.Equals((string) fireGolem[2]))
                {
                    fireGolem[0] = true;
                    fireGolem[1] = buffText;
                }
                else if (thisBuff.Equals((string) iceGolem[2]))
                {
                    iceGolem[0] = true;
                    iceGolem[1] = buffText;
                }
                else if (thisBuff.Equals((string) lightningGolem[2]))
                {
                    lightningGolem[0] = true;
                    lightningGolem[1] = buffText;
                }
                else if (thisBuff.Equals((string) chaosGolem[2]))
                {
                    chaosGolem[0] = true;
                    chaosGolem[1] = buffText;
                }
                else if (thisBuff.Equals((string) stoneGolem[2]))
                {
                    stoneGolem[0] = true;
                    stoneGolem[1] = buffText;
                }

                #endregion

                #region Offensive Auras

                else if (thisBuff.Equals((string) anger[2]))
                {
                    anger[0] = true;
                    anger[1] = buffText;
                }
                else if (thisBuff.Equals((string) hatred[2]))
                {
                    hatred[0] = true;
                    hatred[1] = buffText;
                }
                else if (thisBuff.Equals((string) wrath[2]))
                {
                    wrath[0] = true;
                    wrath[1] = buffText;
                }
                else if (thisBuff.Equals((string) heraldOfAsh[2]))
                {
                    heraldOfAsh[0] = true;
                    heraldOfAsh[1] = buffText;
                }
                else if (thisBuff.Equals((string) heraldOfIce[2]))
                {
                    heraldOfIce[0] = true;
                    heraldOfIce[1] = buffText;
                }
                else if (thisBuff.Equals((string) heraldOfThunder[2]))
                {
                    heraldOfThunder[0] = true;
                    heraldOfThunder[1] = buffText;
                }
                else if (thisBuff.Equals((string) haste[2]))
                {
                    haste[0] = true;
                    haste[1] = buffText;
                }

                #endregion

                #region Defensive Auras

                else if (thisBuff.Equals((string) purityOfFire[2]))
                {
                    purityOfFire[0] = true;
                    purityOfFire[1] = buffText;
                }
                else if (thisBuff.Equals((string) purityOfIce[2]))
                {
                    purityOfIce[0] = true;
                    purityOfIce[1] = buffText;
                }
                else if (thisBuff.Equals((string) purityOfLightning[2]))
                {
                    purityOfLightning[0] = true;
                    purityOfLightning[1] = buffText;
                }
                else if (thisBuff.Equals((string) purityOfElements[2]))
                {
                    purityOfElements[0] = true;
                    purityOfElements[1] = buffText;
                }
                else if (thisBuff.Equals((string) vitality[2]))
                {
                    vitality[0] = true;
                    vitality[1] = buffText;
                }
                else if (thisBuff.Equals((string) discipline[2]))
                {
                    discipline[0] = true;
                    discipline[1] = buffText;
                }
                else if (thisBuff.Equals((string) determination[2]))
                {
                    determination[0] = true;
                    determination[1] = buffText;
                }
                else if (thisBuff.Equals((string) grace[2]))
                {
                    grace[0] = true;
                    grace[1] = buffText;
                }
                else if (thisBuff.Equals((string) clarity[2]))
                {
                    clarity[0] = true;
                    clarity[1] = buffText;
                }

                #endregion

                #region charges

                else if (thisBuff.Equals((string) powerCharges[2]))
                {
                    powerCharges[0] = true;
                    powerCharges[1] = buffText;
                    powerCharges[5] = charges;
                }
                else if (thisBuff.Equals((string) frenzyCharges[2]))
                {
                    frenzyCharges[0] = true;
                    frenzyCharges[1] = buffText;
                    frenzyCharges[5] = charges;
                }
                else if (thisBuff.Equals((string) enduranceCharges[2]))
                {
                    enduranceCharges[0] = true;
                    enduranceCharges[1] = buffText;
                    enduranceCharges[5] = charges;
                }
                else if (thisBuff.Equals((string) bladeVortexStacks[2]))
                {
                    bladeVortexStacks[0] = true;
                    bladeVortexStacks[1] = buffText;
                    bladeVortexStacks[5] = charges;
                }
                else if (thisBuff.Equals((string) reaveStacks[2]))
                {
                    reaveStacks[0] = true;
                    reaveStacks[1] = buffText;
                    reaveStacks[5] = charges;
                }

                #endregion

                #region Curses

                else if (thisBuff.Equals((string) cursePoachersMark[2]))
                {
                    cursePoachersMark[0] = true;
                    cursePoachersMark[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseFrostbite[2]))
                {
                    curseFrostbite[0] = true;
                    curseFrostbite[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseVulnerability[2]))
                {
                    curseVulnerability[0] = true;
                    curseVulnerability[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseWarlordsMark[2]))
                {
                    curseWarlordsMark[0] = true;
                    curseWarlordsMark[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseFlammability[2]))
                {
                    curseFlammability[0] = true;
                    curseFlammability[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseAssassinsMark[2]))
                {
                    curseAssassinsMark[0] = true;
                    curseAssassinsMark[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseElementalWeakness[2]))
                {
                    curseElementalWeakness[0] = true;
                    curseElementalWeakness[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseConductivity[2]))
                {
                    curseConductivity[0] = true;
                    curseConductivity[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseEnfeeble[2]))
                {
                    curseEnfeeble[0] = true;
                    curseEnfeeble[1] = buffText;
                }
                else if (thisBuff.Equals((string) cursePunishment[2]))
                {
                    cursePunishment[0] = true;
                    cursePunishment[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseProjectileWeakness[2]))
                {
                    curseProjectileWeakness[0] = true;
                    curseProjectileWeakness[1] = buffText;
                }
                else if (thisBuff.Equals((string) curseTemporalChains[2]))
                {
                    curseTemporalChains[0] = true;
                    curseTemporalChains[1] = buffText;
                }

                #endregion

                #region Leeching

                else if (thisBuff.Equals((string) leechingLife[2]))
                {
                    leechingLife[0] = true;
                    leechingLifeBuffDurations.Add(buff.Timer);
                }
                else if (thisBuff.Equals((string) leechingMana[2]))
                {
                    leechingMana[0] = true;
                    leechingManaBuffDurations.Add(buff.Timer);
                }

                #endregion
            }

            #region Others

            if (Settings.Others)
            {
                #region Arcane Surge

                Try_Draw_Buff(Settings.ArcaneSurge, (bool) arcaneSurge[0], Settings.ArcaneSurgeShowInactive, true,
                    Settings.ArcaneSurgeX,
                    Settings.ArcaneSurgeY,
                    Settings.ArcaneSurgeSize,
                    (string) arcaneSurge[1], (string) arcaneSurge[3], (string) arcaneSurge[4]);

                #endregion

                #region Blood_Rage

                Try_Draw_Buff(Settings.BloodRage, (bool)bloodRage[0], Settings.BloodRageShowInactive, true,
                    Settings.BloodRageX,
                    Settings.BloodRageY,
                    Settings.BloodRageSize,
                    (string)bloodRage[1], (string)bloodRage[3], (string)bloodRage[4]);

                #endregion

                #region elemental Overloard

                Try_Draw_Buff(Settings.ElementalOverload, (bool)elementalOverload[0], Settings.ElementalOverloadShowInactive, true,
                    Settings.ElementalOverloadX,
                    Settings.ElementalOverloadY,
                    Settings.ElementalOverloadSize,
                    (string)elementalOverload[1], (string)elementalOverload[3], (string)elementalOverload[4]);

                #endregion

                #region Elemental_Conflux

                if (Settings.ElementalConflux)
                    if (Settings.ForceIconsOn)
                    {
                        DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                            Settings.ElementalConfluxSize, "99", (string) confluxElemental[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool) confluxElemental[0])
                            DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                                Settings.ElementalConfluxSize, (string) confluxElemental[1],
                                (string) confluxElemental[3]);
                        else if ((bool) confluxChill[0])
                            DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                                Settings.ElementalConfluxSize, (string) confluxChill[1], (string) confluxChill[3]);
                        else if ((bool) confluxShock[0])
                            DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                                Settings.ElementalConfluxSize, (string) confluxShock[1], (string) confluxShock[3]);
                        else if ((bool) confluxIgnite[0])
                            DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                                Settings.ElementalConfluxSize, (string) confluxIgnite[1],
                                (string) confluxIgnite[3]);
                        else if (Settings.ElementalConfluxShowInactive)
                            DrawBuff(Settings.ElementalConfluxX, Settings.ElementalConfluxY,
                                Settings.ElementalConfluxSize, (string) confluxElemental[1],
                                (string) confluxElemental[4]);
                    }

                #endregion
            }

            #endregion

            #region Vaal Skills

            if (Settings.VaalSkills)
            {
                #region Vaal_Haste

                Try_Draw_Buff(Settings.VaalHaste, (bool) vaalHaste[0], Settings.VaalHasteShowInactive, true,
                    Settings.VaalHasteX,
                    Settings.VaalHasteY,
                    Settings.VaalHasteSize,
                    (string) vaalHaste[1], (string) vaalHaste[3], (string) vaalHaste[4]);

                #endregion

                #region Vaal_Grace

                Try_Draw_Buff(Settings.VaalGrace, (bool) vaalGrace[0], Settings.VaalGraceShowInactive, true,
                    Settings.VaalGraceX,
                    Settings.VaalGraceY,
                    Settings.VaalGraceSize,
                    (string) vaalGrace[1], (string) vaalGrace[3], (string) vaalGrace[4]);

                #endregion

                #region Vaal_Clarity

                Try_Draw_Buff(Settings.VaalClarity, (bool) vaalClarity[0], Settings.VaalClarityShowInactive, true,
                    Settings.VaalClarityX,
                    Settings.VaalClarityY,
                    Settings.VaalClaritySize,
                    (string) vaalClarity[1], (string) vaalClarity[3], (string) vaalClarity[4]);

                #endregion

                #region Vaal_Discipline

                Try_Draw_Buff(Settings.VaalDiscipline, (bool) vaalDiscipline[0],
                    Settings.VaalDisciplineShowInactive, true,
                    Settings.VaalDisciplineX,
                    Settings.VaalDisciplineY,
                    Settings.VaalDisciplineSize,
                    (string) vaalDiscipline[1], (string) vaalDiscipline[3], (string) vaalDiscipline[4]);

                #endregion
            }

            #endregion

            #region Offerings

            if (Settings.Offerings)
            {
                #region Spirit Offerings

                if (Settings.OfferingEffect)
                    if (Settings.ForceIconsOn)
                    {
                        DrawBuff(Settings.OfferingEffectX, Settings.OfferingEffectY, Settings.OfferingEffectSize,
                            "", (string) fleshOffering[3]);
                    }
                    // Icon Not Forced On
                    else
                    {
                        if ((bool) fleshOffering[0])
                            DrawBuff(Settings.OfferingEffectX, Settings.OfferingEffectY,
                                Settings.OfferingEffectSize, (string) fleshOffering[1], (string) fleshOffering[3]);
                        else if ((bool) boneOffering[0])
                            DrawBuff(Settings.OfferingEffectX, Settings.OfferingEffectY,
                                Settings.OfferingEffectSize, (string) boneOffering[1], (string) boneOffering[3]);
                        else if ((bool) spiritOffering[0])
                            DrawBuff(Settings.OfferingEffectX, Settings.OfferingEffectY,
                                Settings.OfferingEffectSize, (string) spiritOffering[1],
                                (string) spiritOffering[3]);
                        else if (Settings.OfferingEffectShowInactive)
                            DrawBuff(Settings.OfferingEffectX, Settings.OfferingEffectY,
                                Settings.OfferingEffectSize, (string) fleshOffering[1], (string) fleshOffering[4]);
                    }

                #endregion
            }

            #endregion

            #region Golems

            if (Settings.Golems)
            {
                #region Fire Golem

                Try_Draw_Buff(Settings.FireGolem, (bool) fireGolem[0], Settings.FireGolemShowInactive, false,
                    Settings.FireGolemX,
                    Settings.FireGolemY,
                    Settings.FireGolemSize,
                    (string) fireGolem[1], (string) fireGolem[3], (string) fireGolem[4]);

                #endregion

                #region Ice Golem

                Try_Draw_Buff(Settings.IceGolem, (bool) iceGolem[0], Settings.IceGolemShowInactive, false,
                    Settings.IceGolemX,
                    Settings.IceGolemY,
                    Settings.IceGolemSize,
                    (string) iceGolem[1], (string) iceGolem[3], (string) iceGolem[4]);

                #endregion

                #region Lightning Golem

                Try_Draw_Buff(Settings.LightningGolem, (bool) lightningGolem[0],
                    Settings.LightningGolemShowInactive, false,
                    Settings.LightningGolemX,
                    Settings.LightningGolemY,
                    Settings.LightningGolemSize,
                    (string) lightningGolem[1], (string) lightningGolem[3], (string) lightningGolem[4]);

                #endregion

                #region Chaos Golem

                Try_Draw_Buff(Settings.ChaosGolem, (bool) chaosGolem[0], Settings.ChaosGolemShowInactive, false,
                    Settings.ChaosGolemX,
                    Settings.ChaosGolemY,
                    Settings.ChaosGolemSize,
                    (string) chaosGolem[1], (string) chaosGolem[3], (string) chaosGolem[4]);

                #endregion

                #region Stone Golem

                Try_Draw_Buff(Settings.StoneGolem, (bool) stoneGolem[0], Settings.StoneGolemShowInactive, false,
                    Settings.StoneGolemX,
                    Settings.StoneGolemY,
                    Settings.StoneGolemSize,
                    (string) stoneGolem[1], (string) stoneGolem[3], (string) stoneGolem[4]);

                #endregion
            }

            #endregion

            #region Offensive Auras

            if (Settings.OffensiveAura)
            {
                #region Anger

                Try_Draw_Buff(Settings.Anger, (bool) anger[0], Settings.AngerShowInactive, false,
                    Settings.AngerX,
                    Settings.AngerY,
                    Settings.AngerSize,
                    (string) anger[1], (string) anger[3], (string) anger[4]);

                #endregion

                #region Hatred

                Try_Draw_Buff(Settings.Hatred, (bool) hatred[0], Settings.HatredShowInactive, false,
                    Settings.HatredX,
                    Settings.HatredY,
                    Settings.HatredSize,
                    (string) hatred[1], (string) hatred[3], (string) hatred[4]);

                #endregion

                #region Wrath

                Try_Draw_Buff(Settings.Wrath, (bool) wrath[0], Settings.WrathShowInactive, false,
                    Settings.WrathX,
                    Settings.WrathY,
                    Settings.WrathSize,
                    (string) wrath[1], (string) wrath[3], (string) wrath[4]);

                #endregion

                #region Herald_of_Ash

                Try_Draw_Buff(Settings.HeraldOfAsh, (bool) heraldOfAsh[0], Settings.HeraldOfAshShowInactive,
                    false,
                    Settings.HeraldOfAshX,
                    Settings.HeraldOfAshY,
                    Settings.HeraldOfAshSize,
                    (string) heraldOfAsh[1], (string) heraldOfAsh[3], (string) heraldOfAsh[4]);

                #endregion

                #region Herald_of_Ice

                Try_Draw_Buff(Settings.HeraldOfIce, (bool) heraldOfIce[0], Settings.HeraldOfIceShowInactive,
                    false,
                    Settings.HeraldOfIceX,
                    Settings.HeraldOfIceY,
                    Settings.HeraldOfIceSize,
                    (string) heraldOfIce[1], (string) heraldOfIce[3], (string) heraldOfIce[4]);

                #endregion

                #region Herald_of_Thunder

                Try_Draw_Buff(Settings.HeraldOfThunder, (bool) heraldOfThunder[0],
                    Settings.HeraldOfThunderShowInactive, false,
                    Settings.HeraldOfThunderX,
                    Settings.HeraldOfThunderY,
                    Settings.HeraldOfThunderSize,
                    (string) heraldOfThunder[1], (string) heraldOfThunder[3], (string) heraldOfThunder[4]);

                #endregion

                #region Haste

                Try_Draw_Buff(Settings.Haste, (bool) haste[0], Settings.HasteShowInactive, false,
                    Settings.HasteX,
                    Settings.HasteY,
                    Settings.HasteSize,
                    (string) haste[1], (string) haste[3], (string) haste[4]);

                #endregion
            }

            #endregion

            #region Defensive Auras

            if (Settings.DefenseiveAura)
            {
                #region Purity_of_Fire

                Try_Draw_Buff(Settings.PurityOfFire, (bool) purityOfFire[0], Settings.PurityOfFireShowInactive,
                    false,
                    Settings.PurityOfFireX,
                    Settings.PurityOfFireY,
                    Settings.PurityOfFireSize,
                    (string) purityOfFire[1], (string) purityOfFire[3], (string) purityOfFire[4]);

                #endregion

                #region Purity_of_Ice

                Try_Draw_Buff(Settings.PurityOfIce, (bool) purityOfIce[0], Settings.PurityOfIceShowInactive,
                    false,
                    Settings.PurityOfIceX,
                    Settings.PurityOfIceY,
                    Settings.PurityOfIceSize,
                    (string) purityOfIce[1], (string) purityOfIce[3], (string) purityOfIce[4]);

                #endregion

                #region Purity_of_Lightning

                Try_Draw_Buff(Settings.PurityOfLightning, (bool) purityOfLightning[0],
                    Settings.PurityOfLightningShowInactive, false,
                    Settings.PurityOfLightningX,
                    Settings.PurityOfLightningY,
                    Settings.PurityOfLightningSize,
                    (string) purityOfLightning[1], (string) purityOfLightning[3], (string) purityOfLightning[4]);

                #endregion

                #region Purity_of_Elements

                Try_Draw_Buff(Settings.PurityOfElements, (bool) purityOfElements[0],
                    Settings.PurityOfElementsShowInactive, false,
                    Settings.PurityOfElementsX,
                    Settings.PurityOfElementsY,
                    Settings.PurityOfElementsSize,
                    (string) purityOfElements[1], (string) purityOfElements[3], (string) purityOfElements[4]);

                #endregion

                #region Vitality

                Try_Draw_Buff(Settings.Vitality, (bool) vitality[0], Settings.VitalityShowInactive, false,
                    Settings.VitalityX,
                    Settings.VitalityY,
                    Settings.VitalitySize,
                    (string) vitality[1], (string) vitality[3], (string) vitality[4]);

                #endregion

                #region Discipline

                Try_Draw_Buff(Settings.Discipline, (bool) discipline[0], Settings.DisciplineShowInactive, false,
                    Settings.DisciplineX,
                    Settings.DisciplineY,
                    Settings.DisciplineSize,
                    (string) discipline[1], (string) discipline[3], (string) discipline[4]);

                #endregion

                #region Determination

                Try_Draw_Buff(Settings.Determination, (bool) determination[0], Settings.DeterminationShowInactive,
                    false,
                    Settings.DeterminationX,
                    Settings.DeterminationY,
                    Settings.DeterminationSize,
                    (string) determination[1], (string) determination[3], (string) determination[4]);

                #endregion

                #region Grace

                Try_Draw_Buff(Settings.Grace, (bool) grace[0], Settings.GraceShowInactive, false,
                    Settings.GraceX,
                    Settings.GraceY,
                    Settings.GraceSize,
                    (string) grace[1], (string) grace[3], (string) grace[4]);

                #endregion

                #region Clarity

                Try_Draw_Buff(Settings.Clarity, (bool) clarity[0], Settings.ClarityShowInactive, false,
                    Settings.ClarityX,
                    Settings.ClarityY,
                    Settings.ClaritySize,
                    (string) clarity[1], (string) clarity[3], (string) clarity[4]);

                #endregion
            }

            #endregion

            #region charges

            if (Settings.Others)
            {
                #region Power_Charges

                Try_Draw_Buff(Settings.PowerCharges, (bool) powerCharges[0], Settings.PowerChargesShowInactive,
                    true,
                    Settings.PowerChargesX,
                    Settings.PowerChargesY,
                    Settings.PowerChargesSize,
                    (string) powerCharges[1], (string) powerCharges[3], (string) powerCharges[4],
                    (string) powerCharges[5]);

                #endregion

                #region Frenzy_Charges

                Try_Draw_Buff(Settings.FrenzyCharges, (bool) frenzyCharges[0], Settings.FrenzyChargesShowInactive,
                    true,
                    Settings.FrenzyChargesX,
                    Settings.FrenzyChargesY,
                    Settings.FrenzyChargesSize,
                    (string) frenzyCharges[1], (string) frenzyCharges[3], (string) frenzyCharges[4],
                    (string) frenzyCharges[5]);

                #endregion

                #region Endurance_Charges

                Try_Draw_Buff(Settings.EnduranceCharges, (bool) enduranceCharges[0],
                    Settings.EnduranceChargesShowInactive, true,
                    Settings.EnduranceChargesX,
                    Settings.EnduranceChargesY,
                    Settings.EnduranceChargesSize,
                    (string) enduranceCharges[1], (string) enduranceCharges[3], (string) enduranceCharges[4],
                    (string) enduranceCharges[5]);

                #endregion

                #region Blade_Vortex_Stacks

                Try_Draw_Buff(Settings.BladeVortexStacks, (bool) bladeVortexStacks[0],
                    Settings.BladeVortexStacksShowInactive, true,
                    Settings.BladeVortexStacksX,
                    Settings.BladeVortexStacksY,
                    Settings.BladeVortexStacksSize,
                    (string) bladeVortexStacks[1], (string) bladeVortexStacks[3], (string) bladeVortexStacks[4],
                    (string) bladeVortexStacks[5]);

                #endregion

                #region Reave_Stacks

                Try_Draw_Buff(Settings.ReaveStacks, (bool) reaveStacks[0], Settings.ReaveStacksShowInactive, true,
                    Settings.ReaveStacksX,
                    Settings.ReaveStacksY,
                    Settings.ReaveStacksSize,
                    (string) reaveStacks[1], (string) reaveStacks[3], (string) reaveStacks[4],
                    (string) reaveStacks[5]);

                #endregion
            }

            #endregion

            #region Curses

            if (Settings.Curses)
            {
                #region Curse_Poachers_Mark

                Try_Draw_Buff(Settings.CursePoachersMark, (bool) cursePoachersMark[0],
                    Settings.CursePoachersMarkShowInactive, true,
                    Settings.CursePoachersMarkX,
                    Settings.CursePoachersMarkY,
                    Settings.CursePoachersMarkSize,
                    (string) cursePoachersMark[1], (string) cursePoachersMark[3], (string) cursePoachersMark[4]);

                #endregion

                #region Curse_Frostbite

                Try_Draw_Buff(Settings.CurseFrostbite, (bool) curseFrostbite[0],
                    Settings.CurseFrostbiteShowInactive, true,
                    Settings.CurseFrostbiteX,
                    Settings.CurseFrostbiteY,
                    Settings.CurseFrostbiteSize,
                    (string) curseFrostbite[1], (string) curseFrostbite[3], (string) curseFrostbite[4]);

                #endregion

                #region Curse_Vulnerability

                Try_Draw_Buff(Settings.CurseVulnerability, (bool) curseVulnerability[0],
                    Settings.CurseVulnerabilityShowInactive, true,
                    Settings.CurseVulnerabilityX,
                    Settings.CurseVulnerabilityY,
                    Settings.CurseVulnerabilitySize,
                    (string) curseVulnerability[1], (string) curseVulnerability[3], (string) curseVulnerability[4]);

                #endregion

                #region Curse_Warlords_Mark

                Try_Draw_Buff(Settings.CurseWarlordsMark, (bool) curseWarlordsMark[0],
                    Settings.CurseWarlordsMarkShowInactive, true,
                    Settings.CurseWarlordsMarkX,
                    Settings.CurseWarlordsMarkY,
                    Settings.CurseWarlordsMarkSize,
                    (string) curseWarlordsMark[1], (string) curseWarlordsMark[3], (string) curseWarlordsMark[4]);

                #endregion

                #region Curse_Flammability

                Try_Draw_Buff(Settings.CurseFlammability, (bool) curseFlammability[0],
                    Settings.CurseFlammabilityShowInactive, true,
                    Settings.CurseFlammabilityX,
                    Settings.CurseFlammabilityY,
                    Settings.CurseFlammabilitySize,
                    (string) curseFlammability[1], (string) curseFlammability[3], (string) curseFlammability[4]);

                #endregion

                #region Curse_Assassins_Mark

                Try_Draw_Buff(Settings.CurseAssassinsMark, (bool) curseAssassinsMark[0],
                    Settings.CurseAssassinsMarkShowInactive, true,
                    Settings.CurseAssassinsMarkX,
                    Settings.CurseAssassinsMarkY,
                    Settings.CurseAssassinsMarkSize,
                    (string) curseAssassinsMark[1], (string) curseAssassinsMark[3],
                    (string) curseAssassinsMark[4]);

                #endregion

                #region Curse_Elemental_Weakness

                Try_Draw_Buff(Settings.CurseElementalWeakness, (bool) curseElementalWeakness[0],
                    Settings.CurseElementalWeaknessShowInactive, true,
                    Settings.CurseElementalWeaknessX,
                    Settings.CurseElementalWeaknessY,
                    Settings.CurseElementalWeaknessSize,
                    (string) curseElementalWeakness[1], (string) curseElementalWeakness[3],
                    (string) curseElementalWeakness[4]);

                #endregion

                #region Curse_Conductivity

                Try_Draw_Buff(Settings.CurseConductivity, (bool) curseConductivity[0],
                    Settings.CurseConductivityShowInactive, true,
                    Settings.CurseConductivityX,
                    Settings.CurseConductivityY,
                    Settings.CurseConductivitySize,
                    (string) curseConductivity[1], (string) curseConductivity[3], (string) curseConductivity[4]);

                #endregion

                #region Curse_Enfeeble

                Try_Draw_Buff(Settings.CurseEnfeeble, (bool) curseEnfeeble[0], Settings.CurseEnfeebleShowInactive,
                    true,
                    Settings.CurseEnfeebleX,
                    Settings.CurseEnfeebleY,
                    Settings.CurseEnfeebleSize,
                    (string) curseEnfeeble[1], (string) curseEnfeeble[3], (string) curseEnfeeble[4]);

                #endregion

                #region Curse_Punishment

                Try_Draw_Buff(Settings.CursePunishment, (bool) cursePunishment[0],
                    Settings.CursePunishmentShowInactive, true,
                    Settings.CursePunishmentX,
                    Settings.CursePunishmentY,
                    Settings.CursePunishmentSize,
                    (string) cursePunishment[1], (string) cursePunishment[3], (string) cursePunishment[4]);

                #endregion

                #region Curse_Projectile_Weakness

                Try_Draw_Buff(Settings.CurseProjectileWeakness, (bool) curseProjectileWeakness[0],
                    Settings.CurseProjectileWeaknessShowInactive, true,
                    Settings.CurseProjectileWeaknessX,
                    Settings.CurseProjectileWeaknessY,
                    Settings.CurseProjectileWeaknessSize,
                    (string) curseProjectileWeakness[1], (string) curseProjectileWeakness[3],
                    (string) curseProjectileWeakness[4]);

                #endregion

                #region Curse_Temporal_Chains

                Try_Draw_Buff(Settings.CurseTemporalChains, (bool) curseTemporalChains[0],
                    Settings.CurseTemporalChainsShowInactive, true,
                    Settings.CurseTemporalChainsX,
                    Settings.CurseTemporalChainsY,
                    Settings.CurseTemporalChainsSize,
                    (string) curseTemporalChains[1], (string) curseTemporalChains[3],
                    (string) curseTemporalChains[4]);

                #endregion
            }

            #endregion

            #region Leeching

            if (Settings.Leeching)
            {
                #region Leeching_Life

                if ((bool) leechingLife[0])
                {
                    // Sort life leech buff timers Highest -> Lowest
                    leechingLifeBuffDurations.Sort();
                    leechingLifeBuffDurations.Reverse();
                    leechingLife[1] = Math.Ceiling(leechingLifeBuffDurations.First()).ToString(CultureInfo.InvariantCulture);
                }

                Try_Draw_Buff(Settings.LeechingLife, (bool) leechingLife[0], Settings.LeechingLifeShowInactive,
                    true,
                    Settings.LeechingLifeX,
                    Settings.LeechingLifeY,
                    Settings.LeechingLifeSize,
                    (string) leechingLife[1], (string) leechingLife[3], (string) leechingLife[4],
                    leechingLifeBuffDurations.Count.ToString());

                #endregion

                #region Leeching_Mana

                if ((bool) leechingMana[0])
                {
                    // Sort life leech buff timers Highest -> Lowest
                    leechingManaBuffDurations.Sort();
                    leechingManaBuffDurations.Reverse();
                    leechingMana[1] = Math.Ceiling(leechingManaBuffDurations.First()).ToString(CultureInfo.InvariantCulture);
                }

                Try_Draw_Buff(Settings.LeechingMana, (bool) leechingMana[0], Settings.LeechingManaShowInactive,
                    true,
                    Settings.LeechingManaX,
                    Settings.LeechingManaY,
                    Settings.LeechingManaSize,
                    (string) leechingMana[1], (string) leechingMana[3], (string) leechingMana[4],
                    leechingManaBuffDurations.Count.ToString());

                #endregion
            }

            #endregion
        }

        private void Try_Draw_Buff(ToggleNode isOn, bool gotBuff, ToggleNode showFade, bool couldHaveTimer,
            RangeNode<float> xRangeNode, RangeNode<float> yRangeNode, RangeNode<int> size, string timer,
            string fileActive,
            string fileInactive)
        {
            if (!isOn) return;
            if (Settings.ForceIconsOn)
            {
                DrawBuff(xRangeNode, yRangeNode, size, couldHaveTimer ? "99" : "", fileActive);
            }
            // Icon Not Forced On
            else
            {
                if (gotBuff)
                    DrawBuff(xRangeNode, yRangeNode, size, timer, fileActive);
                else if (showFade)
                    DrawBuff(xRangeNode, yRangeNode, size, timer, fileInactive);
            }
        }

        private void Try_Draw_Buff(ToggleNode isOn, bool gotBuff, ToggleNode showFade, bool couldHaveTimer,
            RangeNode<float> xRangeNode, RangeNode<float> yRangeNode, RangeNode<int> size, string timer,
            string fileActive,
            string fileInactive, string charges)
        {
            if (!isOn) return;
            if (Settings.ForceIconsOn)
            {
                DrawBuff(xRangeNode, yRangeNode, size, couldHaveTimer ? "99" : "", fileActive);
            }
            // Icon Not Forced On
            else
            {
                if (gotBuff)
                    DrawBuff(xRangeNode, yRangeNode, size, timer, fileActive, charges);
                else if (showFade)
                    DrawBuff(xRangeNode, yRangeNode, size, timer, fileInactive);
            }
        }

        private void DrawBuff(float buffX, float buffY, int buffSize, string buffTimer, string buffFileName)
        {
            var timerSize = TimerToBuffSize(buffSize);

            DrawBuffIcon(buffX, buffY, buffSize, buffFileName, out var rect, out var icon);
            DrawBuffTimer(buffX, timerSize, buffTimer, rect, icon);
        }

        private void DrawBuff(float buffX, float buffY, int buffSize, string buffTimer, string buffFileName,
            string buffCharges)
        {
            var timerSize = TimerToBuffSize(buffSize);
            var chargeSize = ChargeToBuffSize(buffSize);

            RectangleF rect, icon;
            DrawBuffIcon(buffX, buffY, buffSize, buffFileName, out rect, out icon);
            icon = DrawBuffTimer(buffX, timerSize, buffTimer, rect, icon);
            DrawCharge(buffCharges, chargeSize, icon);
        }

        private void DrawBuffIcon(float buffX, float buffY, int buffSize, string buffFile, out RectangleF window,
            out RectangleF icon)
        {
            window = GameController.Window.GetWindowRectangle();
            icon = new RectangleF(window.Width * buffX * .01f - buffSize / 2, window.Height * buffY * .01f, buffSize,
                buffSize);
            Graphics.DrawPluginImage(PluginDirectory + $"/images/{buffFile}.png", icon);
        }

        private static int ChargeToBuffSize(int buffSize)
        {
            var buffTextPercent2 = buffSize / 100.00;
            var hardTextSize2 = 28.00 * buffTextPercent2;
            var textSize2 = (int) Math.Floor(hardTextSize2);
            return textSize2;
        }

        private static int TimerToBuffSize(int buffSize)
        {
            var buffTextPercent = buffSize / 100.00;
            var hardTextSize = 32.00 * buffTextPercent;
            return (int) Math.Floor(hardTextSize);
        }

        private RectangleF DrawBuffTimer(float buffX, int textSize, string buffTimerText, RectangleF rect,
            RectangleF testBuffWindow)
        {
            if (buffTimerText == "") return testBuffWindow;

            var buffTimer = Graphics.DrawText(buffTimerText, textSize,
                new Vector2(rect.Width * buffX * .01f, testBuffWindow.Top - textSize + -1), Color.White,
                FontDrawFlags.Center);

            var timerBackground = new RectangleF(testBuffWindow.X, testBuffWindow.Y, testBuffWindow.Width,
                -buffTimer.Height + -1 + 1);

            Graphics.DrawImage("lightBackground.png", timerBackground);

            return testBuffWindow;
        }

        private void DrawCharge(string charges, int textSize, RectangleF testBuffWindow)
        {
            var chargeText = Graphics.DrawText(charges, textSize,
                new Vector2(testBuffWindow.Left + 3, testBuffWindow.Top + 1), Color.White);

            var background = new RectangleF(testBuffWindow.X, testBuffWindow.Y, chargeText.Width + 6,
                chargeText.Height + 2);

            Graphics.DrawImage("lightBackground.png", background);
        }

        private void OnAreaChange(AreaController area)
        {
            _isTown = area.CurrentArea.IsTown;
        }
    }
}