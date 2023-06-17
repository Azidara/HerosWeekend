using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend.Abilities{
    public class Ability : ScriptableObject
    {
        public string ability_name;
        public string description;
        //public float cooldown;
        //public float last_activation;

        protected virtual void action(Vector3 position, Vector2 direction){Debug.Log("Default Ability doesn't do anything.");}

        public void Activate(Vector3 position, Vector2 direction) {
            // This cooldown stuff does work but it doesn't work as you would expect with a scriptableobject
            // Only Activate if the cooldown is up
            //if (last_activation + cooldown > Time.time){
            //    return;
            //}
            
            action(position, direction);
            //last_activation = Time.time;
        }
    }
}
