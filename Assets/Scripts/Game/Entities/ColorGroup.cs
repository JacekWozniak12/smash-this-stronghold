using System;
using SmashStronghold.Base.Managers;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [Serializable]
    public class ColorGroup
    {
        [SerializeField]
        private string groupName;

        [SerializeField]
        Color min;

        [SerializeField]
        Color max;

        [SerializeField]
        Material material;

        [SerializeField]
        Material[] materialVariations;

        public string GroupName { get => groupName; private set => groupName = value; }

        public ColorGroup(string name, Color min, Color max, int amount, Material material)
        {
            groupName = name;
            this.min = min;
            this.max = max;
            this.material = material;
            materialVariations = new Material[amount];

            for (int i = 0; i < amount; i++)
            {
                materialVariations[i] = CreateRandomMaterial(material);
            }
        }

        [ContextMenu("Generate Material Variations")]
        public void GenerateVariations()
        {
            for (int i = 0; i < materialVariations.Length; i++)
            {
                materialVariations[i] = CreateRandomMaterial(material);
            }
        }

        private Material CreateRandomMaterial(Material original)
        {
            Material copy = new Material(original);
            Color.RGBToHSV(min, out float hMin, out float sMin, out float vMin);
            Color.RGBToHSV(max, out float hMax, out float sMax, out float vMax);
            copy.color = UnityEngine.Random.ColorHSV(hMin, hMax, sMin, sMax, vMin, vMax);
            copy.enableInstancing = true;
            return copy;
        }

        public Material GetRandomMaterial()
        {
            return materialVariations[UnityEngine.Random.Range(0, materialVariations.Length)];
        }

        public Material GetMaterial(int index)
        {
            return materialVariations[index];
        }
    }
}