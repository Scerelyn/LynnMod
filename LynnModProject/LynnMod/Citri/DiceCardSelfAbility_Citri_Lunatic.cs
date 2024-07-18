using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Citri_Lunatic : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Combat Start] Set Stagger Resist to 1 and gain 100 Stagger Protection. If the user has Lunacy, this card costs 0 and gain 5 Light and draw 3 cards next scene";

        public override void OnStartBattle()
        {
            this.owner.TakeBreakDamage(this.owner.breakDetail.breakGauge - 1, DamageType.Card_Ability);
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.BreakProtection, 100);

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

        public override void OnRoundEnd_inHand(BattleUnitModel unit, BattleDiceCardModel self)
        {
            BattleUnitBuf lunacy = this.owner.bufListDetail?.GetActivatedBufList().Find(b => b is BattleUnitBuff_Citri_Lunacy);
            if (lunacy != null)
            {
                self.SetCostToZero();
            }
        }
    }
}
