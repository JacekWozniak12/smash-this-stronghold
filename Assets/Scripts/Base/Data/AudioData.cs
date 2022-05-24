using SmashStronghold.Base.Interfaces;
using SmashStronghold.Library.HelperL;
using UnityEngine;

namespace SmashStronghold.Base.Data
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "smash-this-stronghold/AudioData", order = 0)]
    public class AudioData : ScriptableObject, IAudioDeliver
    {
        public AudioClip[] clips;
        public FloatMinMax volume;
        public FloatMinMax pitch;

        public void GetSound(out AudioClip clip, out float volume, out float pitch)
        {
            clip = clips[Random.Range(0, clips.Length)];
            volume = Random.Range(this.volume.min, this.volume.max);
            pitch = Random.Range(this.pitch.min, this.pitch.max);
        }

        public AudioClipData GetSound()
        {
            AudioClipData data = new AudioClipData();
            data.Clip = clips[Random.Range(0, clips.Length)];
            data.Volume = Random.Range(this.volume.min, this.volume.max);
            data.Pitch = Random.Range(this.pitch.min, this.pitch.max);

            return data;
        }
    }

    [System.Serializable]
    public struct AudioClipData
    {
        public AudioClip Clip;
        public float Volume;
        public float Pitch;

        public AudioClipData(AudioClip clip, float volume, float pitch)
        {
            Clip = clip;
            Volume = volume;
            Pitch = pitch;
        }
    }
}