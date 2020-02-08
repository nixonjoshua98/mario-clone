using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://forum.unity.com/threads/mario-style-jumping.381906/

public class MushBox : MonoBehaviour
{
	CollisionTrigger colTrigger;

	public Sprite afterHitSprite;

	public GameObject mushroom;

	bool hasBeenHit = false;

	private void Awake()
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

		GetComponent<SpriteRenderer>().sprite = afterHitSprite;

		Instantiate(mushroom, transform.position, Quaternion.identity);
	}
}
