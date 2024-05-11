using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IEquipable
{
	public MatchColor match { get { return _match; } }
	[SerializeField] protected MatchColor _match;
	
	public MeshRenderer renderer { get { return _renderer; } }
	[SerializeField] protected MeshRenderer _renderer;

	public virtual void Awake()
	{
		_renderer = GetComponentInChildren<MeshRenderer>();
		_collider = GetComponentInChildren<Collider>();
		shots = maxShots;
	}

	void OnEnable()
	{
		_renderer.materials[0].color = _match.color;
		_collider.enabled = true;
		transform.parent = null;
		transform.position = new Vector3(transform.position.x, _yDropPosition, transform.position.z);
	}

	#pragma region Weapon
	
	protected int shots;
	[SerializeField] protected bool infinityShots;
	public readonly int maxShots = 5;

	public virtual void Use() 
	{ 
		if(infinityShots) return; 

		shots--; 
		if(shots <= 0) Destroy(gameObject);
	}

	public abstract void Stop();

	#pragma endregion

	#pragma region Equipment

	public Collider collider { get { return _collider; } }
	[SerializeField] protected Collider _collider;

	public Vector3 equipRotation { get { return _equipRotation; } }
	[SerializeField] protected Vector3 _equipRotation;

	public float yDropPosition { get { return _yDropPosition; } }
	[SerializeField] protected float _yDropPosition;

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

	#pragma endregion
}
