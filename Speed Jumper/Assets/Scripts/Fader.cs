using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public Image image;
    private int alpha = 255;
    public static bool paso = false;
	private void Start () {
        if (!paso) {
            InvokeRepeating("Fade", 0, .005f);
        }
        else {
            Destroy(gameObject);
        }
    }
    private void Fade() {
        alpha--;
        Color c = image.color;
        c.a = (float)alpha / 255f;
        image.color = c;
        if (alpha == 0) {
            paso = true;
            StopCoroutine("Fade");
            Destroy(gameObject);
        }
    }
	
}
