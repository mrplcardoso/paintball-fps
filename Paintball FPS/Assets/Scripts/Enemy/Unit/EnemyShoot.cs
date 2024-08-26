using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Utility.SceneCamera;

public class EnemyShoot : MonoBehaviour, IEquipSlot
{
	[SerializeField] WeaponHand hand;
	public WeaponHand weaponHand { get { return hand; } }

	public void UseWeapon()
	{
		if (hand == null)
		{
			Debug.LogError("WeaponHand not set in EnemyShoot Inspector");
			return;
		}

		hand.TriggerShoot(gameObject);
	}

	public void Equip(IEquipment gun)
	{
		//Convert gun (of IEquipment type) to IWeapon type
		if (gun.gameObject.TryGetComponent(out IWeapon weapon))
		{ hand.Equip(weapon); }
	}
}