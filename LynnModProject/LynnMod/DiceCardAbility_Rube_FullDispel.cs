using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Rube_FullDispel : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Burst Crimson Dust, and clear all statuses on self";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            int bonusDamage = 0;
            int dustMult = 1;
            if (target != null)
            {
                BattleUnitBuf dustBuff = target.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Rube_Dust);
                if (dustBuff != null)
                {
                    dustMult = dustBuff.stack;
                    for (int i = target.bufListDetail.GetActivatedBufList().Count -1; i >= 0;  i--)
                    {
                        BattleUnitBuf buff = target.bufListDetail.GetActivatedBufList()[i];
                        bonusDamage++;
                        target.bufListDetail.RemoveBuf(buff);
                    }
                }
                for (int i = owner.bufListDetail.GetActivatedBufList().Count - 1; i >= 0; i--)
                {
                    BattleUnitBuf buff = owner.bufListDetail.GetActivatedBufList()[i];
                    owner.bufListDetail.RemoveBuf(buff);
                }
                if (bonusDamage > 0)
                {
                    target.TakeDamage(bonusDamage * dustMult);
                }
            }
        }
    }
}
