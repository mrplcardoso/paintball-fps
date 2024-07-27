using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Utility.SceneCamera;

[RequireComponent(typeof(PlayerAmmo))]
public class PlayerShoot : MonoBehaviour
{
	PlayerUnit unit;
	PlayerAmmo ammo;

	[SerializeField] WeaponHand hand;
	public WeaponHand weaponHand { get { return hand; } }

	private void Awake()
	{
		unit = GetComponent<PlayerUnit>();
		ammo = GetComponent<PlayerAmmo>();
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
			if(!ammo.HasCurrentAmmo()) { return; }

			Vector3 target;
			RaycastHit hit = SceneCamera.instance.raycaster.Raycast(50, LayerMask.NameToLayer("Default"));
			if(hit.collider != null) { target = hit.point; }
			else { target = SceneCamera.instance.transform.position + SceneCamera.instance.transform.forward * 50; }

			hand.TriggerShoot(ammo.Get(), target);
		}
	}
}