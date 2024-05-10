using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Rube_Similars : DiceCardSelfAbilityBase
    {
        public static string Desc = "Dice on this page gain +4 Power if the target has only all buffs, or only all ailments";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior?.card?.target;
            if (target != null)
            {
                List<BattleUnitBuf> bufList = target.bufListDetail.GetActivatedBufList();
                if (bufList.Any())
                {
                    BufPositiveType? type = bufList.First().positiveType;
                    if (bufList.All(b => b.positiveType == type))
                    {
                        behavior.ApplyDiceStatBonus(new DiceStatBonus()
                        {
                            power = 4
                        });
                    }
                }
            }
        }
    }
}
