using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPlayerCamera : MonoBehaviour
{
	[Header("Referance")]
	public Transform orientation;
	public Transform player;
	public Transform playerObj;
	public Rigidbody rb;

	public float rotationSpeed;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
		orientation.forward = viewDir.normalized;

		float horizontalInput = Input.GetAxis("Horizontal");
		float vertivalInput = Input.GetAxis("Vertical");
		Vector3 inputDir = orientation.forward * vertivalInput + orientation.right * horizontalInput;

		if(inputDir != Vector3.zero)
		{
			//playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
		}
	}
}
