using System.Collections;
using SmashStronghold.Game.Behaviours;
using UnityEngine;

namespace SmashStronghold.Game.Agents
{
    public class SimpleMouseController : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectile;

        [SerializeField]
        private float reloadSpeed = 1;
        private float beforeNextShot = 0;

        [SerializeField]
        private float force = 500;

        [SerializeField]
        private float weight = 10;

        private Camera handler;

        private void Awake()
        {
            handler = GetComponent<Camera>();
            Cursor.lockState = CursorLockMode.Confined;
        }

        void Update()
        {
            if (beforeNextShot >= 0) beforeNextShot -= Time.deltaTime;
            else
            {
                if (Input.GetMouseButton(0))
                {
                    HandleShooting();
                    return;
                }
                if (Input.GetMouseButton(1))
                {
                    HandleShootingExplosive();
                }
            }
        }

        private void HandleShooting()
        {
            Ray ray = handler.ScreenPointToRay(Input.mousePosition);
            ProjectileSpawn(ray.direction);
        }

        private void HandleShootingExplosive()
        {
            Ray ray = handler.ScreenPointToRay(Input.mousePosition);
            ProjectileSpawn(ray.direction).AddComponent<ExplodeOnHit>();
        }

        private GameObject ProjectileSpawn(Vector3 direction)
        {
            var copy = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            var rigidbody = copy.AddComponent<Rigidbody>();
            rigidbody.mass = weight;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.AddForce(direction * force, ForceMode.Impulse);
            beforeNextShot = reloadSpeed;
            StartCoroutine(KillGameObject(copy));
            return copy;
        }

        private IEnumerator KillGameObject(GameObject go)
        {
            yield return new WaitForSeconds(10);
            if (go != null) Destroy(go);
        }
    }
}

