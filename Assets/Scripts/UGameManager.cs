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
		levelIndex = lvData.IndexLevel;

		player = GameObject.Find("Player");
		playerController = player.GetComponent<UPlayerController>();
		playerView = player.GetComponent<UPlayerView>();
		
		if(countPlayerHealth > 0)
		{
			playerController.PlayerDeath += PlayerLoseLife;
			playerController.PlayerWin += WinGame;
			playerController.PlayerCheck += ChangeStartPosition;
			StartInPosition();
			playerView.SetHelth();
		}
		else
		{
			Debug.Log("LoseInStart");
			playerView.SetHelth();
			LoseGame();
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
		SetStopGame(true);
		LoseBox.SetActive(true);
	}
	public void WinGame()
	{
		Debug.Log("Win");
		SetStopGame(true);
		WinBox.SetActive(true);
	}

	public void PauseGame()
	{
		Debug.Log("Pause");
		SetStopGame(true);
		PauseBox.SetActive(true);
	}
	public void SetStopGame(bool act)
	{
		if(!act)
		{
			PauseBox.SetActive(act);
			WinBox.SetActive(act);
			LoseBox.SetActive(act);
		}
		playerController.rb.velocity = Vector3.zero;
		isPause = act;
		Cursor.visible = act;
		Cursor.lockState = act ? CursorLockMode.Confined : CursorLockMode.Locked;
	}
	public Vector3 ChangeStartPosition(Vector3 pos)
	{
		lvData.StartPosition = pos;
		return pos;
	}
	public void StartInPosition()
	{
		player.transform.position = lvData.StartPosition;
	}
	public void LoadScene(int lv = 0) => SceneManager.LoadScene(lv);
	
}
