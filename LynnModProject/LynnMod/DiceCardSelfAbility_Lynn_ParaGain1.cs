using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Lynn_ParaGain1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Combat Start] Gain 3 Paralysis";

        public override void OnStartBattle()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Paralysis, 3);
        }
    }
}
