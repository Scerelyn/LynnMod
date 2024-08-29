using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Alba_Flood1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Flooded next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf drown = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Flooded);
                if (drown == null)
                {
                    drown = new BattleUnitBuf_Alba_Flooded();
                    target.bufListDetail.AddBuf(drown);
                }
                drown.stack++;
            }
        }
    }
}
