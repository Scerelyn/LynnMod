using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Citri_Eclipsing : DiceCardAbilityBase
    {
        public static string Desc = "If the user has Ecliptic, this dice is rerolled 5 times";

        private int _repeatCount = 0;

        public override void AfterAction()
        {
            if (this.owner.bufListDetail.GetActivatedBufList().Any(b => b is BattleUnitBuff_Citri_Ecliptic) && _repeatCount < 5)
            {
                _repeatCount++;
                ActivateBonusAttackDice();
            }
        }
    }
}
