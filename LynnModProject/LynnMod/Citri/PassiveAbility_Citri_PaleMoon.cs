using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Citri_PaleMoon : PassiveAbilityBase
    {
        public static string Name = "The Pale Moon";
        public static string Desc = "(Untransferable) Cannot be staggered. When stagger resist hits 0, reset it to max and advance Lunar Phase by 1";

        private int _phase = 0;

        private Dictionary<int, Type> LunarPhaseBuffs = new Dictionary<int, Type>()
        {
            {0, typeof(BattleUnitBuff_Citri_LunarPhase_NewMoon) },
            {1, typeof(BattleUnitBuff_Citri_LunarPhase_WaxingCrescent) },
            {2, typeof(BattleUnitBuff_Citri_LunarPhase_HalfMoon) },
            {3, typeof(BattleUnitBuff_Citri_LunarPhase_WaxingGibbous) },
            {4, typeof(BattleUnitBuff_Citri_LunarPhase_FullMoon) },
        };

        public override bool OnBreakGageZero()
        {
            this.owner.RecoverBreakLife(300);
            _phase = _phase >= 4 ? 4 : _phase + 1;
            return true;
        }

        public override void OnRoundStart()
        {
            this.owner.bufListDetail.GetActivatedBufList().RemoveAll(b => LunarPhaseBuffs.Values.Any(lb => lb.GetType() == b.GetType()));
            if (!this.owner.bufListDetail.GetActivatedBufList().Select(b => b.GetType()).Intersect(LunarPhaseBuffs.Values).Any())
            {
                BattleUnitBuf phaseBuff = Activator.CreateInstance(LunarPhaseBuffs[_phase]) as BattleUnitBuf;
                this.owner.bufListDetail.AddBuf(phaseBuff); //add buf at phase count
            }

            //owner.view.ChangeWorkShopSkin(Initializer.PackageId, "Citri0"); //change skin per phase
        }
    }
}
