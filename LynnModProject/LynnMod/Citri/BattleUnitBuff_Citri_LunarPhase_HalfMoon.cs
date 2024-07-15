using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_LunarPhase_HalfMoon : BattleUnitBuf
    {
        public static string Name = "Half Moon";
        public static string Desc = "Increase all Dice power by 3 and Damage by 20%";

        protected override string keywordId => "Citri_Lunar2";
        protected override string keywordIconId => "Lunar2";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = 3,
                dmgRate = 110
            });
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Lunar2"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 3;
        }
    }
}
