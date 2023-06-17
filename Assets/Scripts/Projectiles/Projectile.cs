using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject source;

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject other = collision.gameObject;
        if (other != source){
            if (other.CompareTag("Entity")) {
                Destroy(gameObject);
                Debug.Log(other.name);
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
