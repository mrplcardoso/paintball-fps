using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class MarkPooler : MonoBehaviour
{
    public static MarkPooler instance { get; private set; }
    ObjectPooler<SplashMark> pool;

    void Awake()
    {
        MarkPooler[] g = GameObject.FindObjectsOfType<MarkPooler>();
        if (g.Length > 1) { Destroy(gameObject); return; }
        instance = this;
    }

    public SplashMark NextMark()
    {
        return pool.GetObject();
    }
}