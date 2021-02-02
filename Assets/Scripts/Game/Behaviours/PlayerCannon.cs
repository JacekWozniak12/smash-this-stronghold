using System.Collections;
using SmashStronghold.Library.HelperL;
using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class PlayerCannon : MonoBehaviour
    {

        [Header("Stats"), SerializeField]
        private FloatMinMax ForceMinimalMaximal;

        [SerializeField]
        private float force = 1500f;

        [SerializeField]
        private float weight = 50f;

        [SerializeField]
        private float reloadSpeed = 1f;

        [Space, SerializeField]
        private FloatMinMax gunXRotationMinimalMaximal;

        [SerializeField]
        private float gunXRotation = 0f;

        [SerializeField]
        private float rotationSpeed = 1f;

        [Space, Header("Asset References"), SerializeField]
        private GameObject projectile;

        [Header("Prefab References"), SerializeField]
        private Transform projectileSpawner;

        [SerializeField]
        private Rigidbody body;

        [SerializeField]
        private Transform cannon;

        private void Start() { }

        private void Update()
        {
            if (beforeNextShot > 0) beforeNextShot -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CannonFire();
            }

        }

        private void CannonForce()
        {

        }

        private void CannonFire()
        {
            if (beforeNextShot <= 0) ProjectileSpawn(cannon.forward, projectileSpawner.position, cannon.rotation).AddComponent<ExplodeOnHit>();
        }

        private float beforeNextShot;

        private GameObject ProjectileSpawn(Vector3 direction, Vector3 position, Quaternion rotation)
        {
            var copy = Instantiate(projectile, position, rotation);
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