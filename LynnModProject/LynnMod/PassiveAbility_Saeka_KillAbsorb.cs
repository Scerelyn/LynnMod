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
        public static string Desc = "On kill, increase the maximum value of passive 'Built Strength' by 1";

        public override void OnKill(BattleUnitModel target)
        {
            var passive = owner.passiveDetail.PassiveList.First(p => p is PassiveAbility_Saeka_PowerMaintain) as PassiveAbility_Saeka_PowerMaintain;
            passive.BuffMax += 1;
        }
    }
}
