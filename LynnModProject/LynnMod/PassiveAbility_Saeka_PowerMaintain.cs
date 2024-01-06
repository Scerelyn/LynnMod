using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Saeka_PowerMaintain : PassiveAbilityBase
    {
        public static string Name = "Built Strength";
        public static string Desc = "On turn end, keep stacks of Strength, Endurance, and Haste on the next turn (max 5).";
        public int buffMax = 5;
        public override void OnRoundEnd()
        {
            Dictionary<KeywordBuf, BattleUnitBuf> buffs = owner.bufListDetail.GetActivatedBufList()
                .Where(b => b.bufType == KeywordBuf.Strength || b.bufType == KeywordBuf.Endurance || b.bufType == KeywordBuf.Quickness)
                .ToDictionary(b => b.bufType, b => b);

            foreach(KeywordBuf key in buffs.Keys)
            {
                switch (key)
                {
                    case KeywordBuf.Strength:
                    case KeywordBuf.Endurance:
                    case KeywordBuf.Quickness:
                        owner.bufListDetail.AddKeywordBufByEtc(key, Math.Min(buffs[key].stack, buffMax));
                        break;
                }
            }
        }
    }
}
