using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Enbana_YellowFlame : BattleUnitBuf
    {
        public static string Name = "Yellow Spark";
        public static string Desc = "At the end of the turn, take {0} stagger damage, then reduce the stack by a third";

        protected override string keywordId => "Enbana_YellowFlame";
        protected override string keywordIconId => "YellowSpark";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        public override void OnRoundStartAfter()
        {
            base.OnRoundStartAfter();
            _owner.TakeBreakDamage(stack);
            stack /= 3;

            if(stack <= 0)
            {
                Destroy();
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["YellowSpark"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
