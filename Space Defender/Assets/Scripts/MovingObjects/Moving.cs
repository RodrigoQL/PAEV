﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moving : MonoBehaviour {

    public Vector2 Velocity;
    public float Torque = 0;
    protected Rigidbody2D rBody;

	protected virtual void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Velocity;
        rBody.angularVelocity = Torque;
    }
}
