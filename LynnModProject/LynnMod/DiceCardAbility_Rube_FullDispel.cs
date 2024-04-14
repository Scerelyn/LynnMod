using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Rube_FullDispel : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Dispel all status effects on target, and inflict bonus damage equal to the sum of all stacks of all effects on target and user";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            int bonusDamage = 0;
            if (target != null)
            {
                for(int i = target.bufListDetail.GetActivatedBufList().Count -1; i >= 0;  i--)
                {
                    BattleUnitBuf buff = target.bufListDetail.GetActivatedBufList()[i];
                    bonusDamage += buff.stack;
                    target.bufListDetail.RemoveBuf(buff);
                }
                if (owner.bufListDetail.GetActivatedBufList().Any())
                {
                    bonusDamage += owner.bufListDetail.GetActivatedBufList().Sum(b => b.stack);
                }
                target.TakeDamage(bonusDamage);
            }
        }
    }
}
