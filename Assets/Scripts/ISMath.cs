using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ISMath
{
    static public float Random(ISRange range)
    {
        return UnityEngine.Random.Range(range.min, range.max);
    }
}
[System.Serializable]
public struct ISRange
{
    public float min, max;
    public ISRange(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
