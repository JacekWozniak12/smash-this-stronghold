using SmashStronghold.Base.Managers;
using SmashStronghold.Base.Interfaces;
using UnityEngine;
using System.Collections.Generic;

namespace SmashStronghold.Game.Managers
{
    public class ColorManager : BaseManager<ColorManager>
    {
        public Color min;
        public Color max;

        [SerializeField]
        List<IColorHandler> handlers = new List<IColorHandler>(); 

        [ContextMenu("Refresh Colors")]
        private void RefreshColors()
        {
            handlers.ForEach(x => x.RefreshColor());
        }

        public void Subscribe(IColorHandler item)
        {
            handlers.Add(item);
        }

        public void UnSubscribe(IColorHandler item)
        {
            handlers.Remove(item);
        }
    }
}