using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	PlayerUnit unit;
	[SerializeField] WeaponHand hand;

	[SerializeField] AvailableColors.ColorTag currentColor;

	private void Awake()
	{
		unit = GetComponent<PlayerUnit>();
	}

	private void Start()
	{
		unit.FrameAction += UseWeapon;
	}

	private void OnDestroy()
	{
		unit.FrameAction -= UseWeapon;
	}

	void UseWeapon()
	{
		if (hand == null)
		{
			Debug.LogError("WeaponHand not set in PlayerShoot Inspector");
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{ hand.TriggerShoot((AvailableColors.ColorTag)Random.Range(0, (int)AvailableColors.ColorTag.Count)); }
	}
}