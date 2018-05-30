using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Bola))]
public class DragLaunch : MonoBehaviour {

    private Bola ball;

    private Vector3 dragStart;
    private float startTime;
    private Vector3 dragEnd;
    private float endTime;
    private void Start() {
        ball = GetComponent<Bola>();
    }
    public void DragStart() {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }
    public void DragEnd() {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;
        float launchSpeed_x = ( dragEnd.x - dragStart.x ) / dragDuration;
        float launchSpeed_z = ( dragEnd.y - dragStart.y ) / dragDuration;
        launchSpeed_z *= -1;

        Vector3 launchVelocity = new Vector3( launchSpeed_x, 0, launchSpeed_z );
        ball.Launch( launchVelocity );
    }
}
