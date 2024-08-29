using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Alba_Break2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 2 Seal next Scene";

        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Seal, 2, owner);
        }
    }
}
