using UnityEngine;
using SmashStronghold.Library;
using SmashStronghold.Game.Managers;
using SmashStronghold.Base.Interfaces;

namespace SmashStronghold.Game.Behaviours
{
    public class ColorRandomizer : MonoBehaviour, IColorHandler
    {
        public string colorGroup;

        private void Awake()
        {
            AddToManager();
        }

        private void AddToManager()
        {
            ColorManager.Instance.Subscribe(this);
        }

        public void RefreshColor()
        {
            GetComponent<Renderer>().material = ColorManager.Instance.GetRandomColorFromGroup(colorGroup);
        }
    }
}
