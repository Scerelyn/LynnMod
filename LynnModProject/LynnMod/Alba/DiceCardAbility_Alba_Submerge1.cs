using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Alba_Submerge1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Submerge next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf submerge = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Submerge);
                if (submerge == null)
                {
                    submerge = new BattleUnitBuf_Alba_Submerge();
                    target.bufListDetail.AddReadyBuf(submerge);
                }
                submerge.stack++;
            }
        }
    }
}
