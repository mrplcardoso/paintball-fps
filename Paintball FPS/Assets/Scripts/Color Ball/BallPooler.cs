using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooler : MonoBehaviour
{
    public static BallPooler pooler { get; private set; }

    public ColorBall ballPrefab;

    [SerializeField] int ballInstances;
    List<ColorBall> balls;

    Vector3 start = new Vector3(0, -5000, 0);

    void Awake()
    {
        Singleton();
        PoolAllocation();
    }

    void Singleton()
    {
        var instances = FindObjectsOfType(typeof(BallPooler));
        if (instances.Length > 0)
        {
            for (int i = 0; i < instances.Length; i++)
            {
                if (instances[i] != this)
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
        }
        pooler = this;
    }

    void PoolAllocation()
    {
        balls = new List<ColorBall>();
        for(int i = 0; i < ballInstances; i++)
        {
            ColorBall b = Instantiate(ballPrefab,
                            start, Quaternion.identity);
            b.gameObject.SetActive(false);
            balls.Add(b);
        }
    }

    public ColorBall Next()
    {
        for(int i = 0; i < balls.Count; i++)
        {
            if(!balls[i].gameObject.activeInHierarchy)
            { return balls[i]; }
        }
        return null;
    }
}
