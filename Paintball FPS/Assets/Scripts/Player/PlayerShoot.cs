using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerShoot : MonoBehaviour, IEquipSlot
{
	PlayerUnit unit;

	[SerializeField] WeaponHand hand;
	public WeaponHand weaponHand { get { return hand; } }

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
		{
			hand.TriggerShoot(SceneCamera.instance.gameObject);	
		}
	}

	public void Equip(IEquipment gun)
	{
		//Convert gun (of IEquipment type) to IWeapon type
		if (gun.gameObject.TryGetComponent(out IWeapon weapon))
		{ hand.Equip(weapon); }
	}
}