using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}