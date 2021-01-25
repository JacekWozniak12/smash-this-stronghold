using UnityEngine;

namespace SmashStronghold.Library
{
    public static class ColorL
    {
        /// <summary>
        /// Creates new color within [(0,0,0,1), (255,255,255,1)]
        /// </summary>
        public static Color GetRandomColorRGB()
        {
            return new Color(Random.Range(0, 256),
                             Random.Range(0, 256),
                             Random.Range(0, 256),
                             1);
        }

        /// <summary>
        /// Creates new color between colors.
        /// </summary>
        public static Color GetRandomColorRGB(Color min, Color max)
        {
            return GetRandomColorRGB(min.r, max.r, min.g, max.g, min.b, max.b, min.a, max.a);
        }

        /// <summary>
        /// Creates new color within specified min, max for Red, Green and Blue. Alpha = 1.
        /// </summary>
        public static Color GetRandomColorRGB(float rMin, float rMax, float gMin, float gMax, float bMin, float bMax)
        {
            return GetRandomColorRGB(rMin, rMax, gMin, gMax, bMin, bMax, 1);
        }

        /// <summary>
        /// Creates new color within specified min, max for Red, Green and Blue with adjustable alpha.
        /// </summary>
        public static Color GetRandomColorRGB(float rMin, float rMax, float gMin, float gMax, float bMin, float bMax, float alpha)
        {
            return GetRandomColorRGB(rMin, rMax, gMin, gMax, bMin, bMax, alpha, alpha);
        }

        /// <summary>
        /// Creates new color within specified min, max for Red, Green, Blue and Alpha.
        /// </summary>
        public static Color GetRandomColorRGB(float rMin, float rMax, float gMin, float gMax, float bMin, float bMax, float aMin, float aMax)
        {
            rMin = Mathf.Clamp(rMin, 0, 255);
            rMax = Mathf.Clamp(rMax, 0, 255);
            gMin = Mathf.Clamp(gMin, 0, 255);
            gMax = Mathf.Clamp(gMax, 0, 255);
            bMin = Mathf.Clamp(bMin, 0, 255);
            bMax = Mathf.Clamp(bMax, 0, 255);
            aMin = Mathf.Clamp01(aMin);
            aMax = Mathf.Clamp01(aMax);

            return new Color(Random.Range(rMin, rMax),
                             Random.Range(gMin, gMax),
                             Random.Range(bMin, bMax),
                             Random.Range(aMin, aMax));
        }
    }
}