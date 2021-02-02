using UnityEngine;

namespace SmashStronghold.Game.Behaviours.Keyboard
{
    public class InputMoveTransform : MonoBehaviour
    {
        public KeyCode KeyPositive;
        public KeyCode KeyNegative;

        [SerializeField]
        private Vector3 vectorMovement;

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
                transform.position += vectorMovement * speed * Time.deltaTime;
            }
            else
            if (Input.GetKey(KeyNegative))
            {
                transform.position -= vectorMovement * speed * Time.deltaTime;
            }

        }
    }
}