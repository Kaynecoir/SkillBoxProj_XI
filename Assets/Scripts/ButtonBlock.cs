using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ButtonBlock : MonoBehaviour
{
	public Material matOff, matOn;
	public Renderer renderer;
	public Animator animator;
	private void Start()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		renderer.material = matOn;
		animator.SetBool("isUpBridge", true);
	}

	private void OnCollisionExit(Collision collision)
	{
		renderer.material = matOff;
		animator.SetBool("isUpBridge", false);
	}
}
