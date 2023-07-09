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
	public ParticleSystem particleSystem;

	private UGameManager GM;
	private UPlayerController playerController;
	private void Awake()
	{
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		playerController = GetComponent<UPlayerController>();
		playerController.PlayerDeath += DeathBoom;
		healthIcon = GameObject.Find("Canvas/InfoBar (Health)").GetComponentsInChildren<Image>();
	}

	private void Update()
	{
		if (particleSystem != null) particleSystem.transform.position = transform.position;
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
		if (particleSystem != null) particleSystem.Play();
	}
}
