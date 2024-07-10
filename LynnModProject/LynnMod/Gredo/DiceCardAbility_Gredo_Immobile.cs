using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Gredo_Immobile : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 1 Immobilize next Scene";

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Stun, 1, owner);
        }
    }
}
