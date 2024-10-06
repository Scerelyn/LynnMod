using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuf_Alba_Submerge : BattleUnitBuf
    {
        public static string Name = "Submerge";
        public static string Desc = "Break {0} speed dice this scene";

        protected override string keywordId => "Alba_Submerge";
        protected override string keywordIconId => "Submerge";
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        public override int SpeedDiceBreakedAdder()
        {
            return stack;
        }
        
        public override void OnRoundEnd()
        {
            Destroy();
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Submerge"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
        }
    }
}
