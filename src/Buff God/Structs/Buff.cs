using System;
using System.Collections.Generic;
using System.Linq;

namespace Buff_God.Structs
{
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

            public DisposableData DisposableData { get; set; } =
                new DisposableData(); // Data that gets used every render and has no use to be kept
        }

        public class Settings
        {
            public string BuffName { get; set; } // BuffName of the buff - "new_new_blade_vortex"
            public string Image { get; set; } // File BuffName
            public bool Enabled { get; set; } // Is this buff enabled?
            public bool Show { get; set; } // Show the buff
            public bool ShowImage { get; set; } = true; // Draw An Image
            public int Size { get; set; }
            public Location Location { get; set; }
            public bool ShowInactive { get; set; }
            public BuffType Type { get; set; } // set type of buff type to apply correct logic
            public Colors Colors { get; set; } = new Colors();
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
                    Duration = (int) Math.Ceiling(buffList.FirstOrDefault().Timer);
                    MaxDuration = (int) Math.Ceiling(buffList.FirstOrDefault().MaxTime);
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