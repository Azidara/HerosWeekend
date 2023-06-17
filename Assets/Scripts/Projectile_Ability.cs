using UnityEngine;
using AzMath;


namespace HWeekend.Abilities{
    public class Projectile_Ability : Ability
    {
        public float speed = 5.0f;
        public float spread = 45f; // Spread in degrees for multiple
        public float inaccuracy = 0.0f; // Random inaccuracy;
        public float amount = 1;
        public float duration = 2.0f;
        public GameObject projectilePrefab;

        protected override void action(Vector3 position, Vector2 direction){
            System.Random rng = new System.Random();
            for (int i=0; i < amount; i++) {
                // Add directional offsets for spread and accuracy
                PolarVec2 polar_dir = PolarVec2.CartesianToPolar(direction);
                float acc_offset = Random.Range(-inaccuracy/2, inaccuracy/2);
                polar_dir.θ += acc_offset;
                float spread_offset = 0.0f;
                if (amount > 1){
                    spread_offset = (spread/(amount-1)) * i - spread/2;
                    polar_dir.θ += spread_offset;
                }
                
                
                Vector2 olddirection = direction;
                Vector2 finaldirection = PolarVec2.PolartoCartesian(polar_dir);
                Debug.Log($"Original Direction : {olddirection.ToString()}\n New Direction : {finaldirection.ToString()}\n accuracy : {acc_offset}\n spread_offset : {spread_offset}");
                GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
                projectileGO.GetComponent<Rigidbody2D>().velocity = finaldirection.normalized * speed;
                projectileGO.transform.Rotate(0.0f,0.0f, Mathf.Atan2(finaldirection.y, finaldirection.x) * Mathf.Rad2Deg);
                Destroy(projectileGO, duration);
            }
        }
    }
}
