using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Lynn_ShockDraw : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Draw 1 page. If inflicted with paralysis, draw another and gain 1 Light";

        public override void OnUseCard()
        {
            bool hasParalysis = owner.bufListDetail.GetActivatedBufList().Any(b => b.bufType == KeywordBuf.Paralysis);
            owner.allyCardDetail.DrawCards(hasParalysis ? 2 : 1);
            if (hasParalysis)
            {
                owner.cardSlotDetail.RecoverPlayPointByCard(1);
            }
        }
    }
}
