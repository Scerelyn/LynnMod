using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina.Citri
{
    public class DiceCardSelfAbility_Citri_BreakDraw2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Lose 8 Stagger Resist and draw 1 card and gain 2 Light";

        public override void OnUseCard()
        {
            int staggerProtection = this.owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.BreakProtection)?.stack ?? 0;
            this.owner.TakeBreakDamage(Math.Max(8 - staggerProtection, 0), DamageType.Card_Ability);
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
}
