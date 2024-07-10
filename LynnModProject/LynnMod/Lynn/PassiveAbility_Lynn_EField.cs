using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Lynn_EField : PassiveAbilityBase
    {
        public static string Name = "E Field Manipulation";
        public static string Desc = "When inflicted with Paralysis, gain 3 to max roll instead";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitBuf para = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Paralysis);
            if (para != null)
            {
                
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    max = behavior.GetDiceMax() == behavior.GetDiceVanillaMax() - 3 ? 6 : 3
                });
            }
        }
    }
}
