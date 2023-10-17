using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Lynn_ParaShock1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Lose] Inflict 2 Paralysis next Scene";

        public override void OnLoseParrying()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 2, base.owner);
            }
        }
    }
}
