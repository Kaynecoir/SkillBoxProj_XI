using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGameManager : MonoBehaviour
{
	public LevelData lvData;
	public GameObject PauseBox, LoseBox;
	public int countPlayerHealth, countPlayerMoney;
	public delegate void SimpleFunction();
	public event SimpleFunction Lose, Pause;

	private GameObject player;
	private UPlayerController playerController;
	private UPlayerView playerView;
	private bool isPause;

	private void Start()
	{
		Debug.Log("Start");

		Lose += LoseGame;
		Pause += PauseGame;
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
			Lose?.Invoke();
		}

	}
	private void Awake()
	{

	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Pause?.Invoke();
		}
	}

	public void PlayerLoseLife()
	{
		lvData.CountPlayerHealth--;
		countPlayerHealth = lvData.CountPlayerHealth;
		Debug.Log(countPlayerHealth);
	}

	public void LoseGame()
	{
		Debug.Log("Lose");
	}

	public void PauseGame()
	{
		Debug.Log("Pause");
		SetPause(true);
	}

	public void SetPause(bool pause) => isPause = pause;
}
