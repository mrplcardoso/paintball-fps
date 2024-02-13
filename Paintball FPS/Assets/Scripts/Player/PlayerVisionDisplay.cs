using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisionDisplay : MonoBehaviour
{
	PlayerDetector detector;
	[SerializeField] DetectableDisplay display;

	void Start()
	{
		detector = GetComponent<PlayerDetector>();
		detector.OnDetected -= SetInfo;
		detector.OnDetected += SetInfo;

		detector.OnNotDetected -= Hide;
		detector.OnNotDetected += Hide;
	}

	public void SetInfo(IDetectable detected)
	{
		string name = detected.name, description = detected.description, hint = "";
		if(detected.gameObject.TryGetComponent<IInteractable>(out IInteractable i))
		{ hint = i.hint; }
		
		if(display != null)
		{ display.Show(hint, name, description); }
	}

	public void Hide()
	{
		if(display != null)
		{ display.Hide(); }
	}
}
