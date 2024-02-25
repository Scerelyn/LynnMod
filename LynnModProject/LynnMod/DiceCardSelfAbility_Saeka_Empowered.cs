using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Saeka_Empowered : DiceCardSelfAbilityBase
    {
        public static string Desc = "Dice on this page lose 12 power. Each unique buff on user gives 1 additional dice power.";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = -12 + behavior.owner.bufListDetail.GetActivatedBufList().Count(b => b.positiveType == BufPositiveType.Positive)
            });
        }
    }
}
