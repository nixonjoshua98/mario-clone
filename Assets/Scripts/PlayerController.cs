using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
	public float movementSpeed = 1.0f;
	public float jumpMultiplier = 1.0f;

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxisRaw("Horizontal");

		// Only allow jumping when grounded
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			currentVelocity.y = jumpMultiplier;
		}

		else if (Input.GetButton("Jump"))
		{
			//if (currentVelocity.y > 0)
			//{
			//	currentVelocity.y *= 1 - (0.25f * Time.deltaTime);
			//}
		}

		targetVelocity = move * movementSpeed;
	}
}