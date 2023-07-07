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
	public delegate Vector3 PositionFunc(Vector3 pos);
	public event SimpleFunc PlayerDeath, PlayerWin;
	public event PositionFunc PlayerCheck;

	private UGameManager GM;

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		rb.mass = GM.lvData.PlayerData.PlayerMass;
		playerSpeed = GM.lvData.PlayerData.PlayerSpeed;
	}

	private void Update()
	{
		if (!GM.isPause)
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			float vertivalInput = Input.GetAxis("Vertical");
			Vector3 inputDir = orientation.forward * vertivalInput + orientation.right * horizontalInput;
			rb.AddForce(inputDir * playerSpeed, ForceMode.Force);

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Death Trigger")
		{
			Debug.Log("Death");
			PlayerDeath?.Invoke();
		}
		if(other.tag == "Check Point")
		{
			Debug.Log("Check Point");
			PlayerCheck?.Invoke(other.transform.position);
		}
		if(other.tag == "Win Point")
		{
			Debug.Log("Win");
			PlayerWin?.Invoke();
		}
	}
}
