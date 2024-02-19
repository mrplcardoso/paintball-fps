using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    UnitAttributes attributes;
    public NavMeshAgent agent { get; private set; }

	public Vector3 target { get { return PlayerUnit.player.body.position; } }
	
	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		attributes = GetComponentInChildren<UnitAttributes>();
	}

	void Start()	
	{
		agent.speed = attributes[AttributeType.Speed];
	}

	public void SetDestination(Vector3 destiny)
	{ 
		agent.SetDestination(destiny);
	}

	public void Stop()
	{
		agent.SetDestination(transform.position);
	}
}
