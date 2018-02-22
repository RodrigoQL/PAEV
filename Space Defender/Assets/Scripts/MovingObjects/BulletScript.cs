﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Crashable {
	
	void Update () {
		if(this.transform.position.y > 5.5f) {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision) {

        Crashable impactObject = collision.gameObject.GetComponent<Crashable>();
        ReceiveDamage( impactObject );
        
    }

    protected override void DestroySelf() {
        GameObject exp = Instantiate( Explosion, this.transform.position, Quaternion.identity );
        exp.GetComponent<Animator>().speed = 3;
        Destroy( exp, 0.5f );
        Destroy( gameObject );
    }
}