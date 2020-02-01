using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
	CollisionTrigger colTrigger;

	public Sprite afterHitSprite;

	bool hasBeenHit = false;

	private void Awake()
	{
		colTrigger = GetComponentInChildren<CollisionTrigger>();
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

		GetComponent<SpriteRenderer>().sprite = afterHitSprite;
	}
}
