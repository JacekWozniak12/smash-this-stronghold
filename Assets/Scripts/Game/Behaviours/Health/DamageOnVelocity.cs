using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class DamageOnVelocity : MonoBehaviour
    {
        int damage = 125;
        float velocityToFullDamage = 50;
        float velocityTreshold = 1;
        Damageable damageable;

        private void Awake()
        {
            damageable = gameObject.GetComponent<Damageable>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.relativeVelocity.magnitude < velocityTreshold) return;
            int tempDamage = (int)Mathf.Lerp(0, damage, other.relativeVelocity.magnitude / velocityToFullDamage);
            damageable.Damage(tempDamage);
        }
    }
}