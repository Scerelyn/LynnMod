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
            int staggerProtection = this.owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.BreakProtection)?.stack ?? 0;
            this.owner.TakeBreakDamage(Math.Max(20 - staggerProtection, 0), DamageType.Card_Ability);
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
