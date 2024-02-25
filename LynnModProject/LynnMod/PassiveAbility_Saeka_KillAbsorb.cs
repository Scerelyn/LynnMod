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
        public static string Desc = "When a target is staggered, increase the maximum value of passive 'Built Strength' by 1. On kill, increase the maximum by 2 instead, and gain any buffs the target has next scene.";

        public override void OnWaveStart()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_Saeka_Absorb());
        }

        public override void OnKill(BattleUnitModel target)
        {
            BattleUnitBuf_Saeka_Absorb absorbBuff = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Saeka_Absorb) as BattleUnitBuf_Saeka_Absorb;
            if (absorbBuff != null)
            {
                absorbBuff.stack += 2;
            }
            foreach (BattleUnitBuf buff in target.bufListDetail.GetActivatedBufList().Where(b => b.positiveType == BufPositiveType.Positive))
            {
                BattleUnitBuf copied = Activator.CreateInstance(buff.GetType()) as BattleUnitBuf;
                copied.stack = buff.stack;
                owner.bufListDetail.AddReadyBuf(copied);
            }
        }

        public override void OnMakeBreakState(BattleUnitModel target)
        {
            BattleUnitBuf_Saeka_Absorb absorbBuff = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Saeka_Absorb) as BattleUnitBuf_Saeka_Absorb;
            if (absorbBuff != null) {
                absorbBuff.stack += 1;
            }
        }
    }
}
