using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Rube_ClearOut : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Dispel 3 random statuses. For each one dispelled, draw 1 card and gain 1 light.";

        private static Random rng = new Random();

        public override void OnUseCard()
        {
            int gainAmount = Math.Min(3, owner.bufListDetail.GetActivatedBufList().Count);
            if (gainAmount > 0)
            {
                owner.cardSlotDetail.RecoverPlayPointByCard(gainAmount);
                owner.allyCardDetail.DrawCards(gainAmount);
                for (int i = 0; i < 3; i++)
                {
                    int statusCount = owner.bufListDetail.GetActivatedBufList().Count;
                    if (statusCount > 0)
                    {
                        BattleUnitBuf randomOwnerStatus = owner.bufListDetail.GetActivatedBufList()[rng.Next(0, statusCount)];
                        owner.bufListDetail.RemoveBuf(randomOwnerStatus);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
