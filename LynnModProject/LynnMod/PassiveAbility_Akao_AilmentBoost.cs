using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Akao_AilmentBoost : PassiveAbilityBase
    {
        public static string Name = "Seven Colored Melody";
        public static string Desc = "Dice gain 1 power per unique negative ailment on target";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior?.card?.target;
            
            if (target != null)
            {
                int ailmentCount = target.bufListDetail.GetActivatedBufList().Count(b => b.positiveType == BufPositiveType.Negative);
            
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = ailmentCount
                });
            }
        }
    }
}
