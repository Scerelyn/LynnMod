using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Alba_Drowning : BattleUnitBuf
    {
        public static string Name = "Drowning";
        public static string Desc = "When attacked, take {0} damage once for each broken speed dice, then reduce the stack by a half.";

        protected override string keywordId => "Alba_Drown";
        protected override string keywordIconId => "Drown";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            var brokenDice = this._owner.speedDiceResult.Count(sd => sd.breaked);
            this._owner.TakeDamage(stack * brokenDice, DamageType.Buf);
            BattleUnitBuf flood = this._owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Flooded);
            if ((flood?.stack ?? 0) <= 0)
            {
                stack /= 2;
            }
        }

        public override void OnRoundEnd()
        {
            BattleUnitBuf flood = this._owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuf_Alba_Flooded);
            if ((flood?.stack ?? 0) <= 0)
            {
                Destroy();
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Drown"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
        }
    }
}
