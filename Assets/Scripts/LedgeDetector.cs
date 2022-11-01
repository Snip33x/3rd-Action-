using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    public event Action<Vector3, Vector3> OnLedgeDetect;

    private void OnTriggerEnter(Collider other)
    {
        OnLedgeDetect?.Invoke(other.transform.forward, other.ClosestPointOnBounds(transform.position)); //forward is the blue arrow in object moving in editor
    }
}
