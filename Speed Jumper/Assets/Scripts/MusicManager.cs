using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    
    private AudioSource audioSource;
    public List<AudioClip> Music;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    private void OnLevelWasLoaded(int level) {
        if (Music[level] != null && Music[level] != audioSource.clip) {
            audioSource.Stop();
            audioSource.clip = Music[level];
            audioSource.Play();
        }
    }
}
