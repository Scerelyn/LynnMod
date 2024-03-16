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
        public static string Desc => "(Untransferable) Receive no damage from attacks. Gain 25 Resistance at the start of the Act. Gain 5 Resisistance every Scene (Max 40)";

        private readonly int buffStartMax = 25;
        private readonly int buffMax = 40;
        
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Resistance, buffStartMax);
        }

        public override void OnRoundStart()
        {
            BattleUnitBuf resBuff = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b.bufType == KeywordBuf.Resistance);
            if (resBuff == null)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Resistance, 5);
            }
            else if(resBuff.stack < buffMax)
            {
                resBuff.stack += resBuff.stack > buffMax - 5 ? buffMax - resBuff.stack : 5;
            }
        }

        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            atkDice.ApplyDiceStatBonus(new DiceStatBonus()
            {
                dmgRate = -9999
            });
            base.OnTakeDamageByAttack(atkDice, dmg);
        }
    }
}
