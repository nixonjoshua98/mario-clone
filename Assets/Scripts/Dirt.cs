using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
	[Header("Sprites")]
	public Sprite square;

	// Components
	SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			spriteRenderer.sprite = square;

			spriteRenderer.color = new Color(160 / 255.0f, 82 / 255.0f, 45 / 255.0f);
		}
	}
}
