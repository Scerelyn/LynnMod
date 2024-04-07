using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Rube_Clarity : PassiveAbilityBase
    {
        public static string Name = "Clarity";
        public static string Desc = "If this character has no status effects, gain +3 Dice power. If the target has no statuses, inflict double damage";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior?.card?.target;
            if (target != null)
            {
                if (!target.bufListDetail.GetActivatedBufList().Any())
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus()
                    {
                        dmgRate = 200
                    });
                }
            }
            if (!owner.bufListDetail.GetActivatedBufList().Any())
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = 3
                });
            }
        }
    }
}
