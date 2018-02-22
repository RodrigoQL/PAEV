using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : Crashable {

    protected override void Start() {
        base.Start();

        Vector2 rSpeed = new Vector2( Random.Range( -1f, 1f ), Random.Range( 0f, -2f ) );
        Velocity += rSpeed;
        rBody.velocity = Velocity;

        float aSpeed = Random.Range( -10f, -10f );
        Torque += aSpeed;
        rBody.angularVelocity = aSpeed;
    }
    protected override void DestroySelf() {

    }
}
