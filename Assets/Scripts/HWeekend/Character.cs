using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


using HWeekend.Abilities;

namespace HWeekend{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : NetworkBehaviour
    {
        #region Configurable Variables
        [SerializeField] private string _character_name;
        public int max_health = 10;
        public float speed = 10f;
        public Vector2 respawn_position = new Vector2(0,0);
        #endregion

        #region State Variables
        public Vector3 move_input;
        public Vector2 aim_input;
        [SerializeField] private int _health;
        [SerializeField] private int last_health;
        #endregion

        #region Reference Variables
        public Animator animator;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D hitbox;

        #region Actions
        public Ability primary_attack;
        public Ability secondary_attack;
        public Ability action1;
        public Ability action2;
        public Ability action3;
        public Ability action4;
        public Ability action5;
        #endregion
        #endregion

        #region Accessors
        public string character_name {get {return _character_name;} set{_character_name = value; OnCharacterNameChange?.Invoke();}}
        public int health {get{return _health;} set{last_health = _health; _health = value; OnHealthChange?.Invoke();}}
        #endregion

        #region Events
        public VoidDelegate OnCharacterNameChange;
        public VoidDelegate OnHealthChange;
        #endregion
        

        protected virtual void Awake(){
            rb = this.GetComponent<Rigidbody2D>();
            hitbox = this.transform.Find("HitBox").GetComponent<Collider2D>();

            // Initalize Actions to a blank action if they are null;
            primary_attack = initalizeAbility(primary_attack, "PrimaryAttack");
            secondary_attack = initalizeAbility(secondary_attack, "SecondaryAttack");
            action1 = initalizeAbility(action1, "Action1");
            action2 = initalizeAbility(action2, "Action2");
            action3 = initalizeAbility(action3, "Action3");
            action4 = initalizeAbility(action4, "Action4");
            action5 = initalizeAbility(action5, "Action5");

            // Subscribe to Events
            this.OnHealthChange += HealthCheck;

            // Initalize State Variables
            _health = max_health;
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

        private void HealthCheck(){
            if (_health <= 0 && last_health > 0){
                OnDeath();
            }
        }

        private void OnDeath(){
            Debug.Log($"{this.name} died");
            hitbox.gameObject.SetActive(false);
            // Tempory animation
            this.transform.Rotate(0,0,90);
            Destroy(this.gameObject, 5.0f);
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