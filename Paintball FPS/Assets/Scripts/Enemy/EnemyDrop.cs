using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Random;

public class EnemyDrop : MonoBehaviour
{
	TakeDamage take;
	[SerializeField] Weapon[] drops;

	void Start()
	{
		take = GetComponentInChildren<TakeDamage>();
		take.OnDeath -= Drop;
		take.OnDeath += Drop;
	}

	void Drop()
	{
		if(RandomStream.NextBool()) { return; }

		int r = RandomStream.NextInt(0, drops.Length);
		Instantiate(drops[r], transform.position, Quaternion.identity);
	}
}
