using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Citri_Lunatic : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Combat Start] Set Stagger Resist to 1 and gain 100 Stagger Resist Protection this scene and next scene. If the user has Lunacy, gain 5 Light and draw 3 cards next scene";

        public override void OnStartBattle()
        {
            this.owner.TakeBreakDamage(this.owner.breakDetail.breakLife - 1);

            BattleUnitBuf lunacy = this.owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuff_Citri_Lunacy);
            if (lunacy != null)
            {
                lunacy.stack = 99;
                owner.allyCardDetail.DrawCards(3);
                owner.cardSlotDetail.RecoverPlayPointByCard(5);
            }

            BattleUnitBuf ecliptic = this.owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuff_Citri_Ecliptic);
            if (ecliptic != null)
            {
                ecliptic.stack = 99;
            }
        }
    }
}
