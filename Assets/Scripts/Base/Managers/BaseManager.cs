using UnityEngine;

namespace SmashStronghold.Base.Managers
{
    public abstract class BaseManager<T> : MonoBehaviour where T : BaseManager<T>
    {
        private static T instance;

        public static T Instance
        {
            get => instance;
            private set { }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject.GetComponent<T>());
                Debug.Log($"Component of type {typeof(T)} was destroyed on {this.gameObject}");
            }
            else instance = this as T;
        }
    }
}