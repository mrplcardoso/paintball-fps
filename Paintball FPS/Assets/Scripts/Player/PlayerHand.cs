using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour, IWeaponHolder
{
	PlayerInteractor interactor;

	public IEquipable equip { get { return weapon; } }
	public Weapon currentWeapon { get { return weapon; } }
	public bool holding { get { return weapon != null; } }
	Weapon weapon;
	
	public void Start()
	{
		interactor = GetComponentInParent<PlayerInteractor>();
		interactor.OnInterection -= WeaponInteraction;
		interactor.OnInterection += WeaponInteraction;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			UseWeapon();
		}

		if(Input.GetMouseButtonUp(0))
		{
			StopWeapon();
		}
	}
	
	public void WeaponInteraction(IInteractable interactable)
	{
		if(holding)
		{
			weapon.DeEquip(this);
			weapon = null;
		}

		if(interactable.gameObject.TryGetComponent<Weapon>(out Weapon w))
		{
			w.Equip(this);
			weapon = w;
		}
	}

	public void UseWeapon()
	{
		if(weapon != null) { weapon.Use(); }
	}
	
	public void StopWeapon()
	{
		if(weapon != null) { weapon.Stop(); }
	}
}
