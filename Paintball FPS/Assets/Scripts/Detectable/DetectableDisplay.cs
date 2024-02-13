using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EventCommunication;
using TMPro;

public class DetectableDisplay : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI hint, name, description;

	public void Show(string hint, string name, string description)
	{
		this.hint.text = hint;
		this.name.text = name;
		this.description.text = description;
	
		//SetActive(true);
	}

	public void Hide()
	{
		this.hint.text = "";
		this.name.text = "";
		this.description.text = "";
	}
}
