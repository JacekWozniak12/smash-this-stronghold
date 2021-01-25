using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class DestroyWhenHealthBelowZero : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Damageable>().HealthZeroOrBelow += Act; 
        }

        private void Act()
        {
            Destroy(gameObject);
        }
    }
}