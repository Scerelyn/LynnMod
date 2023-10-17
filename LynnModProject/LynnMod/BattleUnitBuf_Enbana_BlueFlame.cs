using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Enbana_BlueFlame : BattleUnitBuf
    {
        public static string Name = "Blue Flame";
        public static string Desc = "At the end of the turn, take 3*{0} damage, then remove the entire stack";

        protected override string keywordId => "Enbana_BlueFlame";
        protected override string keywordIconId => "BlueFlame";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        public override void OnRoundStartAfter()
        {
            base.OnRoundStartAfter();
            _owner.TakeDamage(stack * 3);
            stack = 0;
            Destroy();
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["BlueFlame"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 0;
        }
    }
}
