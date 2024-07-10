using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Gredo_BlackStar : PassiveAbilityBase
    {
        public static string Name => "The Black Star";
        public static string Desc => "(Untransferable) Receive no damage from attacks. Gain 25 Resistance at the start of the Act. Gain 3 Resisistance every Scene (Max 40)";

        private readonly int buffStartMax = 22;
        private readonly int buffMax = 40;
        private readonly int buffPerTurn = 3;

        public override bool IsImmuneDmg(DamageType type, KeywordBuf keyword = KeywordBuf.None)
        {
            return type == DamageType.Attack;
        }

        public override void OnWaveStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Resistance, buffStartMax);
        }

        public override void OnRoundStart()
        {
            BattleUnitBuf resBuff = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Resistance);
            if (resBuff == null)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Resistance, buffPerTurn);
            }
            else if(resBuff.stack < buffMax)
            {
                resBuff.stack += resBuff.stack > buffMax - buffPerTurn ? buffMax - resBuff.stack : buffPerTurn;
            }
        }
    }
}
