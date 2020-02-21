﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://forum.unity.com/threads/mario-style-jumping.381906/

public class CoinBox : MonoBehaviour
{
	// Scripts
	CollisionTrigger colTrigger;

	[Header("Objects")]
	public GameObject coin;

	[Header("Sprites")]
	public Sprite afterHitSprite;
	public Sprite square;

	// Flags
	bool hasBeenHit = false;

	// Components
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		colTrigger = GetComponentInChildren<CollisionTrigger>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			spriteRenderer.sprite = square;
			spriteRenderer.color = new Color(1, 1, 0);
		}
	}

	private void Update()
	{
		if (hasBeenHit) return;


		if (colTrigger.isCollided)
		{
			OnHit();
		}
	}

	void OnHit()
	{
		hasBeenHit = true;

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			spriteRenderer.sprite = square;
			spriteRenderer.color = new Color(204.0f / 255.0f, 204.0f / 255.0f, 0.0f);
		}

		else if (GameManager.instance.assetMode == AssetMode.SPRITE)
		{
			spriteRenderer.sprite = afterHitSprite;
		}

		GameObject spawnedCoin = Instantiate(coin, transform.position, Quaternion.identity);
	}
}
