using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimitiveStyle : MonoBehaviour
{
	[Header("Sprites")]
	public Sprite primitive;

	[Header("Changes")]
	public bool destroy;

	[Space]

	public Vector3 col;
	public Vector3 newScale = Vector3.zero;

	private void Start()
	{
		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			if (destroy)
			{
				Destroy(gameObject);

				return;
			}

			if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
			{
				spriteRenderer.sprite = primitive;

				if (col != Vector3.zero)
					spriteRenderer.color = new Color(col.x, col.y, col.z);
			}

			else if (gameObject.TryGetComponent<Image>(out Image image))
			{
				image.sprite = primitive;

				if (col != Vector3.zero)
					image.color = new Color(col.x, col.y, col.z);
			}


			if (newScale != Vector3.zero)
				transform.localScale = newScale;
		}
	}
}
