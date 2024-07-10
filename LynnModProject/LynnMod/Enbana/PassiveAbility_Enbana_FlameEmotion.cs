using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Enbana_FlameEmotion : PassiveAbilityBase
    {
        public static string Name = "Igniting Emotion";
        public static string Desc = "Gain +1 Dice power and +3 Burn per emotion level";

        public override void OnRoundStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, owner.emotionDetail.EmotionLevel * 3);
        }

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = owner.emotionDetail.EmotionLevel
            });
        }
    }
}
