using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UPlayerController : MonoBehaviour
{
	public Transform orientation;
	public Transform playerObj;
	public Rigidbody rb;
	public int healthPoint;
	public float playerSpeed;

	private UGameManager GM;

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
	}

	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float vertivalInput = Input.GetAxis("Vertical");
		Vector3 inputDir = orientation.forward * vertivalInput + orientation.right * horizontalInput;
		rb.velocity += inputDir * (playerSpeed / 100);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Death Trigger")
		{
			Debug.Log("Death");
			GM.PlayerLoseLife();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
