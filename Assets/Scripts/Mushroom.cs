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
}
