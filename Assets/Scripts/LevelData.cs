using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "UserTool/LevelData", order = 2)]
public class LevelData : ScriptableObject
{
	[SerializeField] private int indexLevel;
	[SerializeField] private int countPlayerHealth;
	[SerializeField] private Vector3 startPosition;
	[SerializeField] private PlayerData playerData;
	[SerializeField] private bool isComplete;
	public int IndexLevel { get => indexLevel; }
	public int CountPlayerHealth { get => countPlayerHealth; set => countPlayerHealth = value; }
	public Vector3 StartPosition { get => startPosition; set => startPosition = value; }
	public PlayerData PlayerData { get => playerData; }
	public bool IsComplete { get => isComplete; set{ if (!isComplete) isComplete = value; } }
}
