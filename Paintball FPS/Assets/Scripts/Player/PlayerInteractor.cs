using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerInteractor : MonoBehaviour
{
	PlayerUnit unit;
	SceneCamera sceneCamera { get { return SceneCamera.instance; } }
	CameraRaycaster raycaster;
	[SerializeField] LayerMask mask;

	private void Awake()
	{
		unit = GetComponent<PlayerUnit>();
	}

	private void Start()
	{
		raycaster = sceneCamera.GetComponent<CameraRaycaster>();

		unit.FrameAction += Detect;
	}
	
	void Detect()
	{
		//Raycast using "CameraRaycaster" script, present in camera object
		RaycastHit hit = raycaster.Raycast(5, mask);
		if(hit.collider != null) //if a collider was hitted, an object was detected
		{
			//If player press 'E' key, interaction between player and detected object is triggered.
			if(Input.GetKeyDown(KeyCode.E))
			{
				//But only "IInteractable" object can be interacted with
				if(TryGetComponent(out IInteractable interactable))
				{
					interactable.Interaction(gameObject); //trigger interaction
				}
			}
		}
	}
}
