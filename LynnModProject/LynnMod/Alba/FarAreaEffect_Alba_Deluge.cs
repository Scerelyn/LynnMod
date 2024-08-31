using System.Collections.Generic;
using LOR_DiceSystem;
using LOR_XML;
using UnityEngine;

namespace Ruina
{
    public class FarAreaEffect_Alba_Deluge : FarAreaEffect
    {
        private float elapsed;

        private BattleUnitModel owner;

        private bool started;

        private float CurrentAttackDelay
        {
            get => 0.6f;
        }

        private float CurrentEndDelay
        {
            get => 1.5f;
        }

        public override void Init(BattleUnitModel self, params object[] args)
        {
            base.Init(self, args);
            OnEffectStart();
            elapsed = 0f;
            owner = self;
            started = false;
            isRunning = false;
            state = EffectState.None;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
            
        }

        public override bool ActionPhase(float deltaTime, BattleUnitModel attacker, List<BattleFarAreaPlayManager.VictimInfo> victims, ref List<BattleFarAreaPlayManager.VictimInfo> defenseVictims)
        {
            elapsed += deltaTime;
            if (!started)
            {
                started = true;
                //PrintSound();
                
            }
            else if (elapsed >= 0.1f && state == EffectState.None)
            {
                state = EffectState.Start;
                PrintEffect();
                owner.view.charAppearance.ChangeMotion(ActionDetail.Slash);
                
            }
            else if (elapsed >= CurrentAttackDelay && state == EffectState.Start)
            {
                state = EffectState.GiveDamage;
                foreach (BattleFarAreaPlayManager.VictimInfo victim2 in victims)
                {
                    if (victim2.playingCard != null)
                    {
                        int sum = 0;
                        List<BattleDiceBehavior> diceBehaviorList = victim2.playingCard.GetDiceBehaviorList();
                        if (!victim2.cardDestroyed)
                        {
                            diceBehaviorList.ForEach(delegate (BattleDiceBehavior x)
                            {
                                sum += x.DiceResultValue;
                            });
                        }
                        if (attacker.currentDiceAction.currentBehavior.DiceResultValue > sum)
                        {
                            GiveDamage(attacker, victim2);
                            victim2.cardDestroyed = true;
                        }
                        else
                        {
                            ActionDetail detail = ActionDetail.Default;
                            if (diceBehaviorList.Count > 0)
                            {
                                detail = MotionConverter.MotionToAction(diceBehaviorList[0].behaviourInCard.MotionDetail);
                            }
                            victim2.unitModel.view.charAppearance.ChangeMotion(detail);
                            if (!defenseVictims.Contains(victim2))
                            {
                                defenseVictims.Add(victim2);
                            }
                        }
                    }
                    else
                    {
                        GiveDamage(attacker, victim2);
                    }
                    SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(victim2.unitModel, victim2.unitModel.faction, victim2.unitModel.hp, victim2.unitModel.breakDetail.breakGauge);
                }
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(attacker, attacker.faction, attacker.hp, attacker.breakDetail.breakGauge);
            }
            else if (elapsed >= CurrentEndDelay && state == EffectState.GiveDamage)
            {
                state = EffectState.End;
            }
            else if (state == EffectState.End)
            {
                OnEffectEnd();
                return true;
            }
            return false;
        }

        public override void OnEffectEnd()
        {
            _isDoneEffect = true;
        }

        private void PrintEffect()
        {
            SingletonBehavior<DiceEffectManager>.Instance.CreateBehaviourEffect("Akao_Green_Slash", 1f, _self.view, null);
        }

        private void GiveDamage(BattleUnitModel attacker, BattleFarAreaPlayManager.VictimInfo v)
        {
            attacker.currentDiceAction.currentBehavior.GiveDamage(v.unitModel);
            if (v.unitModel.IsDead())
            {
                List<BattleUnitModel> list = new List<BattleUnitModel>();
                list.Add(attacker);
                v.unitModel.view.DisplayDlg(DialogType.DEATH, list);
            }
            v.unitModel.view.charAppearance.ChangeMotion(ActionDetail.Damaged);
        }
    }
}
