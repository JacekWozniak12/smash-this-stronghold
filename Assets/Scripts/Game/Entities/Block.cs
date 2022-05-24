using SmashStronghold.Base.Data;
using SmashStronghold.Base.Managers;
using SmashStronghold.Game.Behaviours;
using UnityEngine;
using UnityEngine.Audio;

namespace SmashStronghold.Game.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private MusicalAudioData hitData;

        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        [Range(1, 20)]
        private float sleepThreshold = 2;

        private AudioSource audioSource;
        private new Rigidbody rigidbody;

        private void Start()
        {
            gameObject.AddComponent<ColorRandomizer>().ColorGroup = "Blocks";
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = AudioManager.Instance.AudioMixers.Find(x => x.name == "Main").FindMatchingGroups("Blocks")[0];
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.sleepThreshold = sleepThreshold;
        }

        private bool CanPlaySound() => delayBeforeNext <= 0;

        private float time = 0.5f;
        private float delayBeforeNext;

        private void FixedUpdate()
        {
            if (delayBeforeNext > 0) delayBeforeNext -= Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (CanPlaySound() && (other.relativeVelocity.magnitude > 20 || (other.gameObject.tag == "ground" && other.relativeVelocity.magnitude > 2)))
            {
                hitData.GetSound(out AudioClip clip, out float volume, out float pitch);
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.PlayOneShot(clip);
                delayBeforeNext = time;
            }
        }
    }
}
