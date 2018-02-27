using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour {

    private static GlobalValues instance = null;

    public float Speed;
    public float FireRate;
    public int Cannons;
    public int Health;
    public string Level;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

}
