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
        public IntMinMax Octaves;

        private float Modifier = Mathf.Pow(2f, 1.0f / 12f);

        public int NoteFrom = 1;

        public void GetSound(out AudioClip clip, out float volume, out float pitch)
        {
            int octave = UnityEngine.Random.Range(
                Mathf.Clamp(Octaves.min, 1, Octaves.max),
                Octaves.max
                );

            GetSound(octave, out clip, out volume, out pitch);
        }

        public void GetSound(int octave, out AudioClip clip, out float volume, out float pitch)
        {
            clip = Clips[Random.Range(0, Clips.Length)];
            volume = Random.Range(this.Volume.min, this.Volume.max);
            int note = NoteFrom + 12 * octave;
            pitch = Mathf.Pow(Modifier, note);
        }
    }
}