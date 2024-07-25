using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Torna acess�vel o pacote de IA

public class EnemyMove : MonoBehaviour
{
  EnemyUnit unit;
  NavMeshAgent agent;

  //PlayerUnit.player � uma vari�vel est�tica, definida no c�digo PlayerUnit
  public Transform destiny { get
   {
      if(PlayerUnit.player != null)
        return PlayerUnit.player.transform;
      return Camera.main.transform;
    }
  }

  void Awake()
  {
    unit = GetComponent<EnemyUnit>();
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
    if(destiny == null) { return; }

    agent.SetDestination(destiny.position);
  }
}
