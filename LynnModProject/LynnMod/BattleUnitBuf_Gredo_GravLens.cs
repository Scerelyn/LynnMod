using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Gredo_GravLens : BattleUnitBuf
    {
        public static string Name = "Umbral Lens";
        public static string Desc = "If this character takes no action, receive {0} damage";

        protected override string keywordId => "Gredo_Umbral";
        protected override string keywordIconId => "Umbral";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        private bool performedAction = false;

        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            if (!performedAction)
            {
                _owner.TakeDamage(stack);
                performedAction = false;
            }
        }

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            performedAction = true;
            base.OnRollDice(behavior);
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Umbral"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
