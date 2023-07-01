using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UGameManager : MonoBehaviour
{
	public LevelData lvData;
	public GameObject PauseBox, LoseBox, WinBox;
	public int countPlayerHealth, levelIndex;
	public delegate void SimpleFunction();
	public event SimpleFunction Lose, Pause, Win;
	public bool isPause;

	private GameObject player;
	private UPlayerController playerController;
	private UPlayerView playerView;

	private void Start()
	{
		Debug.Log("Start");
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

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
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Pause?.Invoke();
		}
	}

	public void PlayerLoseLife()
	{
		lvData.CountPlayerHealth--;
		countPlayerHealth = lvData.CountPlayerHealth;
		LoadScene(levelIndex);
	}

	public void LoseGame()
	{
		Debug.Log("Lose");
		SetPause(true);
	}
	public void WinGame()
	{
		Debug.Log("Win");
		SetPause(true);
	}

	public void PauseGame()
	{
		Debug.Log("Pause");
		SetPause(true);
	}
	public void SetPause(bool act)
	{
		PauseBox.SetActive(act);
		isPause = act;
		Cursor.visible = act;
		Cursor.lockState = act ? CursorLockMode.Confined : CursorLockMode.Locked;
	}
	public void LoadScene(int lv = 0) => SceneManager.LoadScene(lv);
	
}
