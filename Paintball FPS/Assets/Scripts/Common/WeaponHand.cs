using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
	public IWeapon weapon { get; private set; }
	[SerializeField] Transform weaponAdjusment;

	public AvailableColors.ColorTag color => weapon.color;

	public string layer;

	private void Awake()
	{
		weapon = GetComponentInChildren<IWeapon>();
		weaponAdjusment = GetComponentsInChildren<Transform>()[1];
		if(weaponAdjusment == null) { Debug.LogError("No Weapon Adjusment configured in Inspector"); return; }
	}

	public void Equip(IWeapon weapon)
	{
		//Destroy previous weapon
		if (this.weapon != null) { Destroy(this.weapon.gameObject); }

		//Instance new one
		var instance = Instantiate(weapon.gameObject, transform);
		this.weapon = instance.GetComponent<IWeapon>();

		//adjust position and rotation
		instance.transform.position = weaponAdjusment.position;
	}

	public void PaintWeapon(AvailableColors.ColorTag color)
	{
		if (weapon != null)
		{ weapon.SetColor(color); }
	}

	public void TriggerShoot(GameObject parent)
	{
		if(weapon == null) { Debug.Log("No weapon equiped"); return; }

		weapon.Trigger(parent, layer);
	}
}