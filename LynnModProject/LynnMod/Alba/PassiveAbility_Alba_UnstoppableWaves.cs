using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Alba_UnstoppableWaves : PassiveAbilityBase
    {
        public static string Name = "Riptides";
        public static string Desc = "On Clash Win, if the target has 7+ Drowning, inflict 1 Submerge";

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            var target = behavior.card.target;
            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Seal, 1, this.owner);
            }
        }
    }
}
