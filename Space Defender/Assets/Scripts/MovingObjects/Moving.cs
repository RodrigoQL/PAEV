using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moving : MonoBehaviour {

    public Vector2 Velocity;
    public int Torque = 0;
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Velocity;
        GetComponent<Rigidbody2D>().AddTorque( Torque );
        Initialize();
    }
    protected abstract void Initialize();
}
