using UnityEngine;
using SmashStronghold.Game.Managers;
using SmashStronghold.Base.Interfaces;

namespace SmashStronghold.Game.Behaviours
{
    public class ColorRandomizer : MonoBehaviour, IColorHandler
    {
        public string ColorGroup;
        private new Renderer renderer;
        private ColorManager manager;

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
            manager = ColorManager.Instance;
            AddToManager();
        }

        private void AddToManager() =>
            manager.Subscribe(this);

        public void RefreshColor() =>
            renderer.material =
            manager.GetRandomColorFromGroup(ColorGroup);
    }
}
