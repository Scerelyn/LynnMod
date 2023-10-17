using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Lynn_ParaShock3 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Paralysis to each other next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 2, base.owner);
            }
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 2, base.owner);
        }
    }
}
