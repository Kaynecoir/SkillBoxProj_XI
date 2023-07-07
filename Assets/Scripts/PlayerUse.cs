using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUse : MonoBehaviour
{

	private UPlayerController playerController;
	private UPlayerView playerView;
	private void Start()
	{
		playerView = GetComponent<UPlayerView>();
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Actived Object")
		{
			ActiveObject ao = other.GetComponent<ActiveObject>();
			if(!ao.isActeved)
			{
				playerView.useImage.gameObject.SetActive(true);
				//Debug.Log(Input.GetKey(KeyCode.E));
				if(Input.GetKey(KeyCode.E))
				{
					ao.ActivateObject();
					//Debug.Log("Way is clear!!");
				}
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Actived Object")
		{
			playerView.useImage.gameObject.SetActive(false);
		}
	}
}
