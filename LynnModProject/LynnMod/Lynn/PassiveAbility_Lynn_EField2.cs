using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Lynn_EField2 : PassiveAbilityBase
    {
        public static string Name = "E Field Enhancement";
        public static string Desc = "When inflicted with Paralysis, gain 1 dice power per 3 stacks";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitBuf para = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Paralysis);
            if (para != null)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = para.stack / 3
                });
            }
        }
    }
}
