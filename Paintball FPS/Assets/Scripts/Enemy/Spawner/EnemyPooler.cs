using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
	public static EnemyPooler pooler {  get; private set; }
	public EnemyUnit prefab;

	[SerializeField] int instances;
	List<EnemyUnit> enemies;

	Vector3 start = new Vector3(0, -5500, 0);

	void Awake()
	{
		Singleton();
		PoolAllocation();
	}

	void Singleton()
	{
		var instances = FindObjectsOfType(typeof(EnemyPooler));
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
		enemies = new List<EnemyUnit>();
		for (int i = 0; i < instances; i++)
		{
			EnemyUnit b = Instantiate(prefab,
											start, Quaternion.identity);
			b.gameObject.SetActive(false);
			enemies.Add(b);
		}
	}

	public EnemyUnit Next()
	{
		for (int i = 0; i < enemies.Count; i++)
		{
			if (!enemies[i].gameObject.activeInHierarchy)
			{ return enemies[i]; }
		}
		return null;
	}
}
