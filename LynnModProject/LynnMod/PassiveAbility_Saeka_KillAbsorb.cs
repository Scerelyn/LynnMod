using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Saeka_KillAbsorb : PassiveAbilityBase
    {
        public static string Name = "Absorbtion";
        public static string Desc = "When a target is staggered increase the maximum value of passive 'Built Strength' by 1. On kill, increase the maximum by 2 instead, and gain any buffs the target has next scene.";

        public override void OnKill(BattleUnitModel target)
        {
            var passive = owner.passiveDetail.PassiveList.First(p => p is PassiveAbility_Saeka_PowerMaintain) as PassiveAbility_Saeka_PowerMaintain;
            passive.BuffMax += 2;
            foreach(BattleUnitBuf buff in target.bufListDetail.GetActivatedBufList().Where(b => b.positiveType == BufPositiveType.Positive))
            {
                owner.bufListDetail.AddBuf(buff);
            }
        }

        public override void OnMakeBreakState(BattleUnitModel target)
        {
            var passive = owner.passiveDetail.PassiveList.First(p => p is PassiveAbility_Saeka_PowerMaintain) as PassiveAbility_Saeka_PowerMaintain;
            passive.BuffMax += 1;
        }
    }
}
