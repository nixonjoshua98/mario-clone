using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PhysicsObject
{
	[Header("Sprites")]
	public Sprite circle;

	// Components
	SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
			spriteRenderer.sprite = circle;
			spriteRenderer.color = new Color(0.8f, 0.8f, 0);
		}

		Invoke("DestroyCoin", 0.25f);
	}

	void DestroyCoin()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().coins++;

		Destroy(gameObject);
	}
}
