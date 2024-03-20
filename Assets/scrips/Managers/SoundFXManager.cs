using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private Dictionary<AudioClip, AudioSource> activeSounds = new Dictionary<AudioClip, AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXCLip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        if (activeSounds.ContainsKey(audioClip))
        {
            // If this sound is already playing and we don't want to overlap, we can just return or stop it before playing again.
            StopSoundFXClip(audioClip);
        }

        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        activeSounds[audioClip] = audioSource;

        // Automatically remove the sound from the dictionary when it finishes playing
        StartCoroutine(RemoveSoundFromDictionaryAfterPlay(audioClip, audioSource.clip.length));
    }

    public void StopSoundFXClip(AudioClip audioClip)
    {
        if (activeSounds.TryGetValue(audioClip, out AudioSource audioSource))
        {
            Destroy(audioSource.gameObject);
            activeSounds.Remove(audioClip);
        }
    }

    private IEnumerator RemoveSoundFromDictionaryAfterPlay(AudioClip audioClip, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (activeSounds.ContainsKey(audioClip))
        {
            AudioSource sourceToRemove = activeSounds[audioClip];
            if (sourceToRemove != null)
            {
                Destroy(sourceToRemove.gameObject);
            }
            activeSounds.Remove(audioClip);
        }
    }
}
