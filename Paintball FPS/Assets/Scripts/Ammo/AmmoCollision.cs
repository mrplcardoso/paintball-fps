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
	Vector3 size;

	float damage => attributes[AttributeType.Damage];
		
	void Awake()
	{
		attributes = GetComponentInChildren<UnitAttributes>();
		match = GetComponentInChildren<MatchColor>();
		poolable = GetComponentInChildren<IPoolableObject>();
		size = GetComponentInChildren<Renderer>().bounds.size;
		particle = Instantiate(particle, transform.position, Quaternion.identity);
 	}
	
	void OnTriggerEnter(Collider collider)
	{
		Color c = GetComponent<Renderer>().material.color;

		if(collider.gameObject.TryGetComponent<Paintable>(out Paintable p))
		{
			p.Paint(c, transform.position, size);
		}

		if(collider.gameObject.TryGetComponent<TakeDamage>(out TakeDamage t))
		{
			if(collider.gameObject.TryGetComponent<MatchColor>(out MatchColor m))
			{
				if(m.color == match.color) { t.Damage(damage); }
			}
		}

		particle.SetColor(c);
		particle.transform.position = transform.position;
		particle.SetActive(true);
		
		poolable.Deactivate();
	}
}
