using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;

namespace Buff_God
{
    public class PluginSettings : SettingsBase
    {
        public PluginSettings()
        {
            ForceIconsOn = false;
            Golems = true;
            Offerings = true;
            VaalSkills = true;
            OffensiveAura = true;
            DefenseiveAura = true;
            Charges = true;
            Leeching = true;
            Curses = true;
            Others = true;
            IconTransparency = new RangeNode<int>(191, 1, 255);

            #region Others

            #region Arcane Surge
            ArcaneSurge = true;
            ArcaneSurgeX = new RangeNode<float>(13f, 0.0f, 100.0f);
            ArcaneSurgeY = new RangeNode<float>(76f, 0.0f, 100.0f);
            ArcaneSurgeSize = new RangeNode<int>(64, 1, 128);
            ArcaneSurgeShowInactive = false;
            #endregion

            #region Blood Rage
            BloodRage = true;
            BloodRageX = new RangeNode<float>(13f, 0.0f, 100.0f);
            BloodRageY = new RangeNode<float>(76f, 0.0f, 100.0f);
            BloodRageSize = new RangeNode<int>(64, 1, 128);
            BloodRageShowInactive = false;
            #endregion

            #region Elemental Overload
            ElementalOverload = true;
            ElementalOverloadX = new RangeNode<float>(13f, 0.0f, 100.0f);
            ElementalOverloadY = new RangeNode<float>(76f, 0.0f, 100.0f);
            ElementalOverloadSize = new RangeNode<int>(64, 1, 128);
            ElementalOverloadShowInactive = false;
            #endregion

            #region Elemental Conflux
            ElementalConflux = true;
            ElementalConfluxX = new RangeNode<float>(13f, 0.0f, 100.0f);
            ElementalConfluxY = new RangeNode<float>(76f, 0.0f, 100.0f);
            ElementalConfluxSize = new RangeNode<int>(64, 1, 128);
            ElementalConfluxShowInactive = false;
            #endregion

            #region Fortify
            Fortify = true;
            FortifyX = new RangeNode<float>(13f, 0.0f, 100.0f);
            FortifyY = new RangeNode<float>(76f, 0.0f, 100.0f);
            FortifySize = new RangeNode<int>(64, 1, 128);
            FortifyShowInactive = false;
            #endregion

            #region Adrenaline
            Adrenaline = true;
            AdrenalineX = new RangeNode<float>(13f, 0.0f, 100.0f);
            AdrenalineY = new RangeNode<float>(76f, 0.0f, 100.0f);
            AdrenalineSize = new RangeNode<int>(64, 1, 128);
            AdrenalineShowInactive = false;
            #endregion

            #endregion

            #region Vaal Skills

            VaalHaste = true;
            VaalHasteX = new RangeNode<float>(17f, 0.0f, 100.0f);
            VaalHasteY = new RangeNode<float>(76f, 0.0f, 100.0f);
            VaalHasteSize = new RangeNode<int>(64, 1, 128);
            VaalHasteShowInactive = false;

            VaalDiscipline = true;
            VaalDisciplineX = new RangeNode<float>(17f, 0.0f, 100.0f);
            VaalDisciplineY = new RangeNode<float>(76f, 0.0f, 100.0f);
            VaalDisciplineSize = new RangeNode<int>(64, 1, 128);
            VaalDisciplineShowInactive = false;

            VaalGrace = true;
            VaalGraceX = new RangeNode<float>(17f, 0.0f, 100.0f);
            VaalGraceY = new RangeNode<float>(76f, 0.0f, 100.0f);
            VaalGraceSize = new RangeNode<int>(64, 1, 128);
            VaalGraceShowInactive = false;

            VaalClarity = true;
            VaalClarityX = new RangeNode<float>(17f, 0.0f, 100.0f);
            VaalClarityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            VaalClaritySize = new RangeNode<int>(64, 1, 128);
            VaalClarityShowInactive = false;

            #endregion

            #region Offerings

            OfferingEffect = true;
            OfferingEffectX = new RangeNode<float>(21f, 0.0f, 100.0f);
            OfferingEffectY = new RangeNode<float>(76f, 0.0f, 100.0f);
            OfferingEffectSize = new RangeNode<int>(64, 1, 128);
            OfferingEffectShowInactive = false;

            #endregion

            #region Golems

            FireGolem = true;
            FireGolemX = new RangeNode<float>(13f, 0.0f, 100.0f);
            FireGolemY = new RangeNode<float>(67f, 0.0f, 100.0f);
            FireGolemSize = new RangeNode<int>(64, 1, 128);
            FireGolemShowInactive = false;

            StoneGolem = true;
            StoneGolemX = new RangeNode<float>(13f, 0.0f, 100.0f);
            StoneGolemY = new RangeNode<float>(67f, 0.0f, 100.0f);
            StoneGolemSize = new RangeNode<int>(64, 1, 128);
            StoneGolemShowInactive = false;

            IceGolem = true;
            IceGolemX = new RangeNode<float>(13f, 0.0f, 100.0f);
            IceGolemY = new RangeNode<float>(67f, 0.0f, 100.0f);
            IceGolemSize = new RangeNode<int>(64, 1, 128);
            IceGolemShowInactive = false;

            ChaosGolem = true;
            ChaosGolemX = new RangeNode<float>(13f, 0.0f, 100.0f);
            ChaosGolemY = new RangeNode<float>(67f, 0.0f, 100.0f);
            ChaosGolemSize = new RangeNode<int>(64, 1, 128);
            ChaosGolemShowInactive = false;

            LightningGolem = true;
            LightningGolemX = new RangeNode<float>(13f, 0.0f, 100.0f);
            LightningGolemY = new RangeNode<float>(67f, 0.0f, 100.0f);
            LightningGolemSize = new RangeNode<int>(64, 1, 128);
            LightningGolemShowInactive = false;

            #endregion

            #region Offensive Auras

            Anger = true;
            AngerX = new RangeNode<float>(17f, 0.0f, 100.0f);
            AngerY = new RangeNode<float>(76f, 0.0f, 100.0f);
            AngerSize = new RangeNode<int>(64, 1, 128);
            AngerShowInactive = false;

            Hatred = true;
            HatredX = new RangeNode<float>(17f, 0.0f, 100.0f);
            HatredY = new RangeNode<float>(76f, 0.0f, 100.0f);
            HatredSize = new RangeNode<int>(64, 1, 128);
            HatredShowInactive = false;

            Wrath = true;
            WrathX = new RangeNode<float>(17f, 0.0f, 100.0f);
            WrathY = new RangeNode<float>(76f, 0.0f, 100.0f);
            WrathSize = new RangeNode<int>(64, 1, 128);
            WrathShowInactive = false;

            HeraldOfAsh = true;
            HeraldOfAshX = new RangeNode<float>(17f, 0.0f, 100.0f);
            HeraldOfAshY = new RangeNode<float>(76f, 0.0f, 100.0f);
            HeraldOfAshSize = new RangeNode<int>(64, 1, 128);
            HeraldOfAshShowInactive = false;

            HeraldOfIce = true;
            HeraldOfIceX = new RangeNode<float>(17f, 0.0f, 100.0f);
            HeraldOfIceY = new RangeNode<float>(76f, 0.0f, 100.0f);
            HeraldOfIceSize = new RangeNode<int>(64, 1, 128);
            HeraldOfIceShowInactive = false;

            HeraldOfThunder = true;
            HeraldOfThunderX = new RangeNode<float>(17f, 0.0f, 100.0f);
            HeraldOfThunderY = new RangeNode<float>(76f, 0.0f, 100.0f);
            HeraldOfThunderSize = new RangeNode<int>(64, 1, 128);
            HeraldOfThunderShowInactive = false;

            Haste = true;
            HasteX = new RangeNode<float>(17f, 0.0f, 100.0f);
            HasteY = new RangeNode<float>(76f, 0.0f, 100.0f);
            HasteSize = new RangeNode<int>(64, 1, 128);
            HasteShowInactive = false;

            #endregion

            #region Defensive Auras

            PurityOfFire = true;
            PurityOfFireX = new RangeNode<float>(17f, 0.0f, 100.0f);
            PurityOfFireY = new RangeNode<float>(76f, 0.0f, 100.0f);
            PurityOfFireSize = new RangeNode<int>(64, 1, 128);
            PurityOfFireShowInactive = false;

            PurityOfIce = true;
            PurityOfIceX = new RangeNode<float>(17f, 0.0f, 100.0f);
            PurityOfIceY = new RangeNode<float>(76f, 0.0f, 100.0f);
            PurityOfIceSize = new RangeNode<int>(64, 1, 128);
            PurityOfIceShowInactive = false;

            PurityOfLightning = true;
            PurityOfLightningX = new RangeNode<float>(17f, 0.0f, 100.0f);
            PurityOfLightningY = new RangeNode<float>(76f, 0.0f, 100.0f);
            PurityOfLightningSize = new RangeNode<int>(64, 1, 128);
            PurityOfLightningShowInactive = false;

            PurityOfElements = true;
            PurityOfElementsX = new RangeNode<float>(17f, 0.0f, 100.0f);
            PurityOfElementsY = new RangeNode<float>(76f, 0.0f, 100.0f);
            PurityOfElementsSize = new RangeNode<int>(64, 1, 128);
            PurityOfElementsShowInactive = false;

            Vitality = true;
            VitalityX = new RangeNode<float>(17f, 0.0f, 100.0f);
            VitalityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            VitalitySize = new RangeNode<int>(64, 1, 128);
            VitalityShowInactive = false;

            Discipline = true;
            DisciplineX = new RangeNode<float>(17f, 0.0f, 100.0f);
            DisciplineY = new RangeNode<float>(76f, 0.0f, 100.0f);
            DisciplineSize = new RangeNode<int>(64, 1, 128);
            DisciplineShowInactive = false;

            Determination = true;
            DeterminationX = new RangeNode<float>(17f, 0.0f, 100.0f);
            DeterminationY = new RangeNode<float>(76f, 0.0f, 100.0f);
            DeterminationSize = new RangeNode<int>(64, 1, 128);
            DeterminationShowInactive = false;

            Grace = true;
            GraceX = new RangeNode<float>(17f, 0.0f, 100.0f);
            GraceY = new RangeNode<float>(76f, 0.0f, 100.0f);
            GraceSize = new RangeNode<int>(64, 1, 128);
            GraceShowInactive = false;

            Clarity = true;
            ClarityX = new RangeNode<float>(17f, 0.0f, 100.0f);
            ClarityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            ClaritySize = new RangeNode<int>(64, 1, 128);
            ClarityShowInactive = false;

            #endregion

            #region Charges

            PowerCharges = true;
            PowerChargesX = new RangeNode<float>(13f, 0.0f, 100.0f);
            PowerChargesY = new RangeNode<float>(76f, 0.0f, 100.0f);
            PowerChargesSize = new RangeNode<int>(64, 1, 128);
            PowerChargesShowInactive = false;

            FrenzyCharges = true;
            FrenzyChargesX = new RangeNode<float>(13f, 0.0f, 100.0f);
            FrenzyChargesY = new RangeNode<float>(76f, 0.0f, 100.0f);
            FrenzyChargesSize = new RangeNode<int>(64, 1, 128);
            FrenzyChargesShowInactive = false;

            EnduranceCharges = true;
            EnduranceChargesX = new RangeNode<float>(13f, 0.0f, 100.0f);
            EnduranceChargesY = new RangeNode<float>(76f, 0.0f, 100.0f);
            EnduranceChargesSize = new RangeNode<int>(64, 1, 128);
            EnduranceChargesShowInactive = false;

            BladeVortexStacks = true;
            BladeVortexStacksX = new RangeNode<float>(13f, 0.0f, 100.0f);
            BladeVortexStacksY = new RangeNode<float>(76f, 0.0f, 100.0f);
            BladeVortexStacksSize = new RangeNode<int>(64, 1, 128);
            BladeVortexStacksShowInactive = false;
            BladeVortexStacksBurnedCharges = false;

            ReaveStacks = true;
            ReaveStacksX = new RangeNode<float>(13f, 0.0f, 100.0f);
            ReaveStacksY = new RangeNode<float>(76f, 0.0f, 100.0f);
            ReaveStacksSize = new RangeNode<int>(64, 1, 128);
            ReaveStacksShowInactive = false;
            ReaveStacksBurnedCharges = false;

            #endregion

            #region Curses

            CursePoachersMark = true;
            CursePoachersMarkX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CursePoachersMarkY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CursePoachersMarkSize = new RangeNode<int>(64, 1, 128);
            CursePoachersMarkShowInactive = false;

            CurseFrostbite = true;
            CurseFrostbiteX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseFrostbiteY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseFrostbiteSize = new RangeNode<int>(64, 1, 128);
            CurseFrostbiteShowInactive = false;

            CurseVulnerability = true;
            CurseVulnerabilityX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseVulnerabilityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseVulnerabilitySize = new RangeNode<int>(64, 1, 128);
            CurseVulnerabilityShowInactive = false;

            CurseWarlordsMark = true;
            CurseWarlordsMarkX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseWarlordsMarkY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseWarlordsMarkSize = new RangeNode<int>(64, 1, 128);
            CurseWarlordsMarkShowInactive = false;

            CurseFlammability = true;
            CurseFlammabilityX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseFlammabilityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseFlammabilitySize = new RangeNode<int>(64, 1, 128);
            CurseFlammabilityShowInactive = false;

            CurseAssassinsMark = true;
            CurseAssassinsMarkX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseAssassinsMarkY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseAssassinsMarkSize = new RangeNode<int>(64, 1, 128);
            CurseAssassinsMarkShowInactive = false;

            CurseElementalWeakness = true;
            CurseElementalWeaknessX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseElementalWeaknessY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseElementalWeaknessSize = new RangeNode<int>(64, 1, 128);
            CurseElementalWeaknessShowInactive = false;

            CurseConductivity = true;
            CurseConductivityX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseConductivityY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseConductivitySize = new RangeNode<int>(64, 1, 128);
            CurseConductivityShowInactive = false;

            CurseEnfeeble = true;
            CurseEnfeebleX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseEnfeebleY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseEnfeebleSize = new RangeNode<int>(64, 1, 128);
            CurseEnfeebleShowInactive = false;

            CursePunishment = true;
            CursePunishmentX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CursePunishmentY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CursePunishmentSize = new RangeNode<int>(64, 1, 128);
            CursePunishmentShowInactive = false;

            CurseProjectileWeakness = true;
            CurseProjectileWeaknessX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseProjectileWeaknessY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseProjectileWeaknessSize = new RangeNode<int>(64, 1, 128);
            CurseProjectileWeaknessShowInactive = false;

            CurseTemporalChains = true;
            CurseTemporalChainsX = new RangeNode<float>(13f, 0.0f, 100.0f);
            CurseTemporalChainsY = new RangeNode<float>(76f, 0.0f, 100.0f);
            CurseTemporalChainsSize = new RangeNode<int>(64, 1, 128);
            CurseTemporalChainsShowInactive = false;

            #endregion

            #region Leeching

            LeechingLife = true;
            LeechingLifeX = new RangeNode<float>(13f, 0.0f, 100.0f);
            LeechingLifeY = new RangeNode<float>(76f, 0.0f, 100.0f);
            LeechingLifeSize = new RangeNode<int>(64, 1, 128);
            LeechingLifeShowInactive = false;

            LeechingMana = true;
            LeechingManaX = new RangeNode<float>(13f, 0.0f, 100.0f);
            LeechingManaY = new RangeNode<float>(76f, 0.0f, 100.0f);
            LeechingManaSize = new RangeNode<int>(64, 1, 128);
            LeechingManaShowInactive = false;

            #endregion
        }

        [Menu("Force Icons On", 1)]
        public ToggleNode ForceIconsOn { get; set; }

        [Menu("Inactive Transparency")]
        public RangeNode<int> IconTransparency { get; set; }

        [Menu("Golems", 2)]
        public ToggleNode Golems { get; set; }

        [Menu("Offerings", 3)]
        public ToggleNode Offerings { get; set; }

        [Menu("Vaal Skills", 4)]
        public ToggleNode VaalSkills { get; set; }

        [Menu("Offensive Auras", 5)]
        public ToggleNode OffensiveAura { get; set; }

        [Menu("Defensive Auras", 6)]
        public ToggleNode DefenseiveAura { get; set; }

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
        public ToggleNode FireGolem { get; set; }

        [Menu("X", 1301, 130)]
        public RangeNode<float> FireGolemX { get; set; }

        [Menu("Y", 1302, 130)]
        public RangeNode<float> FireGolemY { get; set; }

        [Menu("Size", 1303, 130)]
        public RangeNode<int> FireGolemSize { get; set; }

        [Menu("Show Inactive", 1304, 130)]
        public ToggleNode FireGolemShowInactive { get; set; }

        [Menu("Ice Golem", 140, 2)]
        public ToggleNode IceGolem { get; set; }

        [Menu("X", 1401, 140)]
        public RangeNode<float> IceGolemX { get; set; }

        [Menu("Y", 1402, 140)]
        public RangeNode<float> IceGolemY { get; set; }

        [Menu("Size", 1403, 140)]
        public RangeNode<int> IceGolemSize { get; set; }

        [Menu("Show Inactive", 1404, 140)]
        public ToggleNode IceGolemShowInactive { get; set; }

        [Menu("Lightning Golem", 150, 2)]
        public ToggleNode LightningGolem { get; set; }

        [Menu("X", 1501, 150)]
        public RangeNode<float> LightningGolemX { get; set; }

        [Menu("Y", 1502, 150)]
        public RangeNode<float> LightningGolemY { get; set; }

        [Menu("Size", 1503, 150)]
        public RangeNode<int> LightningGolemSize { get; set; }

        [Menu("Show Inactive", 1504, 150)]
        public ToggleNode LightningGolemShowInactive { get; set; }

        [Menu("Chaos Golem", 160, 2)]
        public ToggleNode ChaosGolem { get; set; }

        [Menu("X", 1601, 160)]
        public RangeNode<float> ChaosGolemX { get; set; }

        [Menu("Y", 1602, 160)]
        public RangeNode<float> ChaosGolemY { get; set; }

        [Menu("Size", 1603, 160)]
        public RangeNode<int> ChaosGolemSize { get; set; }

        [Menu("Show Inactive", 1604, 160)]
        public ToggleNode ChaosGolemShowInactive { get; set; }

        [Menu("Stone Golem", 170, 2)]
        public ToggleNode StoneGolem { get; set; }

        [Menu("X", 1701, 170)]
        public RangeNode<float> StoneGolemX { get; set; }

        [Menu("Y", 1702, 170)]
        public RangeNode<float> StoneGolemY { get; set; }

        [Menu("Size", 1703, 170)]
        public RangeNode<int> StoneGolemSize { get; set; }

        [Menu("Show Inactive", 1704, 170)]
        public ToggleNode StoneGolemShowInactive { get; set; }

        #endregion

        #region Others

        #region Arcane Surge
        [Menu("Arcane Surge", 312, 7)]
        public ToggleNode ArcaneSurge { get; set; }

        [Menu("X", 3121, 312)]
        public RangeNode<float> ArcaneSurgeX { get; set; }

        [Menu("Y", 3122, 312)]
        public RangeNode<float> ArcaneSurgeY { get; set; }

        [Menu("Size", 3123, 312)]
        public RangeNode<int> ArcaneSurgeSize { get; set; }

        [Menu("Show Inactive", 3124, 312)]
        public ToggleNode ArcaneSurgeShowInactive { get; set; }
        #endregion

        #region Blood Rage
        [Menu("Blood Rage", 313, 7)]
        public ToggleNode BloodRage { get; set; }

        [Menu("X", 3131, 313)]
        public RangeNode<float> BloodRageX { get; set; }

        [Menu("Y", 3132, 313)]
        public RangeNode<float> BloodRageY { get; set; }

        [Menu("Size", 3133, 313)]
        public RangeNode<int> BloodRageSize { get; set; }

        [Menu("Show Inactive", 3134, 313)]
        public ToggleNode BloodRageShowInactive { get; set; }
        #endregion

        #region Elemental Overload
        [Menu("Elemental Overload", 315, 7)]
        public ToggleNode ElementalOverload { get; set; }

        [Menu("X", 3151, 315)]
        public RangeNode<float> ElementalOverloadX { get; set; }

        [Menu("Y", 3152, 315)]
        public RangeNode<float> ElementalOverloadY { get; set; }

        [Menu("Size", 3153, 315)]
        public RangeNode<int> ElementalOverloadSize { get; set; }

        [Menu("Show Inactive", 3154, 315)]
        public ToggleNode ElementalOverloadShowInactive { get; set; }
        #endregion
        
        #region Elemental Conflux
        [Menu("Elemental Conflux", 314, 7)]
        public ToggleNode ElementalConflux { get; set; }

        [Menu("X", 3141, 314)]
        public RangeNode<float> ElementalConfluxX { get; set; }

        [Menu("Y", 3142, 314)]
        public RangeNode<float> ElementalConfluxY { get; set; }

        [Menu("Size", 3143, 314)]
        public RangeNode<int> ElementalConfluxSize { get; set; }

        [Menu("Show Inactive", 3144, 314)]
        public ToggleNode ElementalConfluxShowInactive { get; set; }
        #endregion

        #region Fortify
        [Menu("Fortify", 316, 7)]
        public ToggleNode Fortify { get; set; }

        [Menu("X", 3161, 316)]
        public RangeNode<float> FortifyX { get; set; }

        [Menu("Y", 3162, 316)]
        public RangeNode<float> FortifyY { get; set; }

        [Menu("Size", 3163, 316)]
        public RangeNode<int> FortifySize { get; set; }

        [Menu("Show Inactive", 3164, 316)]
        public ToggleNode FortifyShowInactive { get; set; }
        #endregion

        #region Adrenaline
        [Menu("Adrenaline", 317, 7)]
        public ToggleNode Adrenaline { get; set; }

        [Menu("X", 3171, 317)]
        public RangeNode<float> AdrenalineX { get; set; }

        [Menu("Y", 3172, 317)]
        public RangeNode<float> AdrenalineY { get; set; }

        [Menu("Size", 3173, 317)]
        public RangeNode<int> AdrenalineSize { get; set; }

        [Menu("Show Inactive", 3174, 317)]
        public ToggleNode AdrenalineShowInactive { get; set; }
        #endregion

        #endregion

        #region Vaal Skills

        // Vaal Skills
        [Menu("Vaal Haste", 4562, 4)]
        public ToggleNode VaalHaste { get; set; }

        [Menu("X", 45621, 4562)]
        public RangeNode<float> VaalHasteX { get; set; }

        [Menu("Y", 45622, 4562)]
        public RangeNode<float> VaalHasteY { get; set; }

        [Menu("Size", 45623, 4562)]
        public RangeNode<int> VaalHasteSize { get; set; }

        [Menu("Show Inactive", 45624, 4562)]
        public ToggleNode VaalHasteShowInactive { get; set; }

        [Menu("Vaal Grace", 460, 4)]
        public ToggleNode VaalGrace { get; set; }

        [Menu("X", 4601, 460)]
        public RangeNode<float> VaalGraceX { get; set; }

        [Menu("Y", 4602, 460)]
        public RangeNode<float> VaalGraceY { get; set; }

        [Menu("Size", 4603, 460)]
        public RangeNode<int> VaalGraceSize { get; set; }

        [Menu("Show Inactive", 4604, 460)]
        public ToggleNode VaalGraceShowInactive { get; set; }

        [Menu("Vaal Clarity", 470, 4)]
        public ToggleNode VaalClarity { get; set; }

        [Menu("X", 4701, 470)]
        public RangeNode<float> VaalClarityX { get; set; }

        [Menu("Y", 4702, 470)]
        public RangeNode<float> VaalClarityY { get; set; }

        [Menu("Size", 4703, 470)]
        public RangeNode<int> VaalClaritySize { get; set; }

        [Menu("Show Inactive", 4704, 470)]
        public ToggleNode VaalClarityShowInactive { get; set; }

        [Menu("Vaal Discipline", 480, 4)]
        public ToggleNode VaalDiscipline { get; set; }

        [Menu("X", 4801, 480)]
        public RangeNode<float> VaalDisciplineX { get; set; }

        [Menu("Y", 4802, 480)]
        public RangeNode<float> VaalDisciplineY { get; set; }

        [Menu("Size", 4803, 480)]
        public RangeNode<int> VaalDisciplineSize { get; set; }

        [Menu("Show Inactive", 4804, 480)]
        public ToggleNode VaalDisciplineShowInactive { get; set; }

        #endregion

        #region Offerings

        // Offerings
        [Menu("Offering Effect", 120, 3)]
        public ToggleNode OfferingEffect { get; set; }

        [Menu("X", 1201, 120)]
        public RangeNode<float> OfferingEffectX { get; set; }

        [Menu("Y", 1202, 120)]
        public RangeNode<float> OfferingEffectY { get; set; }

        [Menu("Size", 1203, 120)]
        public RangeNode<int> OfferingEffectSize { get; set; }

        [Menu("Show Inactive", 1204, 120)]
        public ToggleNode OfferingEffectShowInactive { get; set; }

        #endregion

        #region Offensive Auras

        // Offensive Auras
        [Menu("Anger", 210, 5)]
        public ToggleNode Anger { get; set; }

        [Menu("X", 2101, 210)]
        public RangeNode<float> AngerX { get; set; }

        [Menu("Y", 2102, 210)]
        public RangeNode<float> AngerY { get; set; }

        [Menu("Size", 2103, 210)]
        public RangeNode<int> AngerSize { get; set; }

        [Menu("Show Inactive", 2104, 210)]
        public ToggleNode AngerShowInactive { get; set; }

        [Menu("Hatred", 229, 5)]
        public ToggleNode Hatred { get; set; }

        [Menu("X", 2291, 229)]
        public RangeNode<float> HatredX { get; set; }

        [Menu("Y", 2292, 229)]
        public RangeNode<float> HatredY { get; set; }

        [Menu("Size", 2293, 229)]
        public RangeNode<int> HatredSize { get; set; }

        [Menu("Show Inactive", 2294, 229)]
        public ToggleNode HatredShowInactive { get; set; }

        [Menu("Wrath", 230, 5)]
        public ToggleNode Wrath { get; set; }

        [Menu("X", 2301, 230)]
        public RangeNode<float> WrathX { get; set; }

        [Menu("Y", 2302, 230)]
        public RangeNode<float> WrathY { get; set; }

        [Menu("Size", 2303, 230)]
        public RangeNode<int> WrathSize { get; set; }

        [Menu("Show Inactive", 2304, 230)]
        public ToggleNode WrathShowInactive { get; set; }

        [Menu("Herald of Ash", 240, 5)]
        public ToggleNode HeraldOfAsh { get; set; }

        [Menu("X", 2401, 240)]
        public RangeNode<float> HeraldOfAshX { get; set; }

        [Menu("Y", 2402, 240)]
        public RangeNode<float> HeraldOfAshY { get; set; }

        [Menu("Size", 2403, 240)]
        public RangeNode<int> HeraldOfAshSize { get; set; }

        [Menu("Show Inactive", 2404, 240)]
        public ToggleNode HeraldOfAshShowInactive { get; set; }

        [Menu("Herald of Ice", 250, 5)]
        public ToggleNode HeraldOfIce { get; set; }

        [Menu("X", 2501, 250)]
        public RangeNode<float> HeraldOfIceX { get; set; }

        [Menu("Y", 2502, 250)]
        public RangeNode<float> HeraldOfIceY { get; set; }

        [Menu("Size", 2503, 250)]
        public RangeNode<int> HeraldOfIceSize { get; set; }

        [Menu("Show Inactive", 2504, 250)]
        public ToggleNode HeraldOfIceShowInactive { get; set; }

        [Menu("Herald of Thunder", 260, 5)]
        public ToggleNode HeraldOfThunder { get; set; }

        [Menu("X", 2601, 260)]
        public RangeNode<float> HeraldOfThunderX { get; set; }

        [Menu("Y", 2602, 260)]
        public RangeNode<float> HeraldOfThunderY { get; set; }

        [Menu("Size", 2603, 260)]
        public RangeNode<int> HeraldOfThunderSize { get; set; }

        [Menu("Show Inactive", 2604, 260)]
        public ToggleNode HeraldOfThunderShowInactive { get; set; }

        [Menu("Haste", 270, 5)]
        public ToggleNode Haste { get; set; }

        [Menu("X", 2701, 270)]
        public RangeNode<float> HasteX { get; set; }

        [Menu("Y", 2702, 270)]
        public RangeNode<float> HasteY { get; set; }

        [Menu("Size", 2703, 270)]
        public RangeNode<int> HasteSize { get; set; }

        [Menu("Show Inactive", 2704, 270)]
        public ToggleNode HasteShowInactive { get; set; }

        #endregion

        #region Defensive Auras

        // Defensive Auras
        [Menu("Purity of Fire", 310, 6)]
        public ToggleNode PurityOfFire { get; set; }

        [Menu("X", 3101, 310)]
        public RangeNode<float> PurityOfFireX { get; set; }

        [Menu("Y", 3102, 310)]
        public RangeNode<float> PurityOfFireY { get; set; }

        [Menu("Size", 3103, 310)]
        public RangeNode<int> PurityOfFireSize { get; set; }

        [Menu("Show Inactive", 3104, 310)]
        public ToggleNode PurityOfFireShowInactive { get; set; }

        [Menu("Purity of Ice", 320, 6)]
        public ToggleNode PurityOfIce { get; set; }

        [Menu("X", 3201, 320)]
        public RangeNode<float> PurityOfIceX { get; set; }

        [Menu("Y", 3202, 320)]
        public RangeNode<float> PurityOfIceY { get; set; }

        [Menu("Size", 3203, 320)]
        public RangeNode<int> PurityOfIceSize { get; set; }

        [Menu("Show Inactive", 3204, 320)]
        public ToggleNode PurityOfIceShowInactive { get; set; }

        [Menu("Purity of Lightning", 330, 6)]
        public ToggleNode PurityOfLightning { get; set; }

        [Menu("X", 3301, 330)]
        public RangeNode<float> PurityOfLightningX { get; set; }

        [Menu("Y", 3302, 330)]
        public RangeNode<float> PurityOfLightningY { get; set; }

        [Menu("Size", 3303, 330)]
        public RangeNode<int> PurityOfLightningSize { get; set; }

        [Menu("Show Inactive", 3304, 330)]
        public ToggleNode PurityOfLightningShowInactive { get; set; }

        [Menu("Purity of Elements", 340, 6)]
        public ToggleNode PurityOfElements { get; set; }

        [Menu("X", 3401, 340)]
        public RangeNode<float> PurityOfElementsX { get; set; }

        [Menu("Y", 3402, 340)]
        public RangeNode<float> PurityOfElementsY { get; set; }

        [Menu("Size", 3403, 340)]
        public RangeNode<int> PurityOfElementsSize { get; set; }

        [Menu("Show Inactive", 3404, 340)]
        public ToggleNode PurityOfElementsShowInactive { get; set; }

        [Menu("Vitality", 350, 6)]
        public ToggleNode Vitality { get; set; }

        [Menu("X", 3501, 350)]
        public RangeNode<float> VitalityX { get; set; }

        [Menu("Y", 3502, 350)]
        public RangeNode<float> VitalityY { get; set; }

        [Menu("Size", 3503, 350)]
        public RangeNode<int> VitalitySize { get; set; }

        [Menu("Show Inactive", 3504, 350)]
        public ToggleNode VitalityShowInactive { get; set; }

        [Menu("Discipline", 360, 6)]
        public ToggleNode Discipline { get; set; }

        [Menu("X", 3601, 360)]
        public RangeNode<float> DisciplineX { get; set; }

        [Menu("Y", 3602, 360)]
        public RangeNode<float> DisciplineY { get; set; }

        [Menu("Size", 3603, 360)]
        public RangeNode<int> DisciplineSize { get; set; }

        [Menu("Show Inactive", 3604, 360)]
        public ToggleNode DisciplineShowInactive { get; set; }

        [Menu("Determination", 370, 6)]
        public ToggleNode Determination { get; set; }

        [Menu("X", 3701, 370)]
        public RangeNode<float> DeterminationX { get; set; }

        [Menu("Y", 3702, 370)]
        public RangeNode<float> DeterminationY { get; set; }

        [Menu("Size", 3703, 370)]
        public RangeNode<int> DeterminationSize { get; set; }

        [Menu("Show Inactive", 3704, 370)]
        public ToggleNode DeterminationShowInactive { get; set; }

        [Menu("Grace", 380, 6)]
        public ToggleNode Grace { get; set; }

        [Menu("X", 3801, 380)]
        public RangeNode<float> GraceX { get; set; }

        [Menu("Y", 3802, 380)]
        public RangeNode<float> GraceY { get; set; }

        [Menu("Size", 3803, 380)]
        public RangeNode<int> GraceSize { get; set; }

        [Menu("Show Inactive", 3804, 380)]
        public ToggleNode GraceShowInactive { get; set; }

        [Menu("Clarity", 390, 6)]
        public ToggleNode Clarity { get; set; }

        [Menu("X", 3901, 390)]
        public RangeNode<float> ClarityX { get; set; }

        [Menu("Y", 3902, 390)]
        public RangeNode<float> ClarityY { get; set; }

        [Menu("Size", 3903, 390)]
        public RangeNode<int> ClaritySize { get; set; }

        [Menu("Show Inactive", 3904, 390)]
        public ToggleNode ClarityShowInactive { get; set; }

        #endregion

        #region Charges

        // Charges
        [Menu("Power Charges", 510, 8)]
        public ToggleNode PowerCharges { get; set; }

        [Menu("X", 5101, 510)]
        public RangeNode<float> PowerChargesX { get; set; }

        [Menu("Y", 5102, 510)]
        public RangeNode<float> PowerChargesY { get; set; }

        [Menu("Size", 5103, 510)]
        public RangeNode<int> PowerChargesSize { get; set; }

        [Menu("Show Inactive", 5104, 510)]
        public ToggleNode PowerChargesShowInactive { get; set; }

        [Menu("Frenzy Charges", 520, 8)]
        public ToggleNode FrenzyCharges { get; set; }

        [Menu("X", 5201, 520)]
        public RangeNode<float> FrenzyChargesX { get; set; }

        [Menu("Y", 5202, 520)]
        public RangeNode<float> FrenzyChargesY { get; set; }

        [Menu("Size", 5203, 520)]
        public RangeNode<int> FrenzyChargesSize { get; set; }

        [Menu("Show Inactive", 5204, 520)]
        public ToggleNode FrenzyChargesShowInactive { get; set; }

        [Menu("Endurance Charges", 530, 8)]
        public ToggleNode EnduranceCharges { get; set; }

        [Menu("X", 5301, 530)]
        public RangeNode<float> EnduranceChargesX { get; set; }

        [Menu("Y", 5302, 530)]
        public RangeNode<float> EnduranceChargesY { get; set; }

        [Menu("Size", 5303, 530)]
        public RangeNode<int> EnduranceChargesSize { get; set; }

        [Menu("Show Inactive", 5304, 530)]
        public ToggleNode EnduranceChargesShowInactive { get; set; }

        [Menu("Blade Vortex Stacks", 540, 8)]
        public ToggleNode BladeVortexStacks { get; set; }

        [Menu("X", 5401, 540)]
        public RangeNode<float> BladeVortexStacksX { get; set; }

        [Menu("Y", 5402, 540)]
        public RangeNode<float> BladeVortexStacksY { get; set; }

        [Menu("Size", 5403, 540)]
        public RangeNode<int> BladeVortexStacksSize { get; set; }

        [Menu("Show Inactive", 5404, 540)]
        public ToggleNode BladeVortexStacksShowInactive { get; set; }

        [Menu("Charges Above Icon", 5405, 540)]
        public ToggleNode BladeVortexStacksBurnedCharges { get; set; }

        [Menu("Reave Stacks", 550, 8)]
        public ToggleNode ReaveStacks { get; set; }

        [Menu("X", 5501, 550)]
        public RangeNode<float> ReaveStacksX { get; set; }

        [Menu("Y", 5502, 550)]
        public RangeNode<float> ReaveStacksY { get; set; }

        [Menu("Size", 5503, 550)]
        public RangeNode<int> ReaveStacksSize { get; set; }

        [Menu("Show Inactive", 5504, 550)]
        public ToggleNode ReaveStacksShowInactive { get; set; }

        [Menu("Charges Above Icon", 5505, 550)]
        public ToggleNode ReaveStacksBurnedCharges { get; set; }

        #endregion

        #region Curses

        [Menu("Poacher's Mark", 610, 1000)]
        public ToggleNode CursePoachersMark { get; set; }

        [Menu("X", 6101, 610)]
        public RangeNode<float> CursePoachersMarkX { get; set; }

        [Menu("Y", 6102, 610)]
        public RangeNode<float> CursePoachersMarkY { get; set; }

        [Menu("Size", 6103, 610)]
        public RangeNode<int> CursePoachersMarkSize { get; set; }

        [Menu("Show Inactive", 6104, 610)]
        public ToggleNode CursePoachersMarkShowInactive { get; set; }

        [Menu("Frostbite", 620, 1000)]
        public ToggleNode CurseFrostbite { get; set; }

        [Menu("X", 6201, 620)]
        public RangeNode<float> CurseFrostbiteX { get; set; }

        [Menu("Y", 6202, 620)]
        public RangeNode<float> CurseFrostbiteY { get; set; }

        [Menu("Size", 6203, 620)]
        public RangeNode<int> CurseFrostbiteSize { get; set; }

        [Menu("Show Inactive", 6204, 620)]
        public ToggleNode CurseFrostbiteShowInactive { get; set; }

        [Menu("Vulnerability", 630, 1000)]
        public ToggleNode CurseVulnerability { get; set; }

        [Menu("X", 6301, 630)]
        public RangeNode<float> CurseVulnerabilityX { get; set; }

        [Menu("Y", 6302, 630)]
        public RangeNode<float> CurseVulnerabilityY { get; set; }

        [Menu("Size", 6303, 630)]
        public RangeNode<int> CurseVulnerabilitySize { get; set; }

        [Menu("Show Inactive", 6304, 630)]
        public ToggleNode CurseVulnerabilityShowInactive { get; set; }

        [Menu("Warlord's Mark", 640, 1000)]
        public ToggleNode CurseWarlordsMark { get; set; }

        [Menu("X", 6401, 640)]
        public RangeNode<float> CurseWarlordsMarkX { get; set; }

        [Menu("Y", 6402, 640)]
        public RangeNode<float> CurseWarlordsMarkY { get; set; }

        [Menu("Size", 6403, 640)]
        public RangeNode<int> CurseWarlordsMarkSize { get; set; }

        [Menu("Show Inactive", 6404, 640)]
        public ToggleNode CurseWarlordsMarkShowInactive { get; set; }

        [Menu("Flammability", 650, 1000)]
        public ToggleNode CurseFlammability { get; set; }

        [Menu("X", 6501, 650)]
        public RangeNode<float> CurseFlammabilityX { get; set; }

        [Menu("Y", 6502, 650)]
        public RangeNode<float> CurseFlammabilityY { get; set; }

        [Menu("Size", 6503, 650)]
        public RangeNode<int> CurseFlammabilitySize { get; set; }

        [Menu("Show Inactive", 6504, 650)]
        public ToggleNode CurseFlammabilityShowInactive { get; set; }

        [Menu("Assassin's Mark", 660, 1000)]
        public ToggleNode CurseAssassinsMark { get; set; }

        [Menu("X", 6601, 660)]
        public RangeNode<float> CurseAssassinsMarkX { get; set; }

        [Menu("Y", 6602, 660)]
        public RangeNode<float> CurseAssassinsMarkY { get; set; }

        [Menu("Size", 6603, 660)]
        public RangeNode<int> CurseAssassinsMarkSize { get; set; }

        [Menu("Show Inactive", 6604, 660)]
        public ToggleNode CurseAssassinsMarkShowInactive { get; set; }

        [Menu("Elemental Weakness", 670, 1000)]
        public ToggleNode CurseElementalWeakness { get; set; }

        [Menu("X", 6701, 670)]
        public RangeNode<float> CurseElementalWeaknessX { get; set; }

        [Menu("Y", 6702, 670)]
        public RangeNode<float> CurseElementalWeaknessY { get; set; }

        [Menu("Size", 6703, 670)]
        public RangeNode<int> CurseElementalWeaknessSize { get; set; }

        [Menu("Show Inactive", 6704, 670)]
        public ToggleNode CurseElementalWeaknessShowInactive { get; set; }

        [Menu("Conductivity", 680, 1000)]
        public ToggleNode CurseConductivity { get; set; }

        [Menu("X", 6801, 680)]
        public RangeNode<float> CurseConductivityX { get; set; }

        [Menu("Y", 6802, 680)]
        public RangeNode<float> CurseConductivityY { get; set; }

        [Menu("Size", 6803, 680)]
        public RangeNode<int> CurseConductivitySize { get; set; }

        [Menu("Show Inactive", 6804, 680)]
        public ToggleNode CurseConductivityShowInactive { get; set; }

        [Menu("Enfeeble", 690, 1000)]
        public ToggleNode CurseEnfeeble { get; set; }

        [Menu("X", 6901, 690)]
        public RangeNode<float> CurseEnfeebleX { get; set; }

        [Menu("Y", 6902, 690)]
        public RangeNode<float> CurseEnfeebleY { get; set; }

        [Menu("Size", 6903, 690)]
        public RangeNode<int> CurseEnfeebleSize { get; set; }

        [Menu("Show Inactive", 6904, 690)]
        public ToggleNode CurseEnfeebleShowInactive { get; set; }

        [Menu("Punishment", 6010, 1000)]
        public ToggleNode CursePunishment { get; set; }

        [Menu("X", 60101, 6010)]
        public RangeNode<float> CursePunishmentX { get; set; }

        [Menu("Y", 60102, 6010)]
        public RangeNode<float> CursePunishmentY { get; set; }

        [Menu("Size", 60103, 6010)]
        public RangeNode<int> CursePunishmentSize { get; set; }

        [Menu("Show Inactive", 60104, 6010)]
        public ToggleNode CursePunishmentShowInactive { get; set; }

        [Menu("Projectile Weakness", 6011, 1000)]
        public ToggleNode CurseProjectileWeakness { get; set; }

        [Menu("X", 60111, 6011)]
        public RangeNode<float> CurseProjectileWeaknessX { get; set; }

        [Menu("Y", 60112, 6011)]
        public RangeNode<float> CurseProjectileWeaknessY { get; set; }

        [Menu("Size", 60113, 6011)]
        public RangeNode<int> CurseProjectileWeaknessSize { get; set; }

        [Menu("Show Inactive", 60114, 6011)]
        public ToggleNode CurseProjectileWeaknessShowInactive { get; set; }

        [Menu("Temporal Chains", 6012, 1000)]
        public ToggleNode CurseTemporalChains { get; set; }

        [Menu("X", 60121, 6012)]
        public RangeNode<float> CurseTemporalChainsX { get; set; }

        [Menu("Y", 60122, 6012)]
        public RangeNode<float> CurseTemporalChainsY { get; set; }

        [Menu("Size", 60123, 6012)]
        public RangeNode<int> CurseTemporalChainsSize { get; set; }

        [Menu("Show Inactive", 60124, 6012)]
        public ToggleNode CurseTemporalChainsShowInactive { get; set; }

        #endregion

        #region Leeching

        // Leeching
        [Menu("Leeching Life", 710, 9)]
        public ToggleNode LeechingLife { get; set; }

        [Menu("X", 7101, 710)]
        public RangeNode<float> LeechingLifeX { get; set; }

        [Menu("Y", 7102, 710)]
        public RangeNode<float> LeechingLifeY { get; set; }

        [Menu("Size", 7103, 710)]
        public RangeNode<int> LeechingLifeSize { get; set; }

        [Menu("Show Inactive", 7104, 710)]
        public ToggleNode LeechingLifeShowInactive { get; set; }

        [Menu("Leeching Mana", 720, 9)]
        public ToggleNode LeechingMana { get; set; }

        [Menu("X", 7201, 720)]
        public RangeNode<float> LeechingManaX { get; set; }

        [Menu("Y", 7202, 720)]
        public RangeNode<float> LeechingManaY { get; set; }

        [Menu("Size", 7203, 720)]
        public RangeNode<int> LeechingManaSize { get; set; }

        [Menu("Show Inactive", 7204, 720)]
        public ToggleNode LeechingManaShowInactive { get; set; }

        #endregion
    }
}