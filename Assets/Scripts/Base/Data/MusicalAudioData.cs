using SmashStronghold.Base.Interfaces;
using SmashStronghold.Library.HelperL;
using UnityEngine;

namespace SmashStronghold.Base.Data
{
    [CreateAssetMenu(fileName = "MusicalAudioData", menuName = "smash-this-stronghold/MusicalAudioData", order = 0)]
    public class MusicalAudioData : ScriptableObject, IAudioDeliver
    {
        public AudioClip[] clips;
        public FloatMinMax volume;

        public IntMinMax range;
        private float Modifier = Mathf.Pow (2f,1.0f/12f);
        
        public void GetSound(out AudioClip clip, out float volume, out float pitch)
        {
            clip = clips[Random.Range(0, clips.Length)];
            volume = Random.Range(this.volume.min, this.volume.max);
            
            float note = Random.Range(this.range.min, this.range.max);
            pitch = Mathf.Pow(Modifier, note);
        }
    }
}