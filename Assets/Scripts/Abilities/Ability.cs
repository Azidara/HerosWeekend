using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend.Abilities{
    public class Ability : MonoBehaviour
    {
        public string ability_name;
        public string description;
        public float cooldown = 0.1f;
        public float last_activation = 0.0f;

        protected virtual void action(Vector3 position, Vector2 direction, GameObject source = null) {Debug.Log("Default Ability doesn't do anything.");}

        public void Activate(Vector3 position, Vector2 direction, GameObject source) {
            // Only Activate if the cooldown is up
            if (last_activation + cooldown > Time.time){
                return;
            }
            
            action(position, direction, source);
            last_activation = Time.time;
        }
    }
}

