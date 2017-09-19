using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;

namespace Buff_God
{
    public class PluginSettings : SettingsBase
    {
        public PluginSettings()
        {
            Force_Icons_On = false;
            Golems = true;
            Offerings = true;
            Vaal_Skills = true;
            Offensive_Aura = true;
            Defenseive_Aura = true;
            Charges = true;
            Leeching = true;
            Curses = true;
            Others = true;

            #region Others
            Arcane_Surge = true;
            Arcane_Surge_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Arcane_Surge_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Arcane_Surge_Size = new RangeNode<int>(64, 1, 128);
            Arcane_Surge_ShowInactive = false;

            Blood_Rage = true;
            Blood_Rage_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Blood_Rage_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Blood_Rage_Size = new RangeNode<int>(64, 1, 128);
            Blood_Rage_ShowInactive = false;
            #endregion
            #region Vaal Skills
            Vaal_Haste = true;
            Vaal_Haste_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Vaal_Haste_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Vaal_Haste_Size = new RangeNode<int>(64, 1, 128);
            Vaal_Haste_ShowInactive = false;

            Vaal_Discipline = true;
            Vaal_Discipline_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Vaal_Discipline_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Vaal_Discipline_Size = new RangeNode<int>(64, 1, 128);
            Vaal_Discipline_ShowInactive = false;

            Vaal_Grace = true;
            Vaal_Grace_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Vaal_Grace_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Vaal_Grace_Size = new RangeNode<int>(64, 1, 128);
            Vaal_Grace_ShowInactive = false;

            Vaal_Clarity = true;
            Vaal_Clarity_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Vaal_Clarity_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Vaal_Clarity_Size = new RangeNode<int>(64, 1, 128);
            Vaal_Clarity_ShowInactive = false;
            #endregion
            #region Offerings
            Offering_Effect = true;
            Offering_Effect_X = new RangeNode<float>(21f, 0.0f, 100.0f);
            Offering_Effect_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Offering_Effect_Size = new RangeNode<int>(64, 1, 128);
            Offering_Effect_ShowInactive = false;
            #endregion
            #region Golems
            Fire_Golem = true;
            Fire_Golem_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Fire_Golem_Y = new RangeNode<float>(67f, 0.0f, 100.0f);
            Fire_Golem_Size = new RangeNode<int>(64, 1, 128);
            Fire_Golem_ShowInactive = false;

            Stone_Golem = true;
            Stone_Golem_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Stone_Golem_Y = new RangeNode<float>(67f, 0.0f, 100.0f);
            Stone_Golem_Size = new RangeNode<int>(64, 1, 128);
            Stone_Golem_ShowInactive = false;

            Ice_Golem = true;
            Ice_Golem_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Ice_Golem_Y = new RangeNode<float>(67f, 0.0f, 100.0f);
            Ice_Golem_Size = new RangeNode<int>(64, 1, 128);
            Ice_Golem_ShowInactive = false;

            Chaos_Golem = true;
            Chaos_Golem_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Chaos_Golem_Y = new RangeNode<float>(67f, 0.0f, 100.0f);
            Chaos_Golem_Size = new RangeNode<int>(64, 1, 128);
            Chaos_Golem_ShowInactive = false;

            Lightning_Golem = true;
            Lightning_Golem_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Lightning_Golem_Y = new RangeNode<float>(67f, 0.0f, 100.0f);
            Lightning_Golem_Size = new RangeNode<int>(64, 1, 128);
            Lightning_Golem_ShowInactive = false;
            #endregion
            #region Offensive Auras
            Anger = true;
            Anger_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Anger_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Anger_Size = new RangeNode<int>(64, 1, 128);
            Anger_ShowInactive = false;

            Hatred = true;
            Hatred_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Hatred_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Hatred_Size = new RangeNode<int>(64, 1, 128);
            Hatred_ShowInactive = false;

            Wrath = true;
            Wrath_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Wrath_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Wrath_Size = new RangeNode<int>(64, 1, 128);
            Wrath_ShowInactive = false;

            Herald_of_Ash = true;
            Herald_of_Ash_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Herald_of_Ash_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Herald_of_Ash_Size = new RangeNode<int>(64, 1, 128);
            Herald_of_Ash_ShowInactive = false;

            Herald_of_Ice = true;
            Herald_of_Ice_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Herald_of_Ice_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Herald_of_Ice_Size = new RangeNode<int>(64, 1, 128);
            Herald_of_Ice_ShowInactive = false;

            Herald_of_Thunder = true;
            Herald_of_Thunder_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Herald_of_Thunder_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Herald_of_Thunder_Size = new RangeNode<int>(64, 1, 128);
            Herald_of_Thunder_ShowInactive = false;

            Haste = true;
            Haste_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Haste_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Haste_Size = new RangeNode<int>(64, 1, 128);
            Haste_ShowInactive = false;
            #endregion
            #region Defensive Auras
            Purity_of_Fire = true;
            Purity_of_Fire_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Purity_of_Fire_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Purity_of_Fire_Size = new RangeNode<int>(64, 1, 128);
            Purity_of_Fire_ShowInactive = false;

            Purity_of_Ice = true;
            Purity_of_Ice_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Purity_of_Ice_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Purity_of_Ice_Size = new RangeNode<int>(64, 1, 128);
            Purity_of_Ice_ShowInactive = false;

            Purity_of_Lightning = true;
            Purity_of_Lightning_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Purity_of_Lightning_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Purity_of_Lightning_Size = new RangeNode<int>(64, 1, 128);
            Purity_of_Lightning_ShowInactive = false;

            Purity_of_Elements = true;
            Purity_of_Elements_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Purity_of_Elements_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Purity_of_Elements_Size = new RangeNode<int>(64, 1, 128);
            Purity_of_Elements_ShowInactive = false;

            Vitality = true;
            Vitality_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Vitality_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Vitality_Size = new RangeNode<int>(64, 1, 128);
            Vitality_ShowInactive = false;

            Discipline = true;
            Discipline_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Discipline_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Discipline_Size = new RangeNode<int>(64, 1, 128);
            Discipline_ShowInactive = false;

            Determination = true;
            Determination_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Determination_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Determination_Size = new RangeNode<int>(64, 1, 128);
            Determination_ShowInactive = false;

            Grace = true;
            Grace_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Grace_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Grace_Size = new RangeNode<int>(64, 1, 128);
            Grace_ShowInactive = false;

            Clarity = true;
            Clarity_X = new RangeNode<float>(17f, 0.0f, 100.0f);
            Clarity_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Clarity_Size = new RangeNode<int>(64, 1, 128);
            Clarity_ShowInactive = false;
            #endregion
            #region Charges
            Power_Charges = true;
            Power_Charges_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Power_Charges_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Power_Charges_Size = new RangeNode<int>(64, 1, 128);
            Power_Charges_ShowInactive = false;

            Frenzy_Charges = true;
            Frenzy_Charges_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Frenzy_Charges_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Frenzy_Charges_Size = new RangeNode<int>(64, 1, 128);
            Frenzy_Charges_ShowInactive = false;

            Endurance_Charges = true;
            Endurance_Charges_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Endurance_Charges_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Endurance_Charges_Size = new RangeNode<int>(64, 1, 128);
            Endurance_Charges_ShowInactive = false;

            Blade_Vortex_Stacks = true;
            Blade_Vortex_Stacks_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Blade_Vortex_Stacks_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Blade_Vortex_Stacks_Size = new RangeNode<int>(64, 1, 128);
            Blade_Vortex_Stacks_ShowInactive = false;
            Blade_Vortex_Stacks_BurnedCharges = false;

            Reave_Stacks = true;
            Reave_Stacks_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Reave_Stacks_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Reave_Stacks_Size = new RangeNode<int>(64, 1, 128);
            Reave_Stacks_ShowInactive = false;
            Reave_Stacks_BurnedCharges = false;
            #endregion
            #region Curses
            Curse_Poachers_Mark = true;
            Curse_Poachers_Mark_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Poachers_Mark_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Poachers_Mark_Size = new RangeNode<int>(64, 1, 128);
            Curse_Poachers_Mark_ShowInactive = false;

            Curse_Frostbite = true;
            Curse_Frostbite_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Frostbite_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Frostbite_Size = new RangeNode<int>(64, 1, 128);
            Curse_Frostbite_ShowInactive = false;

            Curse_Vulnerability = true;
            Curse_Vulnerability_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Vulnerability_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Vulnerability_Size = new RangeNode<int>(64, 1, 128);
            Curse_Vulnerability_ShowInactive = false;

            Curse_Warlords_Mark = true;
            Curse_Warlords_Mark_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Warlords_Mark_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Warlords_Mark_Size = new RangeNode<int>(64, 1, 128);
            Curse_Warlords_Mark_ShowInactive = false;

            Curse_Flammability = true;
            Curse_Flammability_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Flammability_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Flammability_Size = new RangeNode<int>(64, 1, 128);
            Curse_Flammability_ShowInactive = false;

            Curse_Assassins_Mark = true;
            Curse_Assassins_Mark_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Assassins_Mark_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Assassins_Mark_Size = new RangeNode<int>(64, 1, 128);
            Curse_Assassins_Mark_ShowInactive = false;

            Curse_Elemental_Weakness = true;
            Curse_Elemental_Weakness_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Elemental_Weakness_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Elemental_Weakness_Size = new RangeNode<int>(64, 1, 128);
            Curse_Elemental_Weakness_ShowInactive = false;

            Curse_Conductivity = true;
            Curse_Conductivity_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Conductivity_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Conductivity_Size = new RangeNode<int>(64, 1, 128);
            Curse_Conductivity_ShowInactive = false;

            Curse_Enfeeble = true;
            Curse_Enfeeble_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Enfeeble_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Enfeeble_Size = new RangeNode<int>(64, 1, 128);
            Curse_Enfeeble_ShowInactive = false;

            Curse_Punishment = true;
            Curse_Punishment_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Punishment_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Punishment_Size = new RangeNode<int>(64, 1, 128);
            Curse_Punishment_ShowInactive = false;

            Curse_Projectile_Weakness = true;
            Curse_Projectile_Weakness_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Projectile_Weakness_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Projectile_Weakness_Size = new RangeNode<int>(64, 1, 128);
            Curse_Projectile_Weakness_ShowInactive = false;

            Curse_Temporal_Chains = true;
            Curse_Temporal_Chains_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Curse_Temporal_Chains_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Curse_Temporal_Chains_Size = new RangeNode<int>(64, 1, 128);
            Curse_Temporal_Chains_ShowInactive = false;
            #endregion
            #region Leeching
            Leeching_Life = true;
            Leeching_Life_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Leeching_Life_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Leeching_Life_Size = new RangeNode<int>(64, 1, 128);
            Leeching_Life_ShowInactive = false;

            Leeching_Mana = true;
            Leeching_Mana_X = new RangeNode<float>(13f, 0.0f, 100.0f);
            Leeching_Mana_Y = new RangeNode<float>(76f, 0.0f, 100.0f);
            Leeching_Mana_Size = new RangeNode<int>(64, 1, 128);
            Leeching_Mana_ShowInactive = false;
            #endregion

        }

        [Menu("Force Icons On", 1)]
        public ToggleNode Force_Icons_On { get; set; }

        [Menu("Golems", 2)]
        public ToggleNode Golems { get; set; }

        [Menu("Offerings", 3)]
        public ToggleNode Offerings { get; set; }

        [Menu("Vaal Skills", 4)]
        public ToggleNode Vaal_Skills { get; set; }

        [Menu("Offensive Auras", 5)]
        public ToggleNode Offensive_Aura { get; set; }

        [Menu("Defensive Auras", 6)]
        public ToggleNode Defenseive_Aura { get; set; }

        [Menu("Charges", 8)]
        public ToggleNode Charges { get; set; }

        [Menu("Leeching", 9)]
        public ToggleNode Leeching { get; set; }

        [Menu("Curses", 1000)]
        public ToggleNode Curses { get; set; }

        [Menu("Others", 7)]
        public ToggleNode Others { get; set; }


        #region Golems
        // Golems
        [Menu("Fire Golem", 130, 2)]
        public ToggleNode Fire_Golem { get; set; }
        [Menu("X", 1301, 130)]
        public RangeNode<float> Fire_Golem_X { get; set; }
        [Menu("Y", 1302, 130)]
        public RangeNode<float> Fire_Golem_Y { get; set; }
        [Menu("Size", 1303, 130)]
        public RangeNode<int> Fire_Golem_Size { get; set; }
        [Menu("Show Inactive", 1304, 130)]
        public ToggleNode Fire_Golem_ShowInactive { get; set; }

        [Menu("Ice Golem", 140, 2)]
        public ToggleNode Ice_Golem { get; set; }
        [Menu("X", 1401, 140)]
        public RangeNode<float> Ice_Golem_X { get; set; }
        [Menu("Y", 1402, 140)]
        public RangeNode<float> Ice_Golem_Y { get; set; }
        [Menu("Size", 1403, 140)]
        public RangeNode<int> Ice_Golem_Size { get; set; }
        [Menu("Show Inactive", 1404, 140)]
        public ToggleNode Ice_Golem_ShowInactive { get; set; }

        [Menu("Lightning Golem", 150, 2)]
        public ToggleNode Lightning_Golem { get; set; }
        [Menu("X", 1501, 150)]
        public RangeNode<float> Lightning_Golem_X { get; set; }
        [Menu("Y", 1502, 150)]
        public RangeNode<float> Lightning_Golem_Y { get; set; }
        [Menu("Size", 1503, 150)]
        public RangeNode<int> Lightning_Golem_Size { get; set; }
        [Menu("Show Inactive", 1504, 150)]
        public ToggleNode Lightning_Golem_ShowInactive { get; set; }

        [Menu("Chaos Golem", 160, 2)]
        public ToggleNode Chaos_Golem { get; set; }
        [Menu("X", 1601, 160)]
        public RangeNode<float> Chaos_Golem_X { get; set; }
        [Menu("Y", 1602, 160)]
        public RangeNode<float> Chaos_Golem_Y { get; set; }
        [Menu("Size", 1603, 160)]
        public RangeNode<int> Chaos_Golem_Size { get; set; }
        [Menu("Show Inactive", 1604, 160)]
        public ToggleNode Chaos_Golem_ShowInactive { get; set; }

        [Menu("Stone Golem", 170, 2)]
        public ToggleNode Stone_Golem { get; set; }
        [Menu("X", 1701, 170)]
        public RangeNode<float> Stone_Golem_X { get; set; }
        [Menu("Y", 1702, 170)]
        public RangeNode<float> Stone_Golem_Y { get; set; }
        [Menu("Size", 1703, 170)]
        public RangeNode<int> Stone_Golem_Size { get; set; }
        [Menu("Show Inactive", 1704, 170)]
        public ToggleNode Stone_Golem_ShowInactive { get; set; }
        #endregion
        #region Others
        // Others
        [Menu("Arcane Surge", 312, 7)]
        public ToggleNode Arcane_Surge { get; set; }
        [Menu("X", 3121, 312)]
        public RangeNode<float> Arcane_Surge_X { get; set; }
        [Menu("Y", 3122, 312)]
        public RangeNode<float> Arcane_Surge_Y { get; set; }
        [Menu("Size", 3123, 312)]
        public RangeNode<int> Arcane_Surge_Size { get; set; }
        [Menu("Show Inactive", 3124, 312)]
        public ToggleNode Arcane_Surge_ShowInactive { get; set; }

        [Menu("Blood Rage", 313, 7)]
        public ToggleNode Blood_Rage { get; set; }
        [Menu("X", 3131, 313)]
        public RangeNode<float> Blood_Rage_X { get; set; }
        [Menu("Y", 3132, 313)]
        public RangeNode<float> Blood_Rage_Y { get; set; }
        [Menu("Size", 3133, 313)]
        public RangeNode<int> Blood_Rage_Size { get; set; }
        [Menu("Show Inactive", 3134, 313)]
        public ToggleNode Blood_Rage_ShowInactive { get; set; }
        #endregion
        #region Vaal Skills
        // Vaal Skills
        [Menu("Vaal Haste", 4562, 4)]
        public ToggleNode Vaal_Haste { get; set; }
        [Menu("X", 45621, 4562)]
        public RangeNode<float> Vaal_Haste_X { get; set; }
        [Menu("Y", 45622, 4562)]
        public RangeNode<float> Vaal_Haste_Y { get; set; }
        [Menu("Size", 45623, 4562)]
        public RangeNode<int> Vaal_Haste_Size { get; set; }
        [Menu("Show Inactive", 45624, 4562)]
        public ToggleNode Vaal_Haste_ShowInactive { get; set; }
        
        [Menu("Vaal Grace", 460, 4)]
        public ToggleNode Vaal_Grace { get; set; }
        [Menu("X", 4601, 460)]
        public RangeNode<float> Vaal_Grace_X { get; set; }
        [Menu("Y", 4602, 460)]
        public RangeNode<float> Vaal_Grace_Y { get; set; }
        [Menu("Size", 4603, 460)]
        public RangeNode<int> Vaal_Grace_Size { get; set; }
        [Menu("Show Inactive", 4604, 460)]
        public ToggleNode Vaal_Grace_ShowInactive { get; set; }

        [Menu("Vaal Clarity", 470, 4)]
        public ToggleNode Vaal_Clarity { get; set; }
        [Menu("X", 4701, 470)]
        public RangeNode<float> Vaal_Clarity_X { get; set; }
        [Menu("Y", 4702, 470)]
        public RangeNode<float> Vaal_Clarity_Y { get; set; }
        [Menu("Size", 4703, 470)]
        public RangeNode<int> Vaal_Clarity_Size { get; set; }
        [Menu("Show Inactive", 4704, 470)]
        public ToggleNode Vaal_Clarity_ShowInactive { get; set; }

        [Menu("Vaal Discipline", 480, 4)]
        public ToggleNode Vaal_Discipline { get; set; }
        [Menu("X", 4801, 480)]
        public RangeNode<float> Vaal_Discipline_X { get; set; }
        [Menu("Y", 4802, 480)]
        public RangeNode<float> Vaal_Discipline_Y { get; set; }
        [Menu("Size", 4803, 480)]
        public RangeNode<int> Vaal_Discipline_Size { get; set; }
        [Menu("Show Inactive", 4804, 480)]
        public ToggleNode Vaal_Discipline_ShowInactive { get; set; }
        #endregion
        #region Offerings
        // Offerings
        [Menu("Offering Effect", 120, 3)]
        public ToggleNode Offering_Effect { get; set; }
        [Menu("X", 1201, 120)]
        public RangeNode<float> Offering_Effect_X { get; set; }
        [Menu("Y", 1202, 120)]
        public RangeNode<float> Offering_Effect_Y { get; set; }
        [Menu("Size", 1203, 120)]
        public RangeNode<int> Offering_Effect_Size { get; set; }
        [Menu("Show Inactive", 1204, 120)]
        public ToggleNode Offering_Effect_ShowInactive { get; set; } 
        #endregion
        #region Offensive Auras
        // Offensive Auras
        [Menu("Anger", 210, 5)]
        public ToggleNode Anger { get; set; }
        [Menu("X", 2101, 210)]
        public RangeNode<float> Anger_X { get; set; }
        [Menu("Y", 2102, 210)]
        public RangeNode<float> Anger_Y { get; set; }
        [Menu("Size", 2103, 210)]
        public RangeNode<int> Anger_Size { get; set; }
        [Menu("Show Inactive", 2104, 210)]
        public ToggleNode Anger_ShowInactive { get; set; }

        [Menu("Hatred", 229, 5)]
        public ToggleNode Hatred { get; set; }
        [Menu("X", 2291, 229)]
        public RangeNode<float> Hatred_X { get; set; }
        [Menu("Y", 2292, 229)]
        public RangeNode<float> Hatred_Y { get; set; }
        [Menu("Size", 2293, 229)]
        public RangeNode<int> Hatred_Size { get; set; }
        [Menu("Show Inactive", 2294, 229)]
        public ToggleNode Hatred_ShowInactive { get; set; }

        [Menu("Wrath", 230, 5)]
        public ToggleNode Wrath { get; set; }
        [Menu("X", 2301, 230)]
        public RangeNode<float> Wrath_X { get; set; }
        [Menu("Y", 2302, 230)]
        public RangeNode<float> Wrath_Y { get; set; }
        [Menu("Size", 2303, 230)]
        public RangeNode<int> Wrath_Size { get; set; }
        [Menu("Show Inactive", 2304, 230)]
        public ToggleNode Wrath_ShowInactive { get; set; }

        [Menu("Herald of Ash", 240, 5)]
        public ToggleNode Herald_of_Ash { get; set; }
        [Menu("X", 2401, 240)]
        public RangeNode<float> Herald_of_Ash_X { get; set; }
        [Menu("Y", 2402, 240)]
        public RangeNode<float> Herald_of_Ash_Y { get; set; }
        [Menu("Size", 2403, 240)]
        public RangeNode<int> Herald_of_Ash_Size { get; set; }
        [Menu("Show Inactive", 2404, 240)]
        public ToggleNode Herald_of_Ash_ShowInactive { get; set; }

        [Menu("Herald of Ice", 250, 5)]
        public ToggleNode Herald_of_Ice { get; set; }
        [Menu("X", 2501, 250)]
        public RangeNode<float> Herald_of_Ice_X { get; set; }
        [Menu("Y", 2502, 250)]
        public RangeNode<float> Herald_of_Ice_Y { get; set; }
        [Menu("Size", 2503, 250)]
        public RangeNode<int> Herald_of_Ice_Size { get; set; }
        [Menu("Show Inactive", 2504, 250)]
        public ToggleNode Herald_of_Ice_ShowInactive { get; set; }

        [Menu("Herald of Thunder", 260, 5)]
        public ToggleNode Herald_of_Thunder { get; set; }
        [Menu("X", 2601, 260)]
        public RangeNode<float> Herald_of_Thunder_X { get; set; }
        [Menu("Y", 2602, 260)]
        public RangeNode<float> Herald_of_Thunder_Y { get; set; }
        [Menu("Size", 2603, 260)]
        public RangeNode<int> Herald_of_Thunder_Size { get; set; }
        [Menu("Show Inactive", 2604, 260)]
        public ToggleNode Herald_of_Thunder_ShowInactive { get; set; }

        [Menu("Haste", 270, 5)]
        public ToggleNode Haste { get; set; }
        [Menu("X", 2701, 270)]
        public RangeNode<float> Haste_X { get; set; }
        [Menu("Y", 2702, 270)]
        public RangeNode<float> Haste_Y { get; set; }
        [Menu("Size", 2703, 270)]
        public RangeNode<int> Haste_Size { get; set; }
        [Menu("Show Inactive", 2704, 270)]
        public ToggleNode Haste_ShowInactive { get; set; }
        #endregion
        #region Defensive Auras
        // Defensive Auras
        [Menu("Purity of Fire", 310, 6)]
        public ToggleNode Purity_of_Fire { get; set; }
        [Menu("X", 3101, 310)]
        public RangeNode<float> Purity_of_Fire_X { get; set; }
        [Menu("Y", 3102, 310)]
        public RangeNode<float> Purity_of_Fire_Y { get; set; }
        [Menu("Size", 3103, 310)]
        public RangeNode<int> Purity_of_Fire_Size { get; set; }
        [Menu("Show Inactive", 3104, 310)]
        public ToggleNode Purity_of_Fire_ShowInactive { get; set; }

        [Menu("Purity of Ice", 320, 6)]
        public ToggleNode Purity_of_Ice { get; set; }
        [Menu("X", 3201, 320)]
        public RangeNode<float> Purity_of_Ice_X { get; set; }
        [Menu("Y", 3202, 320)]
        public RangeNode<float> Purity_of_Ice_Y { get; set; }
        [Menu("Size", 3203, 320)]
        public RangeNode<int> Purity_of_Ice_Size { get; set; }
        [Menu("Show Inactive", 3204, 320)]
        public ToggleNode Purity_of_Ice_ShowInactive { get; set; }

        [Menu("Purity of Lightning", 330, 6)]
        public ToggleNode Purity_of_Lightning { get; set; }
        [Menu("X", 3301, 330)]
        public RangeNode<float> Purity_of_Lightning_X { get; set; }
        [Menu("Y", 3302, 330)]
        public RangeNode<float> Purity_of_Lightning_Y { get; set; }
        [Menu("Size", 3303, 330)]
        public RangeNode<int> Purity_of_Lightning_Size { get; set; }
        [Menu("Show Inactive", 3304, 330)]
        public ToggleNode Purity_of_Lightning_ShowInactive { get; set; }

        [Menu("Purity of Elements", 340, 6)]
        public ToggleNode Purity_of_Elements { get; set; }
        [Menu("X", 3401, 340)]
        public RangeNode<float> Purity_of_Elements_X { get; set; }
        [Menu("Y", 3402, 340)]
        public RangeNode<float> Purity_of_Elements_Y { get; set; }
        [Menu("Size", 3403, 340)]
        public RangeNode<int> Purity_of_Elements_Size { get; set; }
        [Menu("Show Inactive", 3404, 340)]
        public ToggleNode Purity_of_Elements_ShowInactive { get; set; }

        [Menu("Vitality", 350, 6)]
        public ToggleNode Vitality { get; set; }
        [Menu("X", 3501, 350)]
        public RangeNode<float> Vitality_X { get; set; }
        [Menu("Y", 3502, 350)]
        public RangeNode<float> Vitality_Y { get; set; }
        [Menu("Size", 3503, 350)]
        public RangeNode<int> Vitality_Size { get; set; }
        [Menu("Show Inactive", 3504, 350)]
        public ToggleNode Vitality_ShowInactive { get; set; }

        [Menu("Discipline", 360, 6)]
        public ToggleNode Discipline { get; set; }
        [Menu("X", 3601, 360)]
        public RangeNode<float> Discipline_X { get; set; }
        [Menu("Y", 3602, 360)]
        public RangeNode<float> Discipline_Y { get; set; }
        [Menu("Size", 3603, 360)]
        public RangeNode<int> Discipline_Size { get; set; }
        [Menu("Show Inactive", 3604, 360)]
        public ToggleNode Discipline_ShowInactive { get; set; }

        [Menu("Determination", 370, 6)]
        public ToggleNode Determination { get; set; }
        [Menu("X", 3701, 370)]
        public RangeNode<float> Determination_X { get; set; }
        [Menu("Y", 3702, 370)]
        public RangeNode<float> Determination_Y { get; set; }
        [Menu("Size", 3703, 370)]
        public RangeNode<int> Determination_Size { get; set; }
        [Menu("Show Inactive", 3704, 370)]
        public ToggleNode Determination_ShowInactive { get; set; }

        [Menu("Grace", 380, 6)]
        public ToggleNode Grace { get; set; }
        [Menu("X", 3801, 380)]
        public RangeNode<float> Grace_X { get; set; }
        [Menu("Y", 3802, 380)]
        public RangeNode<float> Grace_Y { get; set; }
        [Menu("Size", 3803, 380)]
        public RangeNode<int> Grace_Size { get; set; }
        [Menu("Show Inactive", 3804, 380)]
        public ToggleNode Grace_ShowInactive { get; set; }
        
        [Menu("Clarity", 390, 6)]
        public ToggleNode Clarity { get; set; }
        [Menu("X", 3901, 390)]
        public RangeNode<float> Clarity_X { get; set; }
        [Menu("Y", 3902, 390)]
        public RangeNode<float> Clarity_Y { get; set; }
        [Menu("Size", 3903, 390)]
        public RangeNode<int> Clarity_Size { get; set; }
        [Menu("Show Inactive", 3904, 390)]
        public ToggleNode Clarity_ShowInactive { get; set; }
        #endregion
        #region Charges
        // Charges
        [Menu("Power Charges", 510, 8)]
        public ToggleNode Power_Charges { get; set; }
        [Menu("X", 5101, 510)]
        public RangeNode<float> Power_Charges_X { get; set; }
        [Menu("Y", 5102, 510)]
        public RangeNode<float> Power_Charges_Y { get; set; }
        [Menu("Size", 5103, 510)]
        public RangeNode<int> Power_Charges_Size { get; set; }
        [Menu("Show Inactive", 5104, 510)]
        public ToggleNode Power_Charges_ShowInactive { get; set; }

        [Menu("Frenzy Charges", 520, 8)]
        public ToggleNode Frenzy_Charges { get; set; }
        [Menu("X", 5201, 520)]
        public RangeNode<float> Frenzy_Charges_X { get; set; }
        [Menu("Y", 5202, 520)]
        public RangeNode<float> Frenzy_Charges_Y { get; set; }
        [Menu("Size", 5203, 520)]
        public RangeNode<int> Frenzy_Charges_Size { get; set; }
        [Menu("Show Inactive", 5204, 520)]
        public ToggleNode Frenzy_Charges_ShowInactive { get; set; }

        [Menu("Endurance Charges", 530, 8)]
        public ToggleNode Endurance_Charges { get; set; }
        [Menu("X", 5301, 530)]
        public RangeNode<float> Endurance_Charges_X { get; set; }
        [Menu("Y", 5302, 530)]
        public RangeNode<float> Endurance_Charges_Y { get; set; }
        [Menu("Size", 5303, 530)]
        public RangeNode<int> Endurance_Charges_Size { get; set; }
        [Menu("Show Inactive", 5304, 530)]
        public ToggleNode Endurance_Charges_ShowInactive { get; set; }

        [Menu("Blade Vortex Stacks", 540, 8)]
        public ToggleNode Blade_Vortex_Stacks { get; set; }
        [Menu("X", 5401, 540)]
        public RangeNode<float> Blade_Vortex_Stacks_X { get; set; }
        [Menu("Y", 5402, 540)]
        public RangeNode<float> Blade_Vortex_Stacks_Y { get; set; }
        [Menu("Size", 5403, 540)]
        public RangeNode<int> Blade_Vortex_Stacks_Size { get; set; }
        [Menu("Show Inactive", 5404, 540)]
        public ToggleNode Blade_Vortex_Stacks_ShowInactive { get; set; }
        [Menu("Charges Above Icon", 5405, 540)]
        public ToggleNode Blade_Vortex_Stacks_BurnedCharges { get; set; }
        
        [Menu("Reave Stacks", 550, 8)]
        public ToggleNode Reave_Stacks { get; set; }
        [Menu("X", 5501, 550)]
        public RangeNode<float> Reave_Stacks_X { get; set; }
        [Menu("Y", 5502, 550)]
        public RangeNode<float> Reave_Stacks_Y { get; set; }
        [Menu("Size", 5503, 550)]
        public RangeNode<int> Reave_Stacks_Size { get; set; }
        [Menu("Show Inactive", 5504, 550)]
        public ToggleNode Reave_Stacks_ShowInactive { get; set; }
        [Menu("Charges Above Icon", 5505, 550)]
        public ToggleNode Reave_Stacks_BurnedCharges { get; set; }
        #endregion
        #region Curses
        [Menu("Poacher's Mark", 610, 1000)]
        public ToggleNode Curse_Poachers_Mark { get; set; }
        [Menu("X", 6101, 610)]
        public RangeNode<float> Curse_Poachers_Mark_X { get; set; }
        [Menu("Y", 6102, 610)]
        public RangeNode<float> Curse_Poachers_Mark_Y { get; set; }
        [Menu("Size", 6103, 610)]
        public RangeNode<int> Curse_Poachers_Mark_Size { get; set; }
        [Menu("Show Inactive", 6104, 610)]
        public ToggleNode Curse_Poachers_Mark_ShowInactive { get; set; }

        [Menu("Frostbite", 620, 1000)]
        public ToggleNode Curse_Frostbite { get; set; }
        [Menu("X", 6201, 620)]
        public RangeNode<float> Curse_Frostbite_X { get; set; }
        [Menu("Y", 6202, 620)]
        public RangeNode<float> Curse_Frostbite_Y { get; set; }
        [Menu("Size", 6203, 620)]
        public RangeNode<int> Curse_Frostbite_Size { get; set; }
        [Menu("Show Inactive", 6204, 620)]
        public ToggleNode Curse_Frostbite_ShowInactive { get; set; }

        [Menu("Vulnerability", 630, 1000)]
        public ToggleNode Curse_Vulnerability { get; set; }
        [Menu("X", 6301, 630)]
        public RangeNode<float> Curse_Vulnerability_X { get; set; }
        [Menu("Y", 6302, 630)]
        public RangeNode<float> Curse_Vulnerability_Y { get; set; }
        [Menu("Size", 6303, 630)]
        public RangeNode<int> Curse_Vulnerability_Size { get; set; }
        [Menu("Show Inactive", 6304, 630)]
        public ToggleNode Curse_Vulnerability_ShowInactive { get; set; }

        [Menu("Warlord's Mark", 640, 1000)]
        public ToggleNode Curse_Warlords_Mark { get; set; }
        [Menu("X", 6401, 640)]
        public RangeNode<float> Curse_Warlords_Mark_X { get; set; }
        [Menu("Y", 6402, 640)]
        public RangeNode<float> Curse_Warlords_Mark_Y { get; set; }
        [Menu("Size", 6403, 640)]
        public RangeNode<int> Curse_Warlords_Mark_Size { get; set; }
        [Menu("Show Inactive", 6404, 640)]
        public ToggleNode Curse_Warlords_Mark_ShowInactive { get; set; }

        [Menu("Flammability", 650, 1000)]
        public ToggleNode Curse_Flammability { get; set; }
        [Menu("X", 6501, 650)]
        public RangeNode<float> Curse_Flammability_X { get; set; }
        [Menu("Y", 6502, 650)]
        public RangeNode<float> Curse_Flammability_Y { get; set; }
        [Menu("Size", 6503, 650)]
        public RangeNode<int> Curse_Flammability_Size { get; set; }
        [Menu("Show Inactive", 6504, 650)]
        public ToggleNode Curse_Flammability_ShowInactive { get; set; }

        [Menu("Assassin's Mark", 660, 1000)]
        public ToggleNode Curse_Assassins_Mark { get; set; }
        [Menu("X", 6601, 660)]
        public RangeNode<float> Curse_Assassins_Mark_X { get; set; }
        [Menu("Y", 6602, 660)]
        public RangeNode<float> Curse_Assassins_Mark_Y { get; set; }
        [Menu("Size", 6603, 660)]
        public RangeNode<int> Curse_Assassins_Mark_Size { get; set; }
        [Menu("Show Inactive", 6604, 660)]
        public ToggleNode Curse_Assassins_Mark_ShowInactive { get; set; }

        [Menu("Elemental Weakness", 670, 1000)]
        public ToggleNode Curse_Elemental_Weakness { get; set; }
        [Menu("X", 6701, 670)]
        public RangeNode<float> Curse_Elemental_Weakness_X { get; set; }
        [Menu("Y", 6702, 670)]
        public RangeNode<float> Curse_Elemental_Weakness_Y { get; set; }
        [Menu("Size", 6703, 670)]
        public RangeNode<int> Curse_Elemental_Weakness_Size { get; set; }
        [Menu("Show Inactive", 6704, 670)]
        public ToggleNode Curse_Elemental_Weakness_ShowInactive { get; set; }

        [Menu("Conductivity", 680, 1000)]
        public ToggleNode Curse_Conductivity { get; set; }
        [Menu("X", 6801, 680)]
        public RangeNode<float> Curse_Conductivity_X { get; set; }
        [Menu("Y", 6802, 680)]
        public RangeNode<float> Curse_Conductivity_Y { get; set; }
        [Menu("Size", 6803, 680)]
        public RangeNode<int> Curse_Conductivity_Size { get; set; }
        [Menu("Show Inactive", 6804, 680)]
        public ToggleNode Curse_Conductivity_ShowInactive { get; set; }

        [Menu("Enfeeble", 690, 1000)]
        public ToggleNode Curse_Enfeeble { get; set; }
        [Menu("X", 6901, 690)]
        public RangeNode<float> Curse_Enfeeble_X { get; set; }
        [Menu("Y", 6902, 690)]
        public RangeNode<float> Curse_Enfeeble_Y { get; set; }
        [Menu("Size", 6903, 690)]
        public RangeNode<int> Curse_Enfeeble_Size { get; set; }
        [Menu("Show Inactive", 6904, 690)]
        public ToggleNode Curse_Enfeeble_ShowInactive { get; set; }

        [Menu("Punishment", 6010, 1000)]
        public ToggleNode Curse_Punishment { get; set; }
        [Menu("X", 60101, 6010)]
        public RangeNode<float> Curse_Punishment_X { get; set; }
        [Menu("Y", 60102, 6010)]
        public RangeNode<float> Curse_Punishment_Y { get; set; }
        [Menu("Size", 60103, 6010)]
        public RangeNode<int> Curse_Punishment_Size { get; set; }
        [Menu("Show Inactive", 60104, 6010)]
        public ToggleNode Curse_Punishment_ShowInactive { get; set; }

        [Menu("Projectile Weakness", 6011, 1000)]
        public ToggleNode Curse_Projectile_Weakness { get; set; }
        [Menu("X", 60111, 6011)]
        public RangeNode<float> Curse_Projectile_Weakness_X { get; set; }
        [Menu("Y", 60112, 6011)]
        public RangeNode<float> Curse_Projectile_Weakness_Y { get; set; }
        [Menu("Size", 60113, 6011)]
        public RangeNode<int> Curse_Projectile_Weakness_Size { get; set; }
        [Menu("Show Inactive", 60114, 6011)]
        public ToggleNode Curse_Projectile_Weakness_ShowInactive { get; set; }

        [Menu("Temporal Chains", 6012, 1000)]
        public ToggleNode Curse_Temporal_Chains { get; set; }
        [Menu("X", 60121, 6012)]
        public RangeNode<float> Curse_Temporal_Chains_X { get; set; }
        [Menu("Y", 60122, 6012)]
        public RangeNode<float> Curse_Temporal_Chains_Y { get; set; }
        [Menu("Size", 60123, 6012)]
        public RangeNode<int> Curse_Temporal_Chains_Size { get; set; }
        [Menu("Show Inactive", 60124, 6012)]
        public ToggleNode Curse_Temporal_Chains_ShowInactive { get; set; }
        #endregion
        #region Leeching
        // Leeching
        [Menu("Leeching Life", 710, 9)]
        public ToggleNode Leeching_Life { get; set; }
        [Menu("X", 7101, 710)]
        public RangeNode<float> Leeching_Life_X { get; set; }
        [Menu("Y", 7102, 710)]
        public RangeNode<float> Leeching_Life_Y { get; set; }
        [Menu("Size", 7103, 710)]
        public RangeNode<int> Leeching_Life_Size { get; set; }
        [Menu("Show Inactive", 7104, 710)]
        public ToggleNode Leeching_Life_ShowInactive { get; set; }

        [Menu("Leeching Mana", 720, 9)]
        public ToggleNode Leeching_Mana { get; set; }
        [Menu("X", 7201, 720)]
        public RangeNode<float> Leeching_Mana_X { get; set; }
        [Menu("Y", 7202, 720)]
        public RangeNode<float> Leeching_Mana_Y { get; set; }
        [Menu("Size", 7203, 720)]
        public RangeNode<int> Leeching_Mana_Size { get; set; }
        [Menu("Show Inactive", 7204, 720)]
        public ToggleNode Leeching_Mana_ShowInactive { get; set; }
        #endregion

    }
}