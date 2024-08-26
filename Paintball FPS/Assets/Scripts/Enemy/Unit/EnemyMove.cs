using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI; //Torna acessível o pacote de IA
using UnityEngine.UIElements;
using Utility.Random;

public class EnemyMove : MonoBehaviour
{
  EnemyUnit unit;
  EnemyShoot shoot;
  NavMeshAgent agent;

  public LayerMask mask;
  public float detectionRange;
  public float attackRange;
  public float nextFireTime;

  //PlayerUnit.player é uma variável estática, definida no código PlayerUnit
  public Transform destiny { get
   {
      if(PlayerUnit.player != null)
        return PlayerUnit.player.transform;
      return Camera.main.transform;
    }
  }

  public Vector3 targetDirection => destiny.position - transform.position;

  public float targetDistance => Vector3.Distance(destiny.position, transform.position);


	void Awake()
  {
    unit = GetComponent<EnemyUnit>();
    shoot = GetComponent<EnemyShoot>();
    agent = GetComponent<NavMeshAgent>();
  }

  private void Start()
  {
    unit.FrameAction += Move;
  }

  private void OnDestroy()
  {
    unit.FrameAction -= Move;
  }

  void Move()
  {
    Debug.DrawRay(transform.position, targetDirection.normalized * detectionRange, Color.red);
		if (targetDistance <= detectionRange)
    {
			Debug.DrawRay(transform.position, targetDirection.normalized * attackRange, Color.green);
			if (Physics.SphereCast(transform.position, 0.5f, targetDirection, out RaycastHit hit, attackRange, mask))
      {
        if (hit.collider.gameObject.CompareTag("Player"))
        {
          transform.LookAt(destiny.position);
					agent.isStopped = true;
					if (Time.time >= nextFireTime)
					{
						shoot.UseWeapon();
						nextFireTime = Time.time + 1f / 0.5f;
					}
				}
				else
				{
					ToDestiny();
				}
			}
      else
      {
        ToDestiny();
      }
    }
    else
    {
      Patrol();
    }
  }

  void ToDestiny()
  {
    if(destiny == null) { return; }
		agent.isStopped = false;
		agent.SetDestination(destiny.position);
  }

	void Patrol()
	{
		if (agent.remainingDistance < 0.5f)
		{
			agent.isStopped = false;
			Vector3 direction = RandomStream.Direction2D();
      direction.z = direction.y; direction.y = 0;

			Vector3 position = transform.position + direction * detectionRange/2f;

			Debug.DrawRay(transform.position, direction * detectionRange / 2f, Color.blue, 5f);
			if (Physics.Raycast(transform.position, direction, out RaycastHit hit, detectionRange/2f))
      { 
        if(hit.collider != null)
        {
          position = hit.point;
        }
      }

      agent.SetDestination(position);
		}
	}
}
