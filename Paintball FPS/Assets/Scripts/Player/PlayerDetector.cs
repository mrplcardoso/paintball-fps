using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerDetector : MonoBehaviour
{	
	public Action<IDetectable> OnDetected;
	public Action OnNotDetected;
	public LayerMask mask;
	public float range;

	[SerializeField] IDetectable last;
	
    void Update()
    {
        RaycastHit hit = SceneCamera.instance.raycaster.Raycast(range, mask);
        if(hit.collider != null)
        {
            if(hit.collider.TryGetComponent<IDetectable>(out IDetectable d))
            {
				last = d;
				last.InDetection();
                if(OnDetected != null) { OnDetected(d); return; }
            }
        }
		
		if(last != null)
		{
			last.OutDetection();
			last = null;
		}
		if(OnNotDetected != null) { OnNotDetected(); }
    }
}
