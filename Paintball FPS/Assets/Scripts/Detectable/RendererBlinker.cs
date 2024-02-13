using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererBlinker : MonoBehaviour
{
	Renderer renderer;
	public bool inIdle { get { return transform.parent == null; } }

	readonly float availableTime = 3f;
	readonly float interval = 7f;
	float duration;

	void Awake()
	{
		renderer = GetComponentInChildren<Renderer>();
	}
	
	void OnEnable()
	{
		duration = availableTime;
		renderer.enabled = true;
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		while(duration > 0)
		{
			if(duration <= availableTime / 3.0f)
			{
				renderer.enabled = !renderer.enabled;
			}
			duration -= Time.deltaTime;
			yield return new WaitForSeconds(interval * Time.deltaTime);
			if(!inIdle) { renderer.enabled = true; yield break; }
		}
		Destroy(gameObject);
	}
}
