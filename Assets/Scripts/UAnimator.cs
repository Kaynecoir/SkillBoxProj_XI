using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAnimator : MonoBehaviour
{
	public string nameState;

	private Animator anim;
	private void Start()
	{
		anim = GetComponent<Animator>();
		anim.Play(nameState);
	}
}
