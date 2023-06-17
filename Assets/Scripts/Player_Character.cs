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
        public void primary_attack() {
            Vector2 direction =  GetAimPoint() - new Vector2(attack_pivot.position.x, attack_pivot.position.y);
            primary_ability.Activate(attack_pivot.position, direction);
        }

        public void secondary_attack() {
            Vector2 direction = GetAimPoint() - new Vector2(attack_pivot.position.x, attack_pivot.position.y);
            primary_ability.Activate(attack_pivot.position, direction);
        }

        private Vector2 GetAimPoint(){
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }   
    }
}

