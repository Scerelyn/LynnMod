using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Akao_PainTransfer : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Copy all current ailments to next turn";

        public override void OnWinParrying()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                List<BattleUnitBuf> ailments = target.bufListDetail.GetActivatedBufList().Where(b => b.positiveType == BufPositiveType.Negative).ToList();
                foreach(BattleUnitBuf battleUnitBuf in ailments)
                {
                    target.bufListDetail.AddKeywordBufByCard(battleUnitBuf.bufType, battleUnitBuf.stack, target);
                }
                
            }
        }
    }
}
