using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
	public Action OnDeath;
	UnitAttributes attributes;
	float maxLife => attributes[AttributeType.Health];
	[SerializeField] float life;
	
	void Awake()
	{
		attributes = GetComponentInChildren<UnitAttributes>();
	}

	void Start()
	{
		life = maxLife;
	}

	public void Damage(float value)
	{
		life = Mathf.Clamp(life - value, 0.0f, maxLife);
		if(life <= 0)
		{
			if(OnDeath != null) { OnDeath(); }
		}
	}
}
