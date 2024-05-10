using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Rube_ClearSingleDraw1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Dispel a random status and draw 1 card";

        private static Random rng = new Random();

        public override void OnUseCard()
        {
            int statusCount = owner.bufListDetail.GetActivatedBufList().Count;
            if (statusCount > 0)
            {
                BattleUnitBuf randomOwnerStatus = owner.bufListDetail.GetActivatedBufList()[rng.Next(0, statusCount)];
                owner.RecoverHP(randomOwnerStatus.stack);
                owner.bufListDetail.RemoveBuf(randomOwnerStatus);
                owner.allyCardDetail.DrawCards(1);
            }
        }
    }
}
