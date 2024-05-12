using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Rube_Dust2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Crimson Dust";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf dust = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Rube_Dust);
                if (dust == null)
                {
                    dust = new BattleUnitBuf_Rube_Dust();
                    target.bufListDetail.AddBuf(dust);
                }
                dust.stack += 2;
            }
        }
    }
}
