using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Pooling;

public class WeaponItem : MonoBehaviour, IInteractable
{
	Weapon weapon;
	
	public Material outline { get { return _outline; } }
	[SerializeField] Material _outline;

	MeshRenderer renderer;

	public string hint { get { return _hint; } }
	public string description { get { return _description; } }
	
	[SerializeField] string _hint;
	[SerializeField] [TextArea] string _description;

	bool detecting;

	float angularSpeed = 5f;
	public bool inIdle { get { return transform.parent == null; } }

	void Awake()
	{
		weapon = GetComponent<Weapon>();
		renderer = GetComponentInChildren<MeshRenderer>();
	}

	void Update()
	{
		if(!inIdle) { return; }
		Idle();
	}
	
	void Idle()
	{
		transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
	}
	
	public void InDetection()
	{
		if(detecting) { return; }
		
		Material[] original = renderer.materials;
		int length = original.Length;
		Material[] list = new Material[length + 1];

		for(int i = 0; i < length; ++i) { list[i] = original[i]; }
		list[length] = outline;
		
		renderer.materials = list;
		
		detecting = true;
	}

	public void OutDetection()
	{
		if(!detecting) { return; }
		
		Material[] original = renderer.materials;
		int length = original.Length;
		Material[] list = new Material[length - 1];

		for(int i = 0; i < length - 1; ++i) { list[i] = original[i]; }
		renderer.materials = list;
		
		detecting = false;
	}

	public void Interact(GameObject interactor)
	{
		IEquipmentHolder holder = interactor.GetComponentInChildren<IEquipmentHolder>();
		if(holder != null)
        {
			weapon.Equip(holder);
        }
	}
}
