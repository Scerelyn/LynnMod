using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Fel_OpenShot : PassiveAbilityBase
    {
        public static string Name = "Open Shot";
        public static string Desc = "One sided attacks deal 50% extra damage";
        
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            if (!behavior.IsParrying())
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = 50
                });
            }
        }
    }
}
