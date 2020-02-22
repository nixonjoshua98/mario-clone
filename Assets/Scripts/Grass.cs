using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
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

			spriteRenderer.color = new Color(0.0f, 1.0f, 0.0f);
		}
	}
}
