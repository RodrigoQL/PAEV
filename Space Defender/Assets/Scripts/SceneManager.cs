using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    private AudioSource audioSource;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadLevel(string levelName) {
        audioSource.Play();
        StartCoroutine(WaitLoad(levelName));
    }
    public void Salir() {
        print("Salir");
        Application.Quit();
    }
    IEnumerator WaitLoad(string levelName) {
        yield return new WaitForSeconds(0.2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
    public void LoadDifficulty(int difficulty) {
        GameObject.Find( "GlobalValues" ).GetComponent<GlobalValues>().Difficulty = difficulty;
        audioSource.Play();
        StartCoroutine( WaitLoad( "01_01" ) );
    }
}
