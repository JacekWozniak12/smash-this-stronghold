using System.Collections;
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
            StartCoroutine(WaitAndDie());
        }

        private IEnumerator WaitAndDie()
        {
            while(transform.localScale.x > 0.5)
            {
                transform.localScale *= 0.97f;
                yield return new WaitForSeconds(0.1f);
            }
            Destroy(gameObject);
        }
    }
}