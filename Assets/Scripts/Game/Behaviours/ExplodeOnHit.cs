using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ExplodeOnHit : MonoBehaviour
    {
        private float force = 150f, 
        range = 15f, upwardModifier = 15f;

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