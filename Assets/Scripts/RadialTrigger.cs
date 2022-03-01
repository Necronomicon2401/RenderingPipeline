using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform targetPoint;
    public float radius = 2;
    private void OnDrawGizmos()
    {
        Vector3 vectorToTarget = targetPoint.position - transform.position;
        Vector3 vectorToTargetNormalized = vectorToTarget.normalized;
        float distance = Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.y * vectorToTarget.y);

        if (distance <= radius)
        {
            Handles.color = Color.red;
        }
        else
        {
            Handles.color = Color.white;
        }
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
