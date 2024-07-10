using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Enbana_FlameHeal : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Remove all Burn on self and gain HP equal to burn removed";

        public override void OnWinParrying()
        {
            BattleUnitBuf burn = owner.bufListDetail.GetActivatedBufList().Find(b => b.bufType == KeywordBuf.Burn);
            if(burn != null)
            {
                int healAmount = burn.stack;
                owner.bufListDetail.RemoveBuf(burn);
                owner.RecoverHP(healAmount);
            }
        }
    }
}
