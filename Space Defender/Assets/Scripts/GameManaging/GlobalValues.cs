using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalValues : MonoBehaviour {

    private static GlobalValues instance = null;

    public float Speed = 2;
    public int Cannons = 1;
    public float FireRate = 1;
    public int CurrentHealth = 10;
    public int TotalHealth = 10;
    public int Scrap = 0;
    public string Level = "MainMenu";

    public Text CannonsText;
    public Text FireRateText;
    public Text SpeedText;
    public Text HealthText;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateStats() {
        CannonsText.text = "Cannons:  " + Cannons;
        SpeedText.text = "Speed:  " + Speed;
        FireRateText.text = "Fire Rate:  " + FireRate;
        HealthText.text = "Health: " + CurrentHealth + " / " + TotalHealth;
    }

    public void ForceLoad() {
        CannonsText = GameObject.Find("CannonsLbl").GetComponent<Text>();
        SpeedText = GameObject.Find("SpeedLbl").GetComponent<Text>();
        HealthText = GameObject.Find("HealthLbl").GetComponent<Text>();
        FireRateText = GameObject.Find("FireRateLbl").GetComponent<Text>();
    }



}
