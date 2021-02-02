using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class InputRotateRigidbody : MonoBehaviour
    {
        public KeyCode KeyPositive;
        public KeyCode KeyNegative;


        [SerializeField]
        private Vector3 vectorRotation;

        [SerializeField]
        private float speed;
        private new Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = rigidbody ?? GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyPositive))
            {
                rigidbody.AddRelativeTorque(vectorRotation * speed * Time.deltaTime);
            }
            else
            if (Input.GetKey(KeyNegative))
            {
                rigidbody.AddRelativeTorque(-vectorRotation * speed * Time.deltaTime);
            }

        }
    }
}