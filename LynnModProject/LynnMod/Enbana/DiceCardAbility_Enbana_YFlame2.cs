using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Enbana_YFlame2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 3 Yellow Spark next Scene";

        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target != null)
            {
                BattleUnitBuf yellow = target.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Enbana_YellowFlame);
                if (yellow == null)
                {
                    yellow = new BattleUnitBuf_Enbana_YellowFlame();
                    target.bufListDetail.AddBuf(yellow);
                }
                yellow.stack += 3;
            }
        }
    }
}
