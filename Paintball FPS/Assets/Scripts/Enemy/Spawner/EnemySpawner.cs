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

  List<AvailableColors.ColorTag> lastColor;

	//Se o jogador não estiver presente na cena,
  //usa a posição do Enemy Manager como centro.
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
    lastColor = new List<AvailableColors.ColorTag>();
    EventHub.Publish(EventList.AddUpdate, new EventData(this));
  }

  void Spawn()
  {
    if (stop) { return; }
    if (count >= enemiesPerWave) { return; }

    if (time > interval)
    {
      Vector3 rand = SpawnPosition();
      if(!ValidPosition(rand)) { return; }

      EnemyUnit unit = EnemyPooler.pooler.Next();
      unit.color.SetColor(SpawnColor());
      unit.transform.position = rand;
      unit.gameObject.SetActive(true);

      count++;
      time = 0;
    }
    time += Time.deltaTime;
  }

  Vector3 SpawnPosition()
  {
    /*Algoritmo da posição*/
    //1 - Pegar uma posição aleatória
    //dentro de um circulo unitário
    Vector3 randomPosition = Random.insideUnitCircle;
    randomPosition.z = randomPosition.y;
    randomPosition.y = 0;
    //2 - Criar um vetor a partir da posição do jogador
    Vector3 spawnVector = center + randomPosition;
    spawnVector = (spawnVector - center).normalized;
    //3 - Multiplicar pela distancia em relação ao jogador
    spawnVector = spawnVector * Random.Range(innerDistance, outerDistance);
    //4 - Recentrarlizar o vetor em relação ao jogador
    Vector3 spawnPosition = center + spawnVector;
    spawnPosition.y = center.y;

    return spawnPosition;
  }

  bool ValidPosition(Vector3 position)
  {
    return Physics.Raycast(position, Vector3.down, 50);
  }

  AvailableColors.ColorTag SpawnColor()
  {
    //Sorteia uma cor. 'enum' é conversível com 'int'.
    //O código abaixo executa Random.Range, que sorteia um numero entre dois.
    //Converte o ColorTag.Count para 'int', para tratá-lo como numero.
    //Depois do sorteio, converte o numeor sorteado para ColorTag.
    var c = (AvailableColors.ColorTag)Random.Range(0,
                    (int)AvailableColors.ColorTag.Count);

		lastColor.Add(c);

		if (lastColor.Count > 3)
    {
      if(!lastColor.Contains(c = PlayerUnit.player.color))
      { c = PlayerUnit.player.color; lastColor.Clear(); }
    }

    return c;
  }

  public void FrameUpdate()
  {
    Spawn();
  }

  public void PhysicsUpdate() { }

  public void PostUpdate() { }
}
