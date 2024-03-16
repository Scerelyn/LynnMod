using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Gredo_StarBurst : PassiveAbilityBase
    {
        public static string Name = "Star Burst";
        public static string Desc = "When staggered, gain 3 Penumbric";

        private readonly int penBufSize = 3;

        public override void OnBreakState()
        {
            BattleUnitBuf_Gredo_Penumbric penBuf = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Gredo_Penumbric) as BattleUnitBuf_Gredo_Penumbric;
            if (penBuf == null)
            {
                penBuf = new BattleUnitBuf_Gredo_Penumbric();
                owner.bufListDetail.AddBuf(penBuf);
            }
            penBuf.stack += penBufSize;
        }
    }
}
