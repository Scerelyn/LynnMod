using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Rube_Dust : BattleUnitBuf
    {
        public static string Name = "Crimson Dust";
        public static string Desc = "When triggered by a Burst effect, dispel all statuses and inflict damage equal to {0} times the amount of statuses removed. This status is ignored by passives 'Red Sky' and 'Clarity'.";

        protected override string keywordId => "Rube_Dust";
        protected override string keywordIconId => "Dust";
        public override BufPositiveType positiveType => BufPositiveType.None;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Dust"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
