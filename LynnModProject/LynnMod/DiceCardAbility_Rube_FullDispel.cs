using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Rube_FullDispel : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Dispel all status effects on self and target, and inflict bonus damage equal to the sum of all stacks of all effects on target and self";

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
                for (int i = owner.bufListDetail.GetActivatedBufList().Count - 1; i >= 0; i--)
                {
                    BattleUnitBuf buff = owner.bufListDetail.GetActivatedBufList()[i];
                    bonusDamage += buff.stack;
                    owner.bufListDetail.RemoveBuf(buff);
                }
                target.TakeDamage(bonusDamage);
            }
        }
    }
}
