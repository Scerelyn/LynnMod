﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina.Citri
{
    public class DiceCardSelfAbility_Citri_BreakDraw2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Lose 8 Stagger Resist and draw 1 card and gain 1 Light";

        public override void OnUseCard()
        {
            this.owner.TakeBreakDamage(8);
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}
