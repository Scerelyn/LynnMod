using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Saeka_PowerMaintain : PassiveAbilityBase
    {
        public static string Name = "Built Strength";
        public static string Desc = "On scene end, keep stacks of all positive buffs on the next turn (max 5).";

        public override void OnRoundEnd()
        {
            int buffMax = 5 + (owner.bufListDetail.GetActivatedBufList().FirstOrDefault(b => b is BattleUnitBuf_Saeka_Absorb)?.stack ?? 0);
            List<BattleUnitBuf> currentBuffs = owner.bufListDetail.GetActivatedBufList().Where(b => b.positiveType == BufPositiveType.Positive).ToList();
            foreach (BattleUnitBuf buff in currentBuffs)
            {
                BattleUnitBuf existingBuff = owner.bufListDetail.GetReadyBufList().FirstOrDefault(b => b.GetType() == buff.GetType() || b.bufType == buff.bufType);
                if (existingBuff != null)
                {
                    existingBuff.stack = Math.Min(existingBuff.stack + buff.stack, buffMax);
                }
                else
                {
                    int buffStack = Math.Min(buff.stack, buffMax);
                    BattleUnitBuf copied = Activator.CreateInstance(buff.GetType()) as BattleUnitBuf;
                    copied.stack = buffStack;
                    owner.bufListDetail.AddReadyBuf(copied);
                }
            }
        }
    }
}
