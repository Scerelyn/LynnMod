using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Gredo_Penumbric : BattleUnitBuf
    {
        public static string Name = "Penumbric";
        public static string Desc = "When recieving damage, reflect {0} damage back to the attacker";

        protected override string keywordId => "Gredo_Penumbric";
        protected override string keywordIconId => "Penumbric";
        public override BufPositiveType positiveType => BufPositiveType.None;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Penumbric"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
