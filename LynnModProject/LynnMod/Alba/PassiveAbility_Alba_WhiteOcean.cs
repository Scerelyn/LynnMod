﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruina
{
    public class PassiveAbility_Alba_WhiteOcean : PassiveAbilityBase
    {
        public static string Name = "The White Ocean";
        public static string Desc = "(Untransferable) Gain 2 speed dice. Every emotion level, gain 1 additional speed dice.\nGain +2 Dice power and one 2-5 slash counter dice for each broken speed dice.\nAt emotion level 3+, enhance the counter dice to 3-7 with effect \"[On Hit] Inflict 3 Drowning\"";

        public override void OnStartBattle()
        {
            var brokenDice = owner.speedDiceResult.Count(sd => sd.breaked);
            for (int i = 0; i < brokenDice; i++)
            {
                if(owner.emotionDetail.EmotionLevel >= 3)
                {
                    owner.AppendDiceToQueue(101);
                }
                else
                {
                    owner.AppendDiceToQueue(100);
                }
            }
        }

        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            var brokenDice = owner.speedDiceResult.Count(sd => sd.breaked);
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = brokenDice * 2
            });
        }

        public override int SpeedDiceNumAdder()
        {
            return owner.emotionDetail.EmotionLevel + 1;
        }
    }
}
