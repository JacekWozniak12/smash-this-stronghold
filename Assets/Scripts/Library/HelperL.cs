using System;

namespace SmashStronghold.Library.HelperL
{
    [Serializable]
    public struct FloatMinMax
    {
        public float min;
        public float max;

        public FloatMinMax(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }

    [Serializable]
    public struct IntMinMax
    {
        public int min;
        public int max;

        public IntMinMax(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}