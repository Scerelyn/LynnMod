using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Rube_RedSky : PassiveAbilityBase
    {
        public static string Name = "Red Sky";
        public static string Desc = "(Untransferable) On Clash Win, dispel a random status effect on target and self. If it was a negative ailment dispelled, gain 5 hp. If it was positive, gain 5 stagger resist.";

        private static Random rng = new Random();

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior?.card?.target;
            if (target != null)
            {
                if (target.bufListDetail.GetActivatedBufList().Count > 0)
                {
                    BattleUnitBuf randomTargetStatus = target.bufListDetail.GetActivatedBufList()[rng.Next(0, target.bufListDetail.GetActivatedBufList().Count)];
                    target.bufListDetail.RemoveBuf(randomTargetStatus);
                    switch (randomTargetStatus.positiveType)
                    {
                        case BufPositiveType.Positive:
                            owner.RecoverHP(5);
                            break;
                        case BufPositiveType.Negative:
                            owner.RecoverBreakLife(5);
                            break;
                    }
                }
            }
            if (owner.bufListDetail.GetActivatedBufList().Count > 0)
            {
                BattleUnitBuf randomOwnerStatus = owner.bufListDetail.GetActivatedBufList()[rng.Next(0, owner.bufListDetail.GetActivatedBufList().Count)];
                owner.bufListDetail.RemoveBuf(randomOwnerStatus);
                switch (randomOwnerStatus.positiveType)
                {
                    case BufPositiveType.Positive:
                        owner.RecoverHP(5);
                        break;
                    case BufPositiveType.Negative:
                        owner.RecoverBreakLife(5);
                        break;
                }
            }
        }
    }
}
