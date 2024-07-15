using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_LunarPhase_WaxingCrescent : BattleUnitBuf
    {
        public static string Name = "Waxing Crescent";
        public static string Desc = "Increase Attack Dice power by 2 and Damage by 10%";

        protected override string keywordId => "Citri_Lunar1";
        protected override string keywordIconId => "Lunar1";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Type == BehaviourType.Atk)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus()
                {
                    power = 2,
                    dmgRate = 110
                });
            }
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Lunar1"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 2;
        }
    }
}
