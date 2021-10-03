using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    public float GetCurrentVolume() {
        return audioSource.volume;
    }
}
