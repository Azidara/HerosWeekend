using UnityEngine;

namespace HWeekend{
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        public Vector2 velocity = new Vector2(0.0f, 0.0f);
        public GameObject source;

        // Function that gets called when the projectile collider "is Trigger" option is false
        private void OnCollisionEnter2D(Collision2D collision){
            evalInteraction(collision.gameObject);
        }

        // Function that gets called when the projectile collider "is Trigger" option is true
        private void OnTriggerEnter2D(Collider2D other){
            evalInteraction(other.gameObject);
        }

        private void evalInteraction(GameObject other){
            // Check if collision is with source
            Collider2D[] source_colliders = source.GetComponentsInChildren<Collider2D>();
            bool collided_with_source = false;
            foreach (Collider2D c in source_colliders){
                if (c.gameObject == other.gameObject){
                    collided_with_source = true;
                }
            }

            if (!collided_with_source){
                if (other.CompareTag("Entity")) {
                    Character c = other.GetComponentInParent<Character>();
                    if (c != null){
                        c.health -= 1;
                    }
                    Destroy(gameObject);
                    Debug.Log($"{this.name} hit {other.name}");
                }
                
                if (other.CompareTag("Projectile Blocker")) {
                    Destroy(gameObject);
                }
            }
        }

        

        // Update is called once per frame
        void Update()
        {
            Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

            this.transform.position = newPosition;
        }
    }
}
