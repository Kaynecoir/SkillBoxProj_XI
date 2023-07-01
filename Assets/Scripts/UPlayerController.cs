using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPlayerController : MonoBehaviour
{
	public Transform orientation;
	public Transform playerObj;
	public Rigidbody rb;
	public int healthPoint;
	public float playerSpeed;

	public delegate void SimpleFunc();
	public event SimpleFunc PlayerDeath;

	private UGameManager GM;

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
	}

	private void Update()
	{
		if (!GM.isPause)
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			float vertivalInput = Input.GetAxis("Vertical");
			Vector3 inputDir = orientation.forward * vertivalInput + orientation.right * horizontalInput;
			rb.velocity += inputDir * (playerSpeed / 100);

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Death Trigger")
		{
			Debug.Log("Death");
			PlayerDeath?.Invoke();
		}
	}
}
