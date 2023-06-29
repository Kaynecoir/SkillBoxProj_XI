using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "UserTool/LevelData", order = 2)]
public class LevelData : ScriptableObject
{
	[SerializeField] private int countPlayerHealth;
	public int CountPlayerHealth { get => countPlayerHealth; set => countPlayerHealth = value; }
	[SerializeField] private bool firstActive;
	public bool FirstActive { get => firstActive;  set => firstActive = value;  }
}
