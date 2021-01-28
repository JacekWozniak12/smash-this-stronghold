using SmashStronghold.Game.Entities;
using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ClearRotatedBricks : MonoBehaviour
    {
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                var items = FindObjectsOfType<Block>();
                foreach(var item in items)
                {
                    if(item.transform.eulerAngles.x > 1 || item.transform.eulerAngles.x < -1)
                    Destroy(item.gameObject);
                }
            }
        }
    }
}