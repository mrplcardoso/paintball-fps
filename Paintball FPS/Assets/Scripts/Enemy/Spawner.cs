using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;
using Utility.Random;
using Utility.EventCommunication;

public class Spawner : MonoBehaviour
{
	[SerializeField] EnemyPoolable[] prefabs;
	ObjectPooler<EnemyPoolable>[] pools;
	
	readonly int startInstances = 1;
	int waves;
	int instances;

	void Awake()
	{
		GameObject container = new GameObject("Enemy Container");
		pools = new ObjectPooler<EnemyPoolable>[prefabs.Length];
		for(int i = 0; i < prefabs.Length; ++i)
		{
			pools[i] = new ObjectPooler<EnemyPoolable>(prefabs[i], (startInstances/2) + 1, Vector3.down * 5000, true, container.transform);
		}
		waves = 1;
		instances = startInstances;
	}

	void Start()
	{
		EventHub.Subscribe(EventList.EnemyKill, KillCount);
		StartCoroutine(Spawn());
	}
	
	void KillCount(EventData data)
	{
		instances--;
	}

	IEnumerator Spawn()
	{
		while(true)
		{
			int i = instances = waves * startInstances;
			while(i > 0)
			{
				int p = RandomStream.NextInt(0, pools.Length);
				var next = pools[p].GetObject();
				next.transform.position = transform.position;
				next.transform.rotation = transform.rotation;	
				next.Activate(0);
				i--;
			}
			yield return new WaitWhile(() => instances > 0);
			yield return new WaitForSeconds(5f);
			waves++;
		}
	}
}
