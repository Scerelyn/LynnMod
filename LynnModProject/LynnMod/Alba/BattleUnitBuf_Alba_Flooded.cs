using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Alba_Flooded : BattleUnitBuf
    {
        public static string Name = "Flooded";
        public static string Desc = "Drowning does not decrease stacks this Scene. Reduce this stack by 1 at the end of the Scene";

        protected override string keywordId => "Alba_Flood";
        protected override string keywordIconId => "Flood";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        public override void OnRoundEnd()
        {
            stack--;
            if (stack <= 0)
            {
                Destroy();
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Flood"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
        }
    }
}
