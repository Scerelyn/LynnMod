using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Lynn_HardShock2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Deal 5 bonus damage per stack of Paralysis on target";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                int paraCount = target.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Paralysis)?.stack ?? 0;
                if (paraCount > 0)
                {
                    target.TakeDamage(5 * paraCount);
                }
            }
        }
    }
}
