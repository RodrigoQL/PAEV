using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

    private Rigidbody2D rb;
    public bool hasRotation;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (!hasRotation)
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, -2.5f));
            rb.AddTorque(Random.Range(-1000f, 1000f));
        }
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		if(hasRotation)
        {
            Vector3 pos = this.transform.position;
            if(pos.y<1.5)
            {
                pos.y = 1;
                this.transform.position = pos;
            }
            this.transform.Rotate(new Vector3(0,0,10 * Time.deltaTime));
        }
	}
}
