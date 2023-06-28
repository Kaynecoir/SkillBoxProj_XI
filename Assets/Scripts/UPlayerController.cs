using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPlayerController : MonoBehaviour
{
	public Transform orientation;
	public Transform playerObj;
	public Rigidbody rb;

	public float playerSpeed, playerMaxSpeed;

	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float vertivalInput = Input.GetAxis("Vertical");
		Vector3 inputDir = orientation.forward * vertivalInput + orientation.right * horizontalInput;
		rb.velocity += inputDir * (playerSpeed / 100);
		Debug.Log("Speed: " + rb.velocity.sqrMagnitude);
		if(rb.velocity.sqrMagnitude < (playerMaxSpeed / 100))
		{
			Debug.Log("Correct speed");
			//rb.velocity = rb.velocity.normalized * (playerMaxSpeed / 100);
		}
	}
}
