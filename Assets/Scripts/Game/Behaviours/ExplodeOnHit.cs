using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ExplodeOnHit : MonoBehaviour
    {
        float force = 500f;
        float range = 15f;
        float upwardModifier = 20f;

        private void OnCollisionEnter(Collision other)
        {
            var pos = transform.position;
            var objects = Physics.OverlapSphere(pos, 5f);
            foreach (var item in objects)
            {
                try
                {
                    item?.
                    gameObject?.
                    GetComponent<Rigidbody>()?.
                    AddExplosionForce(force, pos, range, upwardModifier, ForceMode.Impulse);
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