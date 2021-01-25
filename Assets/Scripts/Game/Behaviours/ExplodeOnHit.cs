using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ExplodeOnHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var pos = transform.position;
            var objects = Physics.OverlapSphere(pos, 5f);
            foreach (var item in objects)
            {
                try
                {
                    item?.gameObject?.GetComponent<Rigidbody>()?.AddExplosionForce(500f, pos, 5f, 25f, ForceMode.Impulse);
                }
                catch (UnityEngine.MissingComponentException e)
                {
                    Debug.LogWarning(e);
                }
            }
            Destroy(gameObject);
        }
    }
}