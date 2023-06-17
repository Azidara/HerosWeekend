using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend{
    public class Player_Character : Character
    {
        public void primary_attack() {
            Vector2 direction =  GetAimPoint() - new Vector2(this.transform.position.x, this.transform.position.y);
            primary_ability.Activate(this.transform.position, direction);
        }

        public void secondary_attack() {
            Vector2 direction = GetAimPoint() - new Vector2(this.transform.position.x, this.transform.position.y);
            primary_ability.Activate(this.transform.position, direction);
        }

        private Vector2 GetAimPoint(){
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }   
    }
}

