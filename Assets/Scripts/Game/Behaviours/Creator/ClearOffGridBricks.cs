using SmashStronghold.Game.Entities;
using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ClearOffGridBricks : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                var items = FindObjectsOfType<Block>();
                foreach (var item in items)
                {
                    var t = item.gameObject.transform;

                    if (t.position.x % 0.25f > 0.1f ||
                        t.position.y % 0.25f > 0.1f ||
                        t.position.z % 0.25f > 0.1f
                    )
                        Destroy(item.gameObject);
                }
            }
        }
    }
}