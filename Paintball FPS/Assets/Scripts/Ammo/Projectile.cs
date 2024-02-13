using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class Projectile : MonoBehaviour, IPoolableObject
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
		while(duration > 0)
		{
			duration -= Time.deltaTime;
			yield return null;
		}
		Deactivate();
	}

	public void Deactivate()
	{
		body.velocity = Vector3.zero;
		gameObject.SetActive(false);
	}
	
	Rigidbody body;
	public bool isActive { get { return activeInScene; } }

	void Awake()
	{
		body = GetComponent<Rigidbody>();
	}

	public void Launch(float force, float duration)
	{
		Activate(duration);
		body.AddForce(transform.forward * force);
	}
}
