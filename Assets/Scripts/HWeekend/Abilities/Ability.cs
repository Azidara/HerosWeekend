using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend.Abilities{
    public class Ability : MonoBehaviour
    {
        public Sprite icon;
        public string ability_name;
        public string description;
        public float cooldown = 0.1f;
        public float cooldown_timer;
        public bool isConsumable;
        public int uses_left;

        public Character source;

        protected virtual void action(Vector3 position, Vector2 direction, GameObject source = null) {Debug.Log("Default Ability doesn't do anything.");}

        public void activate(){
            // Check that ability is off cooldown
            if (cooldown_timer > 0){
                //Debug.Log($"{ability_name} has {cooldown_timer.ToString("0.00")} secs left");
                return;
            }
            
            // Find the position and direction the ability should be triggered from
            if (source == null){
                Debug.LogError($"Source of {ability_name} was not set. Can not autodetirme where to trigger ability");
            }

            action(source.transform.Find("attack_pivot").transform.position, source.aim_input, source.gameObject);
            cooldown_timer = cooldown;
        }

        void Update(){
            cooldown_timer -= Time.deltaTime;
        }

        public void activate(Vector3 position, Vector2 direction) {
            action(position, direction, source.gameObject);
        }
    }
}

