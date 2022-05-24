using UnityEngine;
using System.Collections;

namespace SmashStronghold.Game.Player
{
    public class FlyCamera : MonoBehaviour
    {
        [SerializeField]
        private float mainSpeed = 5.0f, shiftAdd = 25.0f, 
        maxShift = 1000.0f, camSensor = 0.25f, totalRun = 1.0f;

        private Vector3 lastMouse = new Vector3(255, 255, 255);

        private void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                lastMouse = Input.mousePosition;
            }

            if (Input.GetMouseButton(2))
            {
                lastMouse = Input.mousePosition - lastMouse;

                lastMouse = new Vector3(
                    -lastMouse.y * camSensor,
                    lastMouse.x * camSensor,
                    0);

                lastMouse = new Vector3(
                    transform.eulerAngles.x + lastMouse.x,
                    transform.eulerAngles.y + lastMouse.y,
                    0);

                transform.eulerAngles = lastMouse;
                lastMouse = Input.mousePosition;

                Vector3 input = GetBaseInput();

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    totalRun += Time.deltaTime;
                    input = input * totalRun * shiftAdd;
                    input.x = Mathf.Clamp(input.x, -maxShift, maxShift);
                    input.y = Mathf.Clamp(input.y, -maxShift, maxShift);
                    input.z = Mathf.Clamp(input.z, -maxShift, maxShift);
                }
                else
                {
                    totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                    input = input * mainSpeed;
                }

                input = input * Time.deltaTime;

                transform.Translate(input);
            }
        }

        private Vector3 GetBaseInput()
        {
            Vector3 velocity = new Vector3();

            if (Input.GetKey(KeyCode.W))
                velocity += new Vector3(0, 0, 1);

            if (Input.GetKey(KeyCode.S))
                velocity += new Vector3(0, 0, -1);

            if (Input.GetKey(KeyCode.A))
                velocity += new Vector3(-1, 0, 0);

            if (Input.GetKey(KeyCode.D))
                velocity += new Vector3(1, 0, 0);

            return velocity;
        }
    }
}