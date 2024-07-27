using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
	PlayerUnit unit;

	[SerializeField] AmmoSelector selector;
	public Dictionary<AvailableColors.ColorTag, int> ammo {  get; private set; }
	public AvailableColors.ColorTag currentColor { get; private set; }


	private void Awake()
	{
		unit = GetComponent<PlayerUnit>();

		ammo = new();
		for(int i = 0; i < (int)AvailableColors.ColorTag.Count; i++)
		{ ammo.Add((AvailableColors.ColorTag)i, 5); }
	}

	private void Start()
	{
		for (int i = 0; i < (int)AvailableColors.ColorTag.Count; i++)
		{ selector.Set((AvailableColors.ColorTag)i); selector.Consume("5"); }

		currentColor = AvailableColors.ColorTag.Red;
		selector.Set(currentColor);

		unit.FrameAction += NextAmmo;
	}

	private void OnDestroy()
	{
		unit.FrameAction -= NextAmmo;
	}

	void NextAmmo()
	{
		if (Input.GetMouseButtonDown(1))
		{
			currentColor = selector.Next();
		}
	}

	public bool HasCurrentAmmo() { return ammo[currentColor] > 0; }

	public AvailableColors.ColorTag Get()
	{
		ammo[currentColor]--;
		selector.Consume(ammo[currentColor].ToString());
		return currentColor;
	}
}
