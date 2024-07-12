using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Citri_LoseBreak2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Lose 20 Stagger Resist. Dice on this page gain +4 power.";

        public override void OnUseCard()
        {
            this.owner.TakeBreakDamage(20, DamageType.Card_Ability);
        }

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = 4
            });
        }
    }
}
