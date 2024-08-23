using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
	public Gun gun { get; private set; }

	private void Awake()
	{
		gun = GetComponentInChildren<Gun>();
	}

	public void Equip(Gun gun)
	{
		Destroy(this.gun);

		this.gun = gun;
		/* To do: adjust position, rotation and scale of new gun */
	}

	public void TriggerShoot(AvailableColors.ColorTag color, Vector3 target)
	{
		if(gun == null)
		{ Debug.Log("No gun equiped"); return; }

		gun.Shoot(color, target);
	}
}