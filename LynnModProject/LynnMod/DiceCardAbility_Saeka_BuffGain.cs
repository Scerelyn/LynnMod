using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardAbility_Saeka_BuffGain : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Randomly gain 1 Strength, Haste or Endurance next scene.";
        private static Random rng = new Random();

        public override void OnSucceedAttack()
        {
            switch (rng.Next(0,2))
            {
                case 0:
                    this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
                    break;
                case 1:
                    this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 1);
                    break;
                case 2:
                    this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
                    break;
            }
        }
    }
}
