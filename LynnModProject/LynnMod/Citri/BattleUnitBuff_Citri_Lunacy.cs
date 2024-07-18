using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_Lunacy : BattleUnitBuf
    {
        public static string Name = "Lunacy";
        public static string Desc = "Gain a chance to triple dice rolls based on missing stagger resist ({0}% chance)";

        protected override string keywordId => "Citri_Lunacy";
        protected override string keywordIconId => "Lunacy";

        private static Random rng = new Random();

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            stack = 100 - (100 * this._owner.breakDetail.breakGauge / this._owner.breakDetail.GetDefaultBreakGauge());
            bool rngResult = rng.Next(0, 100) <= stack;
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = rngResult ? behavior.DiceVanillaValue * 2 : 0 //power is added to not set, hence 3x => x + 2x
            });
        }

        public override void OnLoseHp(int dmg)
        {
            stack = 100 - (100 * this._owner.breakDetail.breakGauge / this._owner.breakDetail.GetDefaultBreakGauge());
        }

        public override void OnRoundStart()
        {
            stack = 100 - (100 * this._owner.breakDetail.breakGauge / this._owner.breakDetail.GetDefaultBreakGauge());
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Lunacy"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 100 - (100 * this._owner.breakDetail.breakGauge / this._owner.breakDetail.GetDefaultBreakGauge());
        }
    }
}
