using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UMenuManager : MonoBehaviour
{
	public LevelSystem levelDatas;
	public GameObject secretButton;
	public LevelData secretLevel;
	public void Awake()
	{
		if(levelDatas.IsAllComplete())
		{
			secretButton.SetActive(true);
			levelDatas.levelsInfo.Add(secretLevel);
		}
	}
	public void LoadLevel(int lv)
	{
		levelDatas.levelsInfo[lv - 1].CountPlayerHealth = 5;
		levelDatas.levelsInfo[lv - 1].StartPosition = Vector3.zero;
		SceneManager.LoadScene(levelDatas.levelsInfo[lv-1].IndexLevel);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
