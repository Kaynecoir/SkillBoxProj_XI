using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGameManager : MonoBehaviour
{
	public int countPlayerHealth, countPlayerMoney;

	private GameObject player;
	private UPlayerController playerController;
	private UPlayerView playerView;

	private void Start()
	{
		countPlayerHealth = 5;
		player = GameObject.Find("Player");
		playerController = player.GetComponent<UPlayerController>();
		playerView = player.GetComponent<UPlayerView>();
		playerView.SetHelth();
	}

	public void PlayerLoseLife()
	{
		countPlayerHealth--;
	}
}
