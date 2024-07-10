using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_LunarPhase_FullMoon : BattleUnitBuf
    {
        public static string Name = "Waxing Gibbous";
        public static string Desc = "Gain Lunacy and Ecliptic";

        protected override string keywordId => "Citri_Lunar4";
        protected override string keywordIconId => "Lunar4";

        public override void OnRoundStart()
        {
            BattleUnitBuf lunacy = this._owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuff_Citri_Lunacy);
            if (lunacy == null)
            {
                lunacy = new BattleUnitBuff_Citri_Lunacy();
                this._owner.bufListDetail.AddBuf(lunacy);
            }

            BattleUnitBuf ecliptic = this._owner.bufListDetail.GetActivatedBufList().Find(b => b is BattleUnitBuff_Citri_Ecliptic);
            if (ecliptic == null)
            {
                ecliptic = new BattleUnitBuff_Citri_Ecliptic();
                this._owner.bufListDetail.AddBuf(ecliptic);
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["LunarPhase4"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 5;
        }
    }
}
