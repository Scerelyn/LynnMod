using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Enbana_HealingFlame : PassiveAbilityBase
    {
        public static string Name = "Burning Invigoration";
        public static string Desc = "On Clash Win, heal by 20% of Burn on self";

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            BattleUnitBuf burn = owner.bufListDetail.GetActivatedBufList().Find(b => b.bufType == KeywordBuf.Burn);
            if (burn != null)
            {
                owner.RecoverHP(burn.stack / 5);
            }
        }
    }
}
