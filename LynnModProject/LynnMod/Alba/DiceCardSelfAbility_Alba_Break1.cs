using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Alba_Break1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 1 Seal next Scene";

        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Seal, 1, owner);
        }
    }
}
