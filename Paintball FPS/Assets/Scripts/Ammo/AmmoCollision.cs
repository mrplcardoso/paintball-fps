using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class AmmoCollision : MonoBehaviour
{
	UnitAttributes attributes;
	MatchColor match;
	[SerializeField] IPoolableObject poolable;
	[SerializeField] SplashParticle particle;

	public Vector3 target { get { return PlayerUnit.player.body.position; } }

	float damage => attributes[AttributeType.Damage];
		
	void Awake()
	{
		attributes = GetComponentInChildren<UnitAttributes>();
		match = GetComponentInChildren<MatchColor>();
		poolable = GetComponentInChildren<IPoolableObject>();
		particle = Instantiate(particle, transform.position, Quaternion.identity);
 	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.TryGetComponent<TakeDamage>(out TakeDamage t))
		{
			if(collider.gameObject.TryGetComponent<MatchColor>(out MatchColor m))
			{
				if(m.name == match.name) { t.Damage(damage); }
			}
		}

		particle.SetColor(match.color);
		particle.transform.position = transform.position;
		particle.SetActive(true);
		
		poolable.Deactivate();
	}
}
