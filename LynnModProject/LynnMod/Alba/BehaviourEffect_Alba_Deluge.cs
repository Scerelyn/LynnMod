using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ruina
{
    public class BehaviourEffect_Alba_Deluge : BehaviourActionBase
    {
        public override FarAreaEffect SetFarAreaAtkEffect(BattleUnitModel self)
        {
            _self = self;
            FarAreaEffect_Alba_Deluge farAreaEffect_Deluge = new GameObject().AddComponent<FarAreaEffect_Alba_Deluge>();
            farAreaEffect_Deluge.Init(self);
            return farAreaEffect_Deluge;
        }
    }
}
