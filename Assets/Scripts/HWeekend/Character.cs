using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using HWeekend.Abilities;

namespace HWeekend{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        
        #region Configurable Variables
        public float speed = 10f;
        public Vector2 respawn_position = new Vector2(0,0);
        #endregion

        #region Reference Variables
        public Animator animator;
        private Rigidbody2D rb;
        public Vector3 move_input;
        public Vector2 aim_input;
        #endregion

        #region Actions
        public Ability primary_attack;
        public Ability secondary_attack;
        public Ability action1;
        public Ability action2;
        public Ability action3;
        public Ability action4;
        public Ability action5;
        #endregion

        protected virtual void Awake(){
            rb = this.GetComponent<Rigidbody2D>();

            // Initalize Actions to a blank action if they are null;
            primary_attack = initalizeAbility(primary_attack, "PrimaryAttack");
            secondary_attack = initalizeAbility(secondary_attack, "SecondaryAttack");
            action1 = initalizeAbility(action1, "Action1");
            action2 = initalizeAbility(action2, "Action2");
            action3 = initalizeAbility(action3, "Action3");
            action4 = initalizeAbility(action4, "Action4");
            action5 = initalizeAbility(action5, "Action5");
        }

        private Ability initalizeAbility(Ability a, string name){
            if (a == null){
                string obj_path = Path.Combine(ResourcesIndex.ability_prefabs_path, "EmptyAbility");
                GameObject emptyPrefab = Resources.Load(obj_path) as GameObject;
                if (emptyPrefab == null){Debug.LogError($"Resources.Load returned null for path '{obj_path}'");}
                GameObject emptyGO = Instantiate(emptyPrefab);
                emptyGO.transform.SetParent(this.transform.Find("Abilities").transform);
                a = emptyGO.GetComponent<Ability>();
            }
            a.gameObject.name = name;
            a.source = this;
            return a;
        }

        public void teleport(Vector2 vec){
            this.teleport(vec.x,vec.y);
        }
        public void teleport(float x, float y){
            this.transform.position = new Vector3(x,y,0);
        }
        public void move(Vector2 vec){
            this.move(vec.x,vec.y);
        }
        public void move(float x, float y){
            move_input = new Vector3(x,y,0);
        }

        public void respawn() {
            this.transform.position = new Vector3(respawn_position.x, respawn_position.y, 0);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = move_input * speed;
            
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            //animator.SetFloat("Magnitude", movement.magnitude);

            rb.velocity = move_input * speed;
        }
    }
}