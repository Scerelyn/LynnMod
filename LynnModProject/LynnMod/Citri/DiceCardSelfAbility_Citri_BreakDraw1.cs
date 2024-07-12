using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina.Citri
{
    public class DiceCardSelfAbility_Citri_BreakDraw1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Lose 5 Stagger Resist and draw 1 card";

        public override void OnUseCard()
        {
            this.owner.TakeBreakDamage(5);
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}
