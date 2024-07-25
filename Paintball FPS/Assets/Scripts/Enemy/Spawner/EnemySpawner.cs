using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Actions;
using Utility.EventCommunication;

public class EnemySpawner : MonoBehaviour, IUpdatable
{
  //Faixa em que o inimigo pode nascer, delimitado em um ponto
  //entre dois raios.
  [SerializeField] float innerDistance = 75f, outerDistance = 150f;

  [SerializeField] float interval = 3f;
  float time;
  bool stop;

  [SerializeField] int enemiesPerWave = 10;
  int count;

	//Se o jogador n�o estiver presente na cena,
  //usa a posi��o do Enemy Manager como centro.
	Vector3 center { get
    {
      if (PlayerUnit.player != null)
      { return PlayerUnit.player.transform.position; }
      return transform.position;
    }
   }

  public bool isActive { get { return gameObject.activeInHierarchy; } }

  void Awake()
  {
    stop = false;
    time = 0;
    count = 0;
  }

  private void Start()
  {
    EventHub.Publish(EventList.AddUpdate, new EventData(this));
  }

  void Spawn()
  {
    if (stop) { return; }
    if (count >= enemiesPerWave) { return; }

    if (time > interval)
    {
      EnemyUnit unit = EnemyPooler.pooler.Next();
      unit.color.SetColor(SpawnColor());
      unit.transform.position = SpawnPosition();
      unit.gameObject.SetActive(true);

      count++;
      time = 0;
    }
    time += Time.deltaTime;
  }

  Vector3 SpawnPosition()
  {
    /*Algoritmo da posi��o*/
    //1 - Pegar uma posi��o aleat�ria
    //dentro de um circulo unit�rio
    Vector3 randomPosition = Random.insideUnitCircle;
    randomPosition.z = randomPosition.y;
    randomPosition.y = 0;
    //2 - Criar um vetor a partir da posi��o do jogador
    Vector3 spawnVector = center + randomPosition;
    spawnVector = (spawnVector - center).normalized;
    //3 - Multiplicar pela distancia em rela��o ao jogador
    spawnVector = spawnVector * Random.Range(innerDistance, outerDistance);
    //4 - Recentrarlizar o vetor em rela��o ao jogador
    Vector3 spawnPosition = center + spawnVector;
    spawnPosition.y = center.y;

    return spawnPosition;
  }

  AvailableColors.ColorTag SpawnColor()
  {
    //Sorteia uma cor. 'enum' � convers�vel com 'int'.
    //O c�digo abaixo executa Random.Range, que sorteia um numero entre dois.
    //Converte o ColorTag.Count para 'int', para trat�-lo como numero.
    //Depois do sorteio, converte o numeor sorteado para ColorTag.
    return (AvailableColors.ColorTag)Random.Range(0,
                  (int)AvailableColors.ColorTag.Count);
  }

  public void FrameUpdate()
  {
    Spawn();
  }

  public void PhysicsUpdate() { }

  public void PostUpdate() { }
}
