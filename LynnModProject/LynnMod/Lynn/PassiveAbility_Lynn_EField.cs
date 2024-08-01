using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Lynn_EField : PassiveAbilityBase
    {
        public static string Name = "E Field Manipulation";
        public static string Desc = "When inflicted with Paralysis, gain 3 to max roll instead";

        public override bool IsImmune(KeywordBuf buf)
        {
            return buf == KeywordBuf.Paralysis;
        }

        public static void PassiveAbility_Lynn_EField_OnUseCard(BattleUnitBuf_paralysis __instance, ref BattlePlayingCardDataInUnitModel card)
        {
            if (card.owner.passiveDetail.PassiveList.Any(p => p is PassiveAbility_Lynn_EField))
            {
                card.AddDiceFace(DiceMatch.Random(__instance.stack), 1);
                SingletonBehavior<DiceEffectManager>.Instance.CreateBufEffect("BufEffect_Paralyze", card.owner.view);
            }
        }
    }
}
