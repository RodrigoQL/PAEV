using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : Crashable {

    protected override void InitializeCrashable() {
        Vector2 rSpeed = new Vector2( Random.Range( -1f, 1f ), Random.Range( 0f, -2f ) );
        float aSpeed = Random.Range( -10f, -10f );
        GetComponent<Rigidbody2D>().velocity += rSpeed;
        GetComponent<Rigidbody2D>().angularVelocity += aSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Crashable impactObject = collision.gameObject.GetComponent<Crashable>();
        if (impactObject != null) {
            ReceiveDamage( impactObject );
        }
    }

    protected override void DestroySelf() {

    }
}
