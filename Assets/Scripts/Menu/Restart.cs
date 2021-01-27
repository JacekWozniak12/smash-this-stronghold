using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmashStronghold.Menu.Behaviours
{
    public class Restart : MonoBehaviour
    {
        string scene;
        
        [SerializeField]
        KeyCode keyCode = KeyCode.F7;

        private void Awake()
        {
            scene = SceneManager.GetActiveScene().name;
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode)) SceneManager.LoadScene(scene);
        }
    }
}