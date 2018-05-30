using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    
    public static void SetMasterVolume(float volume) {
        if (volume > 0f && volume < 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else {
            Debug.LogError("Master volume out of range");
        }
    }
    public static float GetMasterVolume() {
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            SetMasterVolume(0.5f);
        }
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void SetDifficulty(int difficulty) {
        if (difficulty >= 1 && difficulty <= 5) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else {
            Debug.LogError("Difficulty out of range");
        }
    }
    public static int GetDifficulty() {
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY)) {
            SetDifficulty(2);
        }
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
