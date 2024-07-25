using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerCamera : MonoBehaviour
{
	PlayerUnit unit;

	private void Awake()
	{
		unit = GetComponent<PlayerUnit>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Start()
	{
		unit.FrameAction += Rotation;
		unit.PostAction += CameraToHead;
	}

	private void OnDestroy()
	{
		unit.FrameAction -= Rotation;
		unit.PostAction -= CameraToHead;
	}

	#region Rotation

	SceneCamera sceneCamera { get { return SceneCamera.instance; } }

	const float minAngle = -50, maxAngle = 50;
	float xRotation, yRotation;
	[SerializeField] float mouseSensitivity = 10;

	void Rotation()
	{
		xRotation += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
		yRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
		yRotation = Mathf.Clamp(yRotation, minAngle, maxAngle);

		sceneCamera.transform.eulerAngles = new Vector3(-yRotation, xRotation, 0);

		transform.eulerAngles = new Vector3(0, xRotation, 0);
	}

	#endregion

	#region Camera Translation

	[SerializeField] Transform head;

	void CameraToHead()
	{
		sceneCamera.transform.position = head.position;
	}

	#endregion
}
