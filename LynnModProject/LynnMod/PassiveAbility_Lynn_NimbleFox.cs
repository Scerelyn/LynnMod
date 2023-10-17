using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Lynn_NimbleFox : PassiveAbilityBase
    {
        public static string Name = "Nimble Fox";
        public static string Desc = "Evade Dice gain +2 power, Block Dice lose -2 power";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            var isEvade = behavior.Detail == LOR_DiceSystem.BehaviourDetail.Evasion;
            var isBlock = behavior.Detail == LOR_DiceSystem.BehaviourDetail.Guard;
            if (isEvade)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = 2
                });
            }
            if (isBlock)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = -2
                });
            }
        }
    }
}
