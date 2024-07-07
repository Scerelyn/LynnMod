using HarmonyLib;
using Battle.DiceAttackEffect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ruina.AttackEffects
{
    public class DiceAttackEffect_Lynn_Block : DiceAttackEffect
    {
        private float duration;

        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            duration = destroyTime;
            spr.sprite = Initializer.ArtWorks["lynn_block_FX"];
            base.Initialize(self, target, destroyTime);
        }

        protected override void Update()
        {
            base.Update();
            duration -= Time.deltaTime;
            base.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, duration * 2f);
        }
    }
}
