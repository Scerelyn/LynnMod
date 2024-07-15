using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_LunarPhase_NewMoon : BattleUnitBuf
    {
        public static string Name = "New Moon";
        public static string Desc = "Increase Attack Dice power by 1";

        protected override string keywordId => "Citri_Lunar0";
        protected override string keywordIconId => "Lunar0";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Type == BehaviourType.Atk)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = 1
                });
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Lunar0"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 1;
        }
    }
}
