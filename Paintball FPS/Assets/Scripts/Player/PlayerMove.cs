using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
  PlayerUnit unit;
  CharacterController controller;

  Vector3 direction;
  Vector3 xVelocity, yVelocity, zVelocity;
  Vector3 velocity { get { return xVelocity + yVelocity + zVelocity; } }

  readonly float walkSpeed = 7.5f;
  readonly float sprintSpeed = 7.5f * 1.75f;
  float cacheSpeed;

  float jump;
  public const float gravity = 20f;

  void Awake()
  {
    unit = GetComponent<PlayerUnit>();
    controller = GetComponent<CharacterController>();
  }

  private void Start()
  {
		unit.FrameAction += MoveUpdate;
  }

	private void OnDestroy()
	{
    unit.FrameAction -= MoveUpdate;
	}

	void MoveUpdate()
  {
    MoveInput();
    //JumpInput();
    controller.Move(velocity * Time.deltaTime);
  }

  #region Input
  void MoveInput()
  {
    if (Input.GetKey(KeyCode.LeftShift))
    { cacheSpeed = sprintSpeed; }
    else
    { cacheSpeed = walkSpeed; }

    direction.x = Input.GetAxis("Horizontal");
    direction.z = Input.GetAxis("Vertical");


    direction = Vector3.ClampMagnitude(direction, 1f);

    xVelocity = transform.right * direction.x * cacheSpeed;
    zVelocity = transform.forward * direction.z * cacheSpeed;
  }

  void JumpInput()
  {
    yVelocity += Vector3.down * gravity * Time.deltaTime;

    if (controller.isGrounded)
    { yVelocity = Vector3.down; }

    if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
      yVelocity = Vector3.up * jump;
    }
  }
  #endregion
}
