using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Enbana_BFlame1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Inflict 1 Blue Flame";

        public override void OnWinParrying()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf blue = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Enbana_BlueFlame);
                if (blue == null)
                {
                    blue = new BattleUnitBuf_Enbana_BlueFlame();
                    target.bufListDetail.AddBuf(blue);
                }
                blue.stack += 1;
            }
        }
    }
}
