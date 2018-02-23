using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Camera myCam;

    private const float KEEP_ASPECT = 16 / 9f;
    private void Start() {
        myCam = GetComponent<Camera>();
        float aspectRatio = Screen.width / ((float)Screen.height);
        float percentage = 1 - (aspectRatio / KEEP_ASPECT);

        myCam.rect = new Rect(0f, (percentage / 2), 1f, (1 - percentage));
    }
}
