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

        private bool mute = true;
        private void Start()
        {
            if(mute) muteMixers();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                mute = !mute;
                if (mute)
                {
                    muteMixers();
                }
                else
                {
                    unmuteMixers();
                }
            }
        }

        private void unmuteMixers()
        {
            foreach (AudioMixer mixer in audioMixers)
            {
                mixer.SetFloat("MasterVolume", 0);
            }
        }

        private void muteMixers()
        {
            foreach (AudioMixer mixer in audioMixers)
            {
                mixer.SetFloat("MasterVolume", -80);
            }
        }
    }
}