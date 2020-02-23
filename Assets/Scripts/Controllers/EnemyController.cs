using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsObject
{
	Vector2 direction;

	// Components
	SpriteRenderer spriteRenderer;

	public void Awake()
	{
		direction = Vector2.left;

		spriteRenderer = GetComponent<SpriteRenderer>();

	}

	private new void FixedUpdate()
	{
		base.FixedUpdate();

		Vector3 start = transform.position + new Vector3(direction.x, direction.y);

		RaycastHit2D hit = Physics2D.Raycast(start, direction, 1.0f);
		RaycastHit2D hit2 = Physics2D.Raycast(start, Vector3.down, 1.0f);

		if ((hit.collider && !hit.collider.CompareTag("Player")) || !hit2.collider)
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;

			direction = direction == Vector2.left ? Vector2.right : Vector2.left;
		}
	}

	protected override void ComputeVelocity()
	{
		targetVelocity = (direction * 0.5f);
	}
}
