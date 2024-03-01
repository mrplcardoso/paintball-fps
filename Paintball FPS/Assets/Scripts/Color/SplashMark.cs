using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class SplashMark : MonoBehaviour, IPoolableObject
{
    float duration;
    public int poolIndex { get { return index; } set { index = index < 0 ? value : index; } }
    int index = -1;
    public bool activeInScene { get { return gameObject.activeInHierarchy; } }

    public void Activate(float duration)
    {
    	this.duration = duration;
    	gameObject.SetActive(true);
    	StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(duration);

    	while(renderer.material.color.a > 0)
    	{
            Color c = renderer.material.color;
            c = new Color(c.r, c.g, c.b, c.a - Time.deltaTime);
            renderer.material.color = c;
    		yield return null;
    	}
    	Deactivate();
    }

    public void Deactivate()
    {
    	gameObject.SetActive(false);
        renderer.material.color = color;
    }

    Renderer renderer;
    Color color;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        color = renderer.material.color;
    }
}