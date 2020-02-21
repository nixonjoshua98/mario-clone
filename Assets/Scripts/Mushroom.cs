using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : PhysicsObject
{
	[Header("Sprites")]
	public Sprite circle;

	// Components
	SpriteRenderer spriteRenderer;

	private void Awake()
	{
		Vector3 pos = transform.position;

		pos.y += 2.0f;

		transform.position = pos;
	}

	public override void Start()
	{
		base.Start();

		spriteRenderer = GetComponent<SpriteRenderer>();

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
			spriteRenderer.sprite = circle;
			spriteRenderer.color = new Color(1.0f, 165 / 255.0f, 0.0f);
		}
	}
}
