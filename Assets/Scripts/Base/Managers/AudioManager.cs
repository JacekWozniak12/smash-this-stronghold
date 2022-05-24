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

        [SerializeField]
        private bool mute = true;
        
        private void Start()
        {
            if(mute) MuteMixers();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                mute = !mute;
                
                if (mute)
                    MuteMixers();
                
                else
                    UnmuteMixers();
            }
        }

        private void UnmuteMixers()
        {
            foreach (AudioMixer mixer in audioMixers)
            {
                mixer.SetFloat("MasterVolume", 0);
            }
        }

        private void MuteMixers()
        {
            foreach (AudioMixer mixer in audioMixers)
            {
                mixer.SetFloat("MasterVolume", -80);
            }
        }
    }
}