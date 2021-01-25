using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
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
            }
        }
    }

    private void HandleShooting()
    {
        Ray ray = handler.ScreenPointToRay(Input.mousePosition);
        ProjectileSpawn(ray.direction);
    }

    private void ProjectileSpawn(Vector3 direction)
    {
        var copy = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        var rigidbody = copy.AddComponent<Rigidbody>();
        rigidbody.mass = weight;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.AddForce(direction * force, ForceMode.Impulse);
        beforeNextShot = reloadSpeed;
    }
}
