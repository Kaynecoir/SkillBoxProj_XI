using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UMenuManager : MonoBehaviour
{
	public LevelData[] levelDatas;
	public void LoadLevel(int lv)
	{
		levelDatas[lv - 1].CountPlayerHealth = 5;
		levelDatas[lv - 1].StartPosition = Vector3.zero;
		SceneManager.LoadScene(levelDatas[lv-1].IndexLevel);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
