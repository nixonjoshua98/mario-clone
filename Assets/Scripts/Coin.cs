using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PhysicsObject
{
	private void Awake()
	{
		Invoke("DestroyCoin", 0.25f);
	}

	void DestroyCoin()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().coins++;

		Destroy(gameObject);
	}
}
