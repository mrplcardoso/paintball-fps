using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;
using Utility.EventCommunication;

public class EnemyPoolable : MonoBehaviour, IPoolableObject
{
	public int poolIndex { get { return index; } set { index = index < 0 ? value : index; } }
	int index = -1;

	public bool activeInScene { get { return gameObject.activeInHierarchy; } }

	void Start()
	{
		GetComponent<TakeDamage>().OnDeath -= Deactivate;
		GetComponent<TakeDamage>().OnDeath += Deactivate;
	}

	public void Activate(float duration)
	{
		gameObject.SetActive(true);
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
		EventHub.Publish(EventList.EnemyKill);
	}
	
	public bool kill;
	void Update()
	{
		if(kill) { Deactivate(); kill = false; }
	}
}
