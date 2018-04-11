using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    public Slider volumeSlider;
    public LevelChanger levelManager;
    public AudioSource musicManager;

    private void Start() {
        float volume = PlayerPrefsManager.GetMasterVolume();
        volumeSlider.value = volume;
        musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    public void changeVolume() {
        float volume = volumeSlider.value;
        if (musicManager != null) {
            musicManager.volume = volume;
        }
        PlayerPrefsManager.SetMasterVolume(volume);
    }
}
