using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public Text txt;
    private int alpha;
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        alpha = 255;
        InvokeRepeating("LoadNextLevel", autoLoadNextLevelAfter,.005f);
    }

    public void LoadLevel(string name) {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel() {
        
        alpha--;
        Color c = txt.color;
        c.a = (float)alpha/255f;
        txt.color = c;
        if (alpha == 0)
            Application.LoadLevel(Application.loadedLevel + 1);
    }
}