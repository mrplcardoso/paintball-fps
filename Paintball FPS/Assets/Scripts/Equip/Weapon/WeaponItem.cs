using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class WeaponItem : MonoBehaviour, IInteractable
{
	Weapon weapon;
	MeshRenderer renderer { get { return weapon.renderer; } }
	
	Material _outline;
	public Material outline { get { return _outline; } }

	public string hint { get { return _hint; } }
	[SerializeField] string _hint;

	public string description { get { return _description; } }
	[SerializeField] [TextArea] string _description;

	void Awake()
	{
		weapon = GetComponent<Weapon>();
	}

	public void Interact(GameObject interactor)
	{
		IEquipmentHolder holder = interactor.GetComponentInChildren<IEquipmentHolder>();
		if(holder != null)
        {
			weapon.Equip(holder);
        }
	}

	public void InDetection() { }
	public void OutDetection() { }
}
