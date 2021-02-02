using SmashStronghold.Game.Behaviours;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [RequireComponent(typeof(Damageable))]
    public class Structure : MonoBehaviour
    {
        // [SerializeField]
        // Damageable damageable;

        // [SerializeField]
        // int itemCount; 

        // private void Start()
        // {
        //     damageable = damageable ?? GetComponent<Damageable>();
        //     var arr = damageable.transform.GetComponentsInChildren<Damageable>();
        //     int total = 0;
        //     itemCount = arr.Length;
        //     foreach(var item in arr)
        //     {
        //         int a = (int) item.MaxHealth / 25;
        //         total += a;
        //         item.Damaged += ChildrenDamaged;
        //     }

        //     damageable.SetStartingHealth(total);
            
        // }

        // private void ChildrenDamaged(Damageable obj)
        // {
        //     damageable.Damage(damageable.MaxHealth / itemCount * 5);
        // }
    }
}
