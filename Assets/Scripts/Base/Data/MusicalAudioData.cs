using SmashStronghold.Base.Interfaces;
using SmashStronghold.Library.HelperL;
using UnityEngine;

namespace SmashStronghold.Base.Data
{
    [CreateAssetMenu(fileName = "MusicalAudioData", menuName = "smash-this-stronghold/MusicalAudioData", order = 0)]
    public class MusicalAudioData : ScriptableObject, IAudioDeliver
    {
        public AudioClip[] Clips;
        public FloatMinMax Volume;

        public IntMinMax Range;
        private float Modifier = Mathf.Pow(2f, 1.0f / 12f);

        [Range(1, 12)]
        public int SemitoneJump = 1;

        public void GetSound(out AudioClip clip, out float volume, out float pitch)
        {
            clip = Clips[Random.Range(0, Clips.Length)];
            volume = Random.Range(this.Volume.min, this.Volume.max);
            int note = Random.Range(this.Range.min, this.Range.max);
            note = note / SemitoneJump;
            pitch = Mathf.Pow(Modifier, note);
        }
    }
}