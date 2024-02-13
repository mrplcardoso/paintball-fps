using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IEquipable
{
	public float yDropPosition { get { return _yDropPosition; } }
	[SerializeField] protected float _yDropPosition;

	public Collider collider { get { return _collider; } }
	[SerializeField] protected Collider _collider;

	public Vector3 equipRotation { get { return _equipRotation; } }
	[SerializeField] protected Vector3 _equipRotation;
	
	public readonly int maxShots = 5;
	protected int shots;
	[SerializeField] bool infinityShots;

	public virtual void Use() 
	{ 
		if(infinityShots) return; 

		shots--; 
		if(shots <= 0) Destroy(gameObject);
	}
	public abstract void Stop();

	public virtual void Awake()
	{
		_collider = GetComponentInChildren<Collider>();
		shots = maxShots;
	}

	void OnEnable()
	{
		_collider.enabled = true;
		transform.parent = null;
		transform.position = new Vector3(transform.position.x, _yDropPosition, transform.position.z);
	}

	public void Equip(IEquipmentHolder holder)
	{
		_collider.enabled = false;
		transform.parent = holder.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.Euler(_equipRotation);
	}

	public void DeEquip(IEquipmentHolder holder)
	{
		_collider.enabled = true;
		transform.parent = null;
		transform.position = new Vector3(holder.transform.position.x, _yDropPosition, holder.transform.position.z);
		transform.rotation = Quaternion.Euler(Vector3.zero);
		Destroy(gameObject);
	}
}
