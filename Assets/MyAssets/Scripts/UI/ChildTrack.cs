using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrack
{
    public Vector3 StartPos { get; private set; }
    public Vector3 FinalPos { get; private set; }

    public ChildTrack(Vector3 childPos, float offsetX)
    {
        FinalPos = childPos;
        StartPos = childPos + Vector3.right * offsetX;
    }

    public Vector3 LerpPosition(float t)
    {
        return Vector3.Lerp(StartPos, FinalPos, t);
    }
}