using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionControl : MonoBehaviour {

    private GlobalValues globalValues;
    private AudioSource audioSource;

    public Text CannonsCost;
    public Text SpeedCost;
    public Text FireRateCost;
    public Text HealthCost;

    private void Start() {
        globalValues = GameObject.Find( "GlobalValues" ).GetComponent<GlobalValues>();
        audioSource = GetComponent<AudioSource>();
        globalValues.ForceLoad();
        UpdateStats();
    }
    public void UpdateStats() {
        globalValues.UpdateStats();
        CannonsCost.text = "&" + GetCost( "Cannons" ).ToString();
        SpeedCost.text = "&" + GetCost( "Speed" ).ToString();
        HealthCost.text = "&" + GetCost( "Health" ).ToString();
        FireRateCost.text = "&" + GetCost( "FireRate" ).ToString();
    }
    public void ImproveStat(string choice) {
        int cost = GetCost( choice );
        if(globalValues.Scrap >= cost) {
            audioSource.Play();
            switch (choice) {
                case "Speed":
                    globalValues.Speed += 1;
                    break;
                case "Cannons":
                    globalValues.Cannons += 1;
                    break;
                case "Health":
                    globalValues.TotalHealth += 5;
                    globalValues.CurrentHealth += 5;
                    break;
                case "FireRate":
                    globalValues.FireRate += 1;
                    break;
            }
            globalValues.Scrap -= cost;
        }
        UpdateStats();
    }
    public int GetCost(string choice) {
        int quantity = 0;
        int base_value = 100;
        switch (choice) {
            case "Speed":
                quantity = (int)globalValues.Speed - 1;
                break;
            case "Cannons":
                quantity = globalValues.Cannons;
                break;
            case "Health":
                quantity = (globalValues.TotalHealth) / 5;
                break;
            case "FireRate":
                quantity = (int)globalValues.FireRate;
                break;
        }
        return quantity * base_value;
    }
    public void Heal(int health) {
        if (globalValues.Scrap > health * 3) {
            audioSource.Play();
            globalValues.CurrentHealth = Mathf.Clamp( globalValues.CurrentHealth + health, 0, globalValues.TotalHealth );
            UpdateStats();
            globalValues.Scrap -= ( health * 3 );
        }
    }
    public void StartMission(string mission) {
        StartCoroutine( WaitLoad( mission ) );
    }
    IEnumerator WaitLoad(string levelName) {
        yield return new WaitForSeconds( 0.2f );
        UnityEngine.SceneManagement.SceneManager.LoadScene( levelName );
    }
}
public enum StatChoice {
    Speed, Cannons, FireRate, Health
}
