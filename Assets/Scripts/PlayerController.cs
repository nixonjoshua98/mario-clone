using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
	public float movementSpeed = 1.0f;
	public float jumpMultiplier = 1.0f;

	private Vector3 startPoint;

	[Header("Components")]
	public SpriteRenderer spriteRenderer;
	public Animator anim;

	bool leftClicked = false;
	bool rightClicked = false;
	bool jumpClicked = false;

	private void Awake()
	{
		startPoint = transform.position;
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxisRaw("Horizontal");

		// Only allow jumping when grounded
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			currentVelocity.y = jumpMultiplier;
		}

		targetVelocity = move * movementSpeed;
	}

	private void LateUpdate()
	{
		if (currentVelocity.x != 0)
		{
			spriteRenderer.flipX = currentVelocity.x < 0.0f;
		}

		anim.SetFloat("VelocityX", Mathf.Abs(currentVelocity.x));

		if (transform.position.y <= -10.0f)
			transform.position = startPoint;
	}
}