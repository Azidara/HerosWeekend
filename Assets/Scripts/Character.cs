using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend{
    public class Character : MonoBehaviour
    {
        public new Transform camera;
        public float speed = 10f;
        public Vector2 respawn_position = new Vector2(0,0);

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
            this.transform.position += new Vector3(x,y,0);
        }

        public void respawn() {
            this.transform.position = new Vector3(respawn_position.x, respawn_position.y, 0);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}