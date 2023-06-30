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
		SceneManager.LoadScene(lv);
	}
}
