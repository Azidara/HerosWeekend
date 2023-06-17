using UnityEngine;
using AzMath;


namespace HWeekend.Abilities{
    public class ProjectileAbility : Ability
    {
        public float speed = 5.0f;
        public float spread = 45f; // Spread in degrees for multiple
        public float inaccuracy = 0.0f; // Random inaccuracy;
        public float amount = 1;
        public float duration = 2.0f;
        public GameObject projectilePrefab;

        protected override void action(Vector3 position, Vector2 direction, GameObject source = null) {
            // Spawn "amount" of projectiles
            for (int i=0; i < amount; i++) {
                // Add offsets for accuracy and spread position
                PolarVec2 polar_dir = PolarVec2.CartesianToPolar(direction);
                polar_dir.θ += Random.Range(-inaccuracy/2, inaccuracy/2);
                if (amount > 1){polar_dir.θ += (spread/(amount-1)) * i - spread/2;}

                Vector2 final_direction = PolarVec2.PolartoCartesian(polar_dir);
                GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
                projectileGO.GetComponent<Projectile>().velocity = final_direction.normalized * speed;
                if (source != null){ projectileGO.GetComponent<Projectile>().source = source;}
                projectileGO.transform.Rotate(0.0f,0.0f, Mathf.Atan2(final_direction.y, final_direction.x) * Mathf.Rad2Deg);
                Destroy(projectileGO, duration);
            }
        }
    }
}
