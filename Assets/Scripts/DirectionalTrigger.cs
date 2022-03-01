using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalTrigger : MonoBehaviour
{
    public float thrashold = 0;
    public Transform targetTransform;
    private void OnDrawGizmos()
    {
        Vector3 vectorToTarget = targetTransform.position - transform.position;
        Gizmos.DrawRay(transform.position, vectorToTarget);
        var check = Vector3.Dot(transform.right, vectorToTarget.normalized);
        if (check >= thrashold)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.DrawRay(targetTransform.position, targetTransform.right);
    }
}
