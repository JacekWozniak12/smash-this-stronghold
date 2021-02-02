using UnityEngine;

namespace SmashStronghold.Game.Behaviours.Keyboard
{
    public class InputMoveRigidbody : MonoBehaviour
    {
        public KeyCode KeyPositive;
        public KeyCode KeyNegative;

        [SerializeField]
        private Vector3 vectorMovement;

        [SerializeField]
        private float speed;
        private new Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = rigidbody ?? GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyPositive))
            {
                rigidbody.AddForce(vectorMovement * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            else
            if (Input.GetKey(KeyNegative))
            {
                rigidbody.AddForce(-vectorMovement * speed * Time.deltaTime, ForceMode.Acceleration);
            }
        }
    }
}