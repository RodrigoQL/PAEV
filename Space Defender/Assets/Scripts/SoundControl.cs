using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

    private static SoundControl instance = null;
	// Use this for initialization
	void Awake () {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
