using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameController : MonoBehaviour {
    public Text Counter;
    public bool isRunning = false;
    public ParticleSystem particles;
    private int regresive = 3;

    public AudioClip CountSound;
    public AudioClip StartSound;

    private AudioSource audioSource;

    public Transform camera;

    public float Speed;
    
    private void Start() {
        int speedOption = PlayerPrefsManager.GetDifficulty();
        switch (speedOption) {
            case 2:
                Speed = 1.5f;
                break;
            case 3:
                Speed = 2f;
                break;
            default:
                Speed = 1.5f;
                break;
        }
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = CountSound;
        InvokeRepeating("Regresive", 3, 1);
        ThirdPersonCharacter person = GameObject.Find( "ThirdPersonController" ).GetComponent<ThirdPersonCharacter>();
        person.m_AnimSpeedMultiplier = Speed;
        person.m_MoveSpeedMultiplier = Speed;
    }

    private void FixedUpdate() {
        
    }
    public void StartLose() {
        isRunning = false;
        camera.parent = null;
        Invoke( "Lose", 2 );
    }
    private void Lose() {
        SceneManager.LoadScene( "s004-Lose" );
    }
    public void StartWin() {
        isRunning = false;
        camera.parent = null;
        Invoke( "Win", 2 );
    }
    private void Win() {
        SceneManager.LoadScene( "s005-Win" );
    }
    private void Regresive() {
        Counter.text = regresive.ToString();
        regresive--;
        if(regresive == -1) {
            audioSource.clip = StartSound;
            Handheld.Vibrate();
            audioSource.Play();
            Counter.text = string.Empty;
            isRunning = true;
            CancelInvoke("Regresive");
            particles.startColor = new Color(1, 1, 1, 0.35f);
        }
        else {
            audioSource.Play();
        }
    }
}
