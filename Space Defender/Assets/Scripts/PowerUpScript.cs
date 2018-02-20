using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    private Vector3 rotation = new Vector3(0, 0, 1);
    private Vector2 velocity = new Vector2(0, -1);

    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = velocity;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(rotation);
	}
    private void OnCollisionEnter2D(Collision2D collision) {
        audioSource.Play();
        StartCoroutine(Finish());
    }
    IEnumerator Finish() {
        this.transform.position = new Vector3(0,50,0);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
