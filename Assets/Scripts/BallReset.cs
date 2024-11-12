using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public void Reset()
    {
        transform.position = Vector3.zero;
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        BallMovement ballMovement = GetComponent<BallMovement>();
        
        TrailRenderer tr = GetComponent<TrailRenderer>();
        tr.Clear();
        
        StartCoroutine(ballMovement.WaitThenLaunch());
    }
}
