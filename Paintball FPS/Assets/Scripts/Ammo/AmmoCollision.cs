using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class AmmoCollision : MonoBehaviour
{
	UnitAttributes attributes;
	MatchColor match;
	[SerializeField] IPoolableObject poolable;

	float damage => attributes[AttributeType.Damage];
		
	void Awake()
	{
		attributes = GetComponentInChildren<UnitAttributes>();
		match = GetComponentInChildren<MatchColor>();
		poolable = GetComponentInChildren<IPoolableObject>();
 	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.TryGetComponent<TakeDamage>(out TakeDamage t))
		{
			if(collider.gameObject.TryGetComponent<MatchColor>(out MatchColor m))
			{
				if(m.color == match.color) { t.Damage(damage); }
			}
		}
		poolable.Deactivate();
	}
}
