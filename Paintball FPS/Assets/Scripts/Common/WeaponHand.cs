using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
	Cannon cannon;

	private void Awake()
	{
		cannon = GetComponentInChildren<Cannon>();
	}

	public void TriggerShoot(AvailableColors.ColorTag color, Vector3 target)
	{
		cannon.Shoot(color, target);
	}
}