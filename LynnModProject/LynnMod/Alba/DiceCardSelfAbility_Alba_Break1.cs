using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Alba_Break1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 1 Submerge next Scene";

        public override void OnUseCard()
        {
            BattleUnitBuf submerge = owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Submerge);
            if (submerge == null)
            {
                submerge = new BattleUnitBuf_Alba_Submerge();
                owner.bufListDetail.AddReadyBuf(submerge);
            }
            submerge.stack++;
        }
    }
}
