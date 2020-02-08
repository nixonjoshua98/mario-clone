using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : PhysicsObject
{
	private void Awake()
	{
		Vector3 pos = transform.position;

		pos.y += 2.0f;

		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);

			collision.gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 1.0f);

			collision.gameObject.GetComponent<PlayerController>().mushrooms++;
		}
	}
}
