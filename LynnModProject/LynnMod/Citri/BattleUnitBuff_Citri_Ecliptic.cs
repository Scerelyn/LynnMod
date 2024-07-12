using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class BattleUnitBuff_Citri_Ecliptic : BattleUnitBuf
    {
        public static string Name = "Ecliptic";
        public static string Desc = "Deal damage based on missing stagger resist ({0}% boost)";

        protected override string keywordId => "Citri_Ecliptic";
        protected override string keywordIconId => "Ecliptic";

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                dmgRate = stack
            });
        }

        public override void OnLoseHp(int dmg)
        {
            stack = 100 - (100 * this._owner.breakDetail.breakLife) / this._owner.breakDetail.breakGauge;
        }

        public override void OnRoundStart()
        {
            stack = 100 - (100 * this._owner.breakDetail.breakLife) / this._owner.breakDetail.breakGauge;
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            typeof(BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, Initializer.ArtWorks["Ecliptic"]);
            typeof(BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            stack = 100 - (100 * this._owner.breakDetail.breakLife) / this._owner.breakDetail.breakGauge;
        }
    }
}
