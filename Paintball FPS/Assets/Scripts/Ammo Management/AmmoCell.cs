using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoCell : MonoBehaviour
{
	[SerializeField] AvailableColors.ColorTag _color;
	public AvailableColors.ColorTag color { get { return _color; } }

	public TextMeshProUGUI ammoText {  get; private set; }

	private void Awake()
	{
		ammoText = GetComponentInChildren<TextMeshProUGUI>();
	}
}
