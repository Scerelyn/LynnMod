using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Enbana_FlameProc : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Combat Start] Winning clashes causes burn to deal damage this round";

        public override void OnStartBattle()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_Enbana_FlameProcBuf());
        }
        
        public class BattleUnitBuf_Enbana_FlameProcBuf : BattleUnitBuf
        {
            public override void OnWinParrying(BattleDiceBehavior behavior)
            {
                BattleUnitModel target = behavior.card.target;
                if (target != null)
                {
                    int burnCount = target.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Burn)?.stack ?? 0;
                    if (stack > 0)
                    {
                        target.TakeDamage(burnCount);
                    }
                }
            }

            public override void OnRoundEnd()
            {
                Destroy();
            }
        }
    }
}
