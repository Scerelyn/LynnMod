using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Gredo_GravLens1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 1 Umbral Lens next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf lensBuff = target.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Gredo_GravLens);
                if (lensBuff == null)
                {
                    lensBuff = new BattleUnitBuf_Gredo_GravLens();
                    target.bufListDetail.AddBuf(lensBuff);
                }
                lensBuff.stack++;
            }

        }
    }
}
