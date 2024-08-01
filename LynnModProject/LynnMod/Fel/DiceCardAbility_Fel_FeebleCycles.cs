using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Fel_FeebleCycles : DiceCardAbilityBase
    {
        public static string Desc = "Recycle this die again for each stack of feeble on self";
        
        public override void AfterAction()
        {
            BattleUnitBuf feeble = this.owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Weak);
            if (feeble != null)
            {
                for(int i = 0; i < feeble.stack; i++)
                {
                    ActivateBonusAttackDice();
                }
            }
        }
    }
}
