using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Rube_EmotionClear : PassiveAbilityBase
    {
        public static string Name = "Garnet Airs";
        public static string Desc = "At the start of each Scene, dispel 1 random status for every emotion level and gain HP equal to the stack";

        private static Random rng = new Random();

        public override void OnRoundStart()
        {
            for (int i = 0; i < owner.emotionDetail.EmotionLevel; i++)
            {
                int statusCount = owner.bufListDetail.GetActivatedBufList().Count;
                if (statusCount > 0)
                {
                    BattleUnitBuf randomOwnerStatus = owner.bufListDetail.GetActivatedBufList()[rng.Next(0, statusCount)];
                    owner.RecoverHP(randomOwnerStatus.stack);
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
