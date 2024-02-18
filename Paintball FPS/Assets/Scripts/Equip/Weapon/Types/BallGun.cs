using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class BallGun : Weapon
{
	[SerializeField] Projectile prefab;
	ObjectPooler<Projectile> ammoPool;
	static GameObject container;

	public void Awake()
	{
		base.Awake();
		if(container == null) { container = new GameObject("Ball Container"); }
		ammoPool = new ObjectPooler<Projectile>(prefab, maxShots, Vector3.down * 5000, infinityShots, container.transform);
	}

	public override void Use()
	{
		Projectile next = ammoPool.GetObject();
		if (next == null)
		{ PrintConsole.Error("No more projectiles"); return; }

		next.transform.position = transform.position;
		next.transform.rotation = transform.rotation;
		next.Launch(200f, 5f);
		
		base.Use();
	}

	public override void Stop(){}
	
	public bool launch;
	void Update()
	{
		if(!launch) return;
		
		launch = false;
		Use();
	}
}
