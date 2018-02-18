using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {
    
    private Material mat;
    public float LoopTime;
    private Vector2 direction;

	void Start () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        mat.mainTexture.wrapMode = TextureWrapMode.Repeat;

        Transform transform = GetComponent<Transform>();
        
        if (transform.rotation.eulerAngles.z == 90) direction = Vector2.right;
        else if (transform.rotation.eulerAngles.z == 180) direction = Vector2.down;
        else if (transform.rotation.eulerAngles.z == 270) direction = Vector2.left;
        else direction = Vector2.up;

    }
	
	void Update () {
        Vector2 offset = mat.mainTextureOffset;
        offset.y += (Time.deltaTime / LoopTime) * direction.y;
        offset.x += (Time.deltaTime / (LoopTime * 20)) * direction.y;
        mat.mainTextureOffset = offset;
	}
}
