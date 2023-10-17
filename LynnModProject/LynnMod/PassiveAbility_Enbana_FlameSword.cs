using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Enbana_FlameSword : PassiveAbilityBase
    {
        public static string Name = "Sword of Flame";
        public static string Desc = "Attacks deal 60% damage and give Burn equivalent to damage";

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior?.card?.target;
            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, behavior.DiceResultDamage, base.owner);
            }
        }

        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = -40,
                breakRate = -40
            });
        }
    }
}
