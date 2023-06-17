using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        //public Animator animator = null;

        public Vector3 move_input;
        public float speed = 10f;
        public Vector2 respawn_position = new Vector2(0,0);
        public Abilities.Ability primary_ability;
        public Abilities.Ability secondary_ability;
        private Rigidbody2D rb;

        void Awake(){
            rb = this.GetComponent<Rigidbody2D>();
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
            //Vector3 movement = move_input * speed;
            /*
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);
            */
            rb.velocity = move_input * speed;
            //this.transform.position += movement * Time.deltaTime;
        }
    }
}