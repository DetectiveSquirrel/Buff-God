using System;
using System.Collections.Generic;
using System.Linq;
using PoeHUD.Poe.RemoteMemoryObjects;

namespace Buff_God
{
    public partial class Core
    {
        public List<Buff> SearchForBuffs(Structs.Buff.Base wantedBuff, List<Buff> currentBuffs)
        {
            return currentBuffs.Where(buff =>
                string.Equals(buff.Name, wantedBuff.Settings.BuffName, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
    }
}