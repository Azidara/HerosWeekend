using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend{
    public class Player_Character : Character
    {
        Transform attack_pivot;

        protected override void Awake(){
            base.Awake();
            if (attack_pivot == null){
                attack_pivot = this.transform.Find("attack_pivot").transform;
            }
        }
    }
}

