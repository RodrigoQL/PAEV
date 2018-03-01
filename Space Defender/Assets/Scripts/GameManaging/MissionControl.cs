using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionControl : MonoBehaviour {

    private GlobalValues globalValues;
    private AudioSource audioSource;

    private void Start() {
        globalValues = GameObject.Find( "GlobalValues" ).GetComponent<GlobalValues>();
        audioSource = GetComponent<AudioSource>();
        globalValues.ForceLoad();
        globalValues.UpdateStats();
    }
    public void ImproveStat(string choice) {
        if(globalValues.Scrap > 100) {
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
            globalValues.Scrap -= 100;
        }
        globalValues.UpdateStats();
    }
    public void Heal(int health) {
        if (globalValues.Scrap > health * 3) {
            audioSource.Play();
            globalValues.CurrentHealth = Mathf.Clamp( globalValues.CurrentHealth + health, 0, globalValues.TotalHealth );
            globalValues.UpdateStats();
            globalValues.Scrap -= ( health * 3 );
        }
    }
    public void StartMission(string mission) {
        StartCoroutine( WaitLoad( "01_01" ) );
    }
    IEnumerator WaitLoad(string levelName) {
        yield return new WaitForSeconds( 0.2f );
        UnityEngine.SceneManagement.SceneManager.LoadScene( levelName );
    }
}
public enum StatChoice {
    Speed, Cannons, FireRate, Health
}
