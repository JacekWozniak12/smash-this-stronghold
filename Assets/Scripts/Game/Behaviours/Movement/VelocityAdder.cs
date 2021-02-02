using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class VelocityAdder : MonoBehaviour
    {
        [SerializeField]
        private float force = 1500;

        [SerializeField]
        private Vector3 direction = Vector3.left;

        [SerializeField]
        private bool startAtAwake;

        private void AddVelocity()
        {
            GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }

        private void Awake()
        {
            if(startAtAwake) AddVelocity();
        }
    }
}


