using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class DiceCardSelfAbility_Rube_Similars : DiceCardAbilityBase
    {
        public static string Desc = "Dice on this page gain +2 Power if the target has only all buffs, or only all ailments";

        public override void OnRollDice()
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
                            power = 2
                        });
                    }
                }
            }
        }
    }
}
