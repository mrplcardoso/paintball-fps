using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
	ParticleSystem particle;

	public bool playing { get { return particle.isPlaying; } }
	
	void Awake()
	{
		particle = GetComponent<ParticleSystem>();
	}

	public void Activate()
	{
		gameObject.SetActive(true);
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
