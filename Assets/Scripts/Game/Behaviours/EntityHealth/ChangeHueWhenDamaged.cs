using System;
using UnityEngine;

namespace SmashStronghold.Game.Behaviours
{
    public class ChangeHueWhenDamaged : MonoBehaviour
    {
        Color starting;
        Material modifiedMaterial;
        Damageable damageable;

        private void Awake()
        {
            damageable = GetComponent<Damageable>();
            damageable.Damaged += ChangeColor;
            damageable.Healed += ChangeColor;
        }

        private void ChangeColor()
        {
            if (modifiedMaterial == null)
            {
                modifiedMaterial = GetComponent<Renderer>().material;
                starting = modifiedMaterial.color;
            }
            Color temp = starting;
            
            Color.RGBToHSV(temp, out float hue, out float saturation, out float value);
            float tempHealth = (float) damageable.Health / (float) damageable.MaxHealth;
            saturation = Mathf.Lerp(0, saturation, tempHealth);
            value = Mathf.Lerp(0, value, tempHealth);

            modifiedMaterial.color = Color.HSVToRGB(hue, saturation, value);
        }
    }
}