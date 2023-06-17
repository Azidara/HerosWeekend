using UnityEngine;

namespace HWeekend.Abilities{
    public class Projectile_Ability : Ability
    {
        public float speed = 5.0f;
        //public float breadth;
        //public float inaccuracy = 0.0f;
        public float amount = 1;
        public float duration = 2.0f;
        public GameObject projectilePrefab;

        protected override void action(Vector3 position, Vector2 direction){
            for (int i=0; i < amount; i++) {
                GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
                projectileGO.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
                projectileGO.transform.Rotate(0.0f,0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                Destroy(projectileGO, duration);
            }
        }
    }
}
