using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_LunarPhase_WaxingGibbous : BattleUnitBuf
    {
        public static string Name = "Waxing Gibbous";
        public static string Desc = "Increase all Dice power by 3 and gain Ecliptic";

        protected override string keywordId => "Citri_Lunar3";
        protected override string keywordIconId => "Lunar3";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = 3
            });
        }

        public override void OnRoundStart()
        {
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
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["LunarPhase3"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 4;
        }
    }
}
