using UnityEngine;

namespace HWeekend.Abilities{
    public class EmptyAbility : Ability
    {
        protected override void action(Vector3 position, Vector2 direction, GameObject source = null) {
            // Do Nothing;
        }
    }
}
