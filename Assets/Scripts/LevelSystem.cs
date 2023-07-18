using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public List<LevelData> levelsInfo;

    public bool IsAllComplete()
	{
		foreach (LevelData lv in levelsInfo) if (!lv.IsComplete) return false;
		return true;
	}
}
