using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Enbana_FlamePurge : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Remove all Burn on self, gain +1 Strength per 5 Burn removed next turn";

        public override void OnWinParrying()
        {
            BattleUnitBuf burn = owner.bufListDetail.GetActivatedBufList().Find(b => b.bufType == KeywordBuf.Burn);
            if(burn != null)
            {
                int strengthCount = burn.stack / 5;
                owner.bufListDetail.RemoveBuf(burn);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, strengthCount);
            }
        }
    }
}
