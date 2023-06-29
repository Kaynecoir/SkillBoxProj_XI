using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPlayerView : MonoBehaviour
{
	public Sprite healthOn, healthOff;
	public Image[] healthIcon;

	private UGameManager GM;
	private void Awake()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		healthIcon = GameObject.Find("Canvas/InfoBar (Health)").GetComponentsInChildren<Image>();
	}

	public void SetHelth()
	{
		for (int i = 0; i < healthIcon.Length; i++)
		{
			Debug.Log(healthIcon[i].name + "+" + GM.countPlayerHealth);
			healthIcon[i].sprite = i < GM.countPlayerHealth ? healthOn : healthOff;
			Debug.Log(i < GM.countPlayerHealth ? "On" : "Off");
		}
	}
}
