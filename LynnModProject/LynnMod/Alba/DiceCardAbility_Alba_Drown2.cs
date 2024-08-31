using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Alba_Drown2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 3 Drowning next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf drown = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Drowning);
                if (drown == null)
                {
                    drown = new BattleUnitBuf_Alba_Drowning();
                    target.bufListDetail.AddReadyBuf(drown);
                }
                drown.stack += 3;
            }
        }
    }
}
