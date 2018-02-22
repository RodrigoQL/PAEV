using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : Moving {

    private AudioSource audioSource;

    protected override void Start() {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        audioSource.Play();
        StartCoroutine( Finish() );
    }
    IEnumerator Finish() {
        this.transform.position = new Vector3( 0, 50, 0 );
        yield return new WaitForSeconds( 1f );
        Destroy( gameObject );
    }
}

    
