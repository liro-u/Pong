using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Application;

public class Goal : MonoBehaviour
{
    public delegate void CallbackDelegate();
    public CallbackDelegate onBallEnter;

    private void OnTriggerEnter(Collider other)
    {
        BallReset ballReset = other.GetComponent<BallReset>();
        if (ballReset != null)
        {
            ballReset.Reset();
            onBallEnter?.Invoke();
        }
    }
}
