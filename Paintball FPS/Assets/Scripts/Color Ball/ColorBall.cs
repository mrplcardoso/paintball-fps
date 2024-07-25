using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utility.EventCommunication;
using Utility.Unit;

[RequireComponent(typeof(Rigidbody))]
public class ColorBall : UnitObject
{
  Rigidbody body;
  public BallCollision collision { get; private set; }

  [SerializeField] float duration = 5;
  float time;

	private void Awake()
	{
		body = GetComponent<Rigidbody>();
    collision = GetComponent<BallCollision>();
	}

	private void Start()
  {
    EventHub.Publish(EventList.AddUpdate, new EventData(this));
  }

  void OnEnable()
  {
    time = 0;
  }

  public void Launch(Quaternion rotation, float force)
  {
    //Zera a velocidade vetorial da bola, pois é possível que sobre força
    //do movimento antes dela ser desativada quando colide com alguem objeto
		body.velocity = Vector3.zero;
		//Define a rotação da bola para ser igual a rotação do canhão (mesma direção).
		transform.rotation = rotation;
    //Aplica uma força na bola, pelo rigidbody, para simular
    //a bola ser disparada pelo canhão da arma.
    //Força é um vetor formado pela intensidade e uma direção.
    body.AddForce(transform.forward * force);
  }

  void LifeCycle()
  {
    if (time <= duration)
    { time += Time.deltaTime; return; }

    gameObject.SetActive(false);
  }

  public override void FrameUpdate()
  {
    LifeCycle();
  }

  public override void PhysicsUpdate() { }

  public override void PostUpdate() { }
}
