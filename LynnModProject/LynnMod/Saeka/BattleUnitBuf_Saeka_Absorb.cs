using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Saeka_Absorb : BattleUnitBuf
    {
        public static string Name = "Absorbsion";
        public static string Desc = "Passive Effect \"Built Strength\" maximum value is increased by {0}";

        protected override string keywordId => "Saeka_Absorb";
        protected override string keywordIconId => "Absorb";
        public override BufPositiveType positiveType => BufPositiveType.None;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Absorb"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
