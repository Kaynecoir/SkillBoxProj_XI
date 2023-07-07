using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "UserTool/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
	[SerializeField] private float playerSpeed;
	[SerializeField] private float playerMass;
	public float PlayerSpeed { get => playerSpeed; }
	public float PlayerMass { get => playerMass; }
}
