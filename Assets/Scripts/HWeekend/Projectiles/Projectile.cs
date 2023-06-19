using UnityEngine;

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
        if (other != source){
            if (other.CompareTag("Entity")) {
                Destroy(gameObject);
                Debug.Log($"{this.name} hit {other.name}");
            }
            
            if (other.CompareTag("Projectile Blocker")) {
                Destroy(gameObject);
                Debug.Log($"{this.name} hit {other.name}");
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
