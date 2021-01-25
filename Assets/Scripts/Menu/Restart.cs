using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmashStronghold.Menu.Behaviours
{
    public class Restart : MonoBehaviour
    {
        string scene;

        private void Awake()
        {
            scene = SceneManager.GetActiveScene().name;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(scene);
        }
    }
}