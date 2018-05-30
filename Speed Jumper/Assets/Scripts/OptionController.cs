using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    public Slider volumeSlider;
    public LevelChanger levelManager;
    public AudioSource musicManager;

    public Text txtDifficulty;

    public int Difficulty;

    private void Start() {
        float volume = PlayerPrefsManager.GetMasterVolume();
        Difficulty = PlayerPrefsManager.GetDifficulty();
        setDifficulty();
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
    public void setDifficulty() {
        switch (Difficulty) {
            case 2:
                txtDifficulty.text = "Medium";
                break;
            case 3:
                txtDifficulty.text = "Hard";
                break;
            default:
                txtDifficulty.text = "Medium";
                break;
        }
    }
    public void changeDifficulty() {
        switch (Difficulty) {
            case 2:
                PlayerPrefsManager.SetDifficulty( 3 );
                break;
            case 3:
                PlayerPrefsManager.SetDifficulty( 2 );
                break;
            default:
                PlayerPrefsManager.SetDifficulty( 2 );
                break;
        }
        Difficulty = PlayerPrefsManager.GetDifficulty();
        setDifficulty();
    }
}
