using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
	public Action<IInteractable> OnInterection;
	PlayerDetector detector;
	
	void Start()
	{
		detector = GetComponent<PlayerDetector>();
		detector.OnDetected -= OnDetected;
		detector.OnDetected += OnDetected;
	}

	public void OnDetected(IDetectable detected)
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(detected.gameObject.TryGetComponent<IInteractable>(out IInteractable i))
			{
				if(OnInterection != null) { OnInterection(i); }
			}
		}
	}
}
