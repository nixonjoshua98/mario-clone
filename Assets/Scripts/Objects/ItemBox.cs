using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
	// Scripts
	CollisionTrigger colTrigger;

	[Header("Objects")]
	public GameObject itemToSpawn;

	[Header("Sprites")]
	public Sprite afterHitSprite;

	// Flags
	bool hasBeenHit = false;

	private void Start()
	{
		colTrigger = GetComponentInChildren<CollisionTrigger>();
	}

	private void Update()
	{
		if (hasBeenHit)
			return;


		if (colTrigger.isCollided)
		{
			OnHit();
		}
	}

	void OnHit()
	{
		hasBeenHit = true;

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		switch (GameManager.instance.assetMode)
		{
			case AssetMode.PRIMITIVE:
				spriteRenderer.color = new Color(204.0f / 255.0f, 204.0f / 255.0f, 0.0f);
				break;

			case AssetMode.SPRITE:
				spriteRenderer.sprite = afterHitSprite;
				break;

			case AssetMode.BLACK_WHITE:
				spriteRenderer.sprite = afterHitSprite;
				break;
		}

		GameObject spawnedCoin = Instantiate(itemToSpawn, transform.position, Quaternion.identity);
	}
}
