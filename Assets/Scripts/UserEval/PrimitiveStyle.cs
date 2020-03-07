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
			// To be destroyed
			if (destroy)
			{
				Destroy(gameObject);

				return;
			}

			// Has a Renderer
			if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
			{
				spriteRenderer.sprite = primitive;

				if (col != Vector3.zero)
					spriteRenderer.color = new Color(col.x, col.y, col.z);
			}

			// Has a UI Image component
			else if (gameObject.TryGetComponent<Image>(out Image image))
			{
				image.sprite = primitive;

				if (col != Vector3.zero)
					image.color = new Color(col.x, col.y, col.z);
			}

			// Update the scale if it needs to change
			if (newScale != Vector3.zero)
				transform.localScale = newScale;
		}
	}
}
