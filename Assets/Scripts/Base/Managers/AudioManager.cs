using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SmashStronghold.Base.Managers
{
    public class AudioManager : BaseManager<AudioManager>
    {
        [SerializeField]
        private List<AudioMixer> audioMixers;

        public List<AudioMixer> AudioMixers
        {
            get { return audioMixers; }
            set { audioMixers = value; }
        }

        private bool mute;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                mute = !mute;
                if (mute)
                {
                    foreach (AudioMixer mixer in audioMixers)
                    {
                        mixer.SetFloat("MasterVolume", -80);
                    }
                }
                else
                {
                    foreach (AudioMixer mixer in audioMixers)
                    {
                        mixer.SetFloat("MasterVolume", 0);
                    }
                }    
            }
        }

    }
}