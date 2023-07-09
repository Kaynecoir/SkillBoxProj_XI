using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPointScr : MonoBehaviour
{
	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private GameObject viewObject;
	
	public void Play()
	{
		viewObject.SetActive(false);
		particleSystem.Play();
		Destroy(gameObject, 2);
	}
}
