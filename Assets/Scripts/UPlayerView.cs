using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPlayerView : MonoBehaviour
{
	public Sprite useSprite;
	public Image useImage;
	public Sprite healthOn, healthOff;
	public Image[] healthIcon;
	public List<ParticleSystem> particleSystemList;

	private UGameManager GM;
	private UPlayerController playerController;
	private void Awake()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		playerController = GetComponent<UPlayerController>();
		playerController.PlayerDeath += DeathBoom;
		playerController.PlayerWin += ParticalSystemPlay;
		healthIcon = GameObject.Find("Canvas/InfoBar (Health)").GetComponentsInChildren<Image>();
	}

	private void Update()
	{
		if (particleSystemList.Count != 0)
		{
			foreach(ParticleSystem ps in particleSystemList)	ps.transform.position = transform.position;
		}
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

	private void DeathBoom()
	{
		if (particleSystemList.Count != 0)
		{
			particleSystemList[0].Play();
		}
	}

	private void ParticalSystemPlay()
	{
		if (particleSystemList.Count != 0)
		{
			foreach (ParticleSystem ps in particleSystemList) ps.Play();
		}
	}
}
