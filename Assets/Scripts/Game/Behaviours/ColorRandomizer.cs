using UnityEngine;
using SmashStronghold.Library;
using SmashStronghold.Game.Managers;
using SmashStronghold.Base.Interfaces;

namespace SmashStronghold.Game.Behaviours
{
    public class ColorRandomizer : MonoBehaviour, IColorHandler
    {
        [SerializeField]
        private Color min = Color.black;

        [SerializeField]
        private Color max = Color.cyan;

        [SerializeField]
        private bool RGB = false;

        [SerializeField]
        private bool getFromColorManager = true;

        private void Awake()
        {
            UpdateData();
            AddToManager();
            RefreshColor();
        }

        private void AddToManager()
        {
            ColorManager.Instance.Subscribe(this);
        }

        private void UpdateData()
        {
            if (getFromColorManager)
            {
                min = ColorManager.Instance.min;
                max = ColorManager.Instance.max;
            }
        }

        public void RefreshColor()
        {
            UpdateData();
            if (RGB) SetMaterialFromRGB();
            else SetMaterialFromHSV();   
        }

        private void SetMaterialFromHSV()
        {
            Color.RGBToHSV(min, out float hMin, out float sMin, out float vMin);
            Color.RGBToHSV(max, out float hMax, out float sMax, out float vMax);
            GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV(hMin, hMax, sMin, sMax, vMin, vMax);
        }

        private void SetMaterialFromRGB()
        {
            GetComponent<MeshRenderer>().material.color = ColorL.GetRandomColorRGB(min, max);
        }
    }
}
