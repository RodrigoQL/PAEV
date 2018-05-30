using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform follow;
    public Vector3 offset;
        
    private void Update() {
        if (follow.position.z < 650 && follow.position.z > 120) {
            transform.position = follow.position + offset;
        }
        
    }
}
