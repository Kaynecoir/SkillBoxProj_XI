using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGameManager : MonoBehaviour
{
	public LevelData lvData;
	public int countPlayerHealth, countPlayerMoney;
	public delegate void SimpleFunction();
	public event SimpleFunction Lose, Pause;

	private GameObject player;
	private UPlayerController playerController;
	private UPlayerView playerView;

	private void Start()
	{
		Debug.Log("Start");
		countPlayerHealth = lvData.CountPlayerHealth;
		if(countPlayerHealth > 0)
		{
			player = GameObject.Find("Player");
			playerController = player.GetComponent<UPlayerController>();
			playerView = player.GetComponent<UPlayerView>();
			playerController.PlayerDeath += PlayerLoseLife;
			playerView.SetHelth();
		}
		else
		{

		}

	}
	private void Awake()
	{

	}

	public void PlayerLoseLife()
	{
		lvData.CountPlayerHealth--;
		countPlayerHealth = lvData.CountPlayerHealth;
		Debug.Log(countPlayerHealth);
	}
}
