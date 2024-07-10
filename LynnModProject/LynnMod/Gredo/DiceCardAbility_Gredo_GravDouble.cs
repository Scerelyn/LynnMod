using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Gredo_GravDouble : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Double the amount of Umbral Lens on target";

        public override void OnWinParrying()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf lensBuff = target.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Gredo_GravLens);
                if (lensBuff != null)
                {
                    lensBuff.stack *= 2;
                }
            }
        }
    }
}
