using System.Collections.Generic;
using LOR_DiceSystem;
using UnityEngine;

namespace Ruina
{

    public class FarAreaEffect_Alba_Deluge : FarAreaEffect
    {
        private const int _XIAO_NORMAL_ID = -1;

        private const int _XIAO_EGO_1_ID = 150036;

        private const int _XIAO_EGO_2_ID = 150038;

        private float _elapsed;

        private CameraFilterPack_FX_EarthQuake _camFilter;

        private SpriteRenderer _spr;

        private ActionDetail _beforeMotion;

        public override void Init(BattleUnitModel self, params object[] args)
        {
            base.Init(self, args);
            self.moveDetail.Move(Vector3.zero, 200f);
            OnEffectStart();
            _elapsed = 0f;
            Singleton<BattleFarAreaPlayManager>.Instance.SetActionDelay(0f);
            List<BattleUnitModel> list = new List<BattleUnitModel>();
            list.Add(self);
            list.AddRange(BattleObjectManager.instance.GetAliveList((self.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy));
            if (self.Book.GetBookClassInfoId() == -1)
            {
                SingletonBehavior<BattleCamManager>.Instance.FollowUnits(false, list);
            }
            _beforeMotion = ActionDetail.Default;
        }

        protected override void Update()
        {
            if (state == EffectState.Start)
            {
                if (_self.moveDetail.isArrived)
                {
                    state = EffectState.GiveDamage;
                }
            }
            else if (state == EffectState.GiveDamage)
            {
                _elapsed += Time.deltaTime;
                if (_elapsed >= 0.25f)
                {
                    _beforeMotion = _self.view.charAppearance.GetCurrentMotionDetail();
                    //if (_self.UnitData.unitData.EnemyUnitId == 50002 || _self.Book.GetBookClassInfoId() == 250002)
                    //{
                    //    _self.view.charAppearance.ChangeMotion(ActionDetail.S2);
                    //}
                    //else
                    //{
                        _self.view.charAppearance.ChangeMotion(ActionDetail.Hit);
                    //}
                    _elapsed = 0f;
                    isRunning = false;
                    state = EffectState.End;
                    Camera camera = SingletonBehavior<BattleCamManager>.Instance?.EffectCam;
                    _camFilter = camera.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>();
                    if (SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject is ScorchedGirlMapManager)
                    {
                        ScorchedGirlMapManager scorchedGirlMapManager = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject as ScorchedGirlMapManager;
                        _spr = scorchedGirlMapManager.SetBurnFilterLinearDodge(b: true);
                    }
                    TimeManager.Instance.SlowMotion(0.25f, 0.125f, zoom: true);
                    if (_self.Book.GetBookClassInfoId() == -1)
                    {
                        _self.view.charAppearance.soundInfo.PlaySound(MotionDetail.S2, win: true);
                        SingletonBehavior<DiceEffectManager>.Instance.CreateBehaviourEffect("LiuSection1Shyao_AreaAtk2", 1f, _self.view, null);
                    }
                    else
                    {
                        _self.view.charAppearance.soundInfo.PlaySound(MotionDetail.S2, win: true);
                        SingletonBehavior<DiceEffectManager>.Instance.CreateBehaviourEffect("XiaoEgo_S2", 1f, _self.view, null);
                    }
                }
            }
            else if (state == EffectState.End)
            {
                _elapsed += Time.deltaTime;
                if (_camFilter != null)
                {
                    _camFilter.Speed = 30f * (1f - _elapsed);
                    _camFilter.X = 0.1f * (1f - _elapsed);
                    _camFilter.Y = 0.1f * (1f - _elapsed);
                }
                if (_spr != null)
                {
                    Color color = _spr.color;
                    color.a = 1f - _elapsed;
                    _spr.color = color;
                }
                if (_elapsed > 1f)
                {
                    if (_camFilter != null)
                    {
                        Object.Destroy(_camFilter);
                        _camFilter = null;
                    }
                    if (_spr != null)
                    {
                        _spr.enabled = false;
                    }
                    if (_self.UnitData.unitData.EnemyUnitId == 50002)
                    {
                        _self.view.charAppearance.ChangeMotion(ActionDetail.Default);
                    }
                    else
                    {
                        _self.view.charAppearance.ChangeMotion(_beforeMotion);
                    }
                    state = EffectState.None;
                    _elapsed = 0f;
                }
            }
            else if (state == EffectState.None)
            {
                if (_self.Book.GetBookClassInfoId() == -1)
                {
                    SingletonBehavior<BattleCamManager>.Instance.FollowUnits(false, BattleObjectManager.instance.GetAliveList());
                }
                if (_self.view.FormationReturned)
                {
                    Object.Destroy(base.gameObject);
                }
                Debug.Log($"LorId: {_self.Book.BookId.id}, {_self.Book.BookId.packageId}, isworkshop: {_self.Book.BookId.IsWorkshop()}, book name: {_self.Book.Name}");
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_camFilter != null)
            {
                Object.Destroy(_camFilter);
                _camFilter = null;
            }
        }
    }
}
