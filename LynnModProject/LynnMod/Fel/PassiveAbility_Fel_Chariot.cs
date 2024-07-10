using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Fel_Chariot : PassiveAbilityBase
    {
        private static int _strengthLimit = 5;
        private static int _weakLimit = 5;
        public static string Name = "Chariot";
        public static string Desc = "On clash win, gain 1 Strength (max 5). On clash lose, gain 1 Feeble (max 5)";

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            bool isStrengthBelowLimit = (owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Strength)?.stack ?? 0) < _strengthLimit;
            if (isStrengthBelowLimit)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 1);
            }
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            bool isWeakBelowLimit = (owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Weak)?.stack ?? 0) < _weakLimit;
            if (isWeakBelowLimit)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 1);
            }
        }
    }
}
