using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    private Rigidbody rigidbody;
    private AudioSource audioSource;
    public float launchspeed;
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidbody.useGravity = false;
    }
    public void Launch(Vector3 launchVelocity) {
        launchVelocity *= 2;
        rigidbody.useGravity = true;
        rigidbody.velocity = launchVelocity;
        audioSource.Play();
    }
}
