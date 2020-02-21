using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2 : MonoBehaviour
{
	public Sprite square;

	private void Start()
	{
		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			GetComponent<SpriteRenderer>().sprite = square;

			GetComponent<SpriteRenderer>().color = new Color(160 / 255.0f, 82 / 255.0f, 45 / 255.0f);
		}
	}
}
