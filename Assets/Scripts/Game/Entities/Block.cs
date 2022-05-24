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
        private AudioMixer audioMixer;

        [SerializeField]
        [Range(1, 20)]
        private float sleepThreshold = 2;

        private AudioSource audioSource;
        private new Rigidbody rigidbody;

        private AudioRandomizer audioRandomizer;

        private void Start()
        {
            gameObject.AddComponent<ColorRandomizer>().ColorGroup = "Blocks";
            audioRandomizer = gameObject.AddComponent<AudioRandomizer>();
            audioRandomizer.AudioGroup = "Blocks";

            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
            audioSource.outputAudioMixerGroup =
                AudioManager.Instance.AudioMixers.Find(x => x.name == "Main").
                FindMatchingGroups("Blocks")[0];

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
            AudioClipData hitData = audioRandomizer.GetAudio();

            if (CanPlaySound() && ShouldPlaySound(other))
            {
                audioSource.volume = hitData.Volume;
                audioSource.pitch = hitData.Pitch;
                audioSource.PlayOneShot(hitData.Clip);
                delayBeforeNext = time;
            }
        }

        private bool ShouldPlaySound(Collision other)
        {
            return (other.relativeVelocity.magnitude > 20 || (other.gameObject.tag == "ground" && other.relativeVelocity.magnitude > 2));
        }
    }
}
