using UnityEngine;

namespace SmashStronghold.Game.Behaviours.Keyboard
{
    public class InputRotateTransform : MonoBehaviour
    {
        public KeyCode KeyPositive;
        public KeyCode KeyNegative;

        [SerializeField]
        private Vector3 vectorRotation;

        [SerializeField]
        private float speed;
        private new Transform transform;

        private void Start()
        {
            transform = transform ?? GetComponent<Transform>();
        }

        private void Update()
        {

            if (Input.GetKey(KeyPositive))
            {
                transform.Rotate(vectorRotation * speed * Time.deltaTime);
            }
            else
            if (Input.GetKey(KeyNegative))
            {
                transform.Rotate(-vectorRotation * speed * Time.deltaTime);
            }

        }
    }
}