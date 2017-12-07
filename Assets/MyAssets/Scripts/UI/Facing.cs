using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Transform Target;
    public float DotResult;
    public float DotResultBoundary;

    void Update()
    {
        DotResult = Vector3.Dot(Camera.main.transform.forward.normalized, (Target.position - Camera.main.transform.position).normalized);
        if (DotResult > DotResultBoundary)
        {
            Debug.Log("Found.");
        }
    }
}
