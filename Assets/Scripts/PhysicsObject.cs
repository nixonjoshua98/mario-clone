using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
	[Header("Modifiers")]
	public float gravityModifier = 1.0f;

	// - Flags
	protected bool isGrounded;

	// - Velocity
	protected Vector2 targetVelocity;
	protected Vector2 currentVelocity;

	// - Vector2
	protected Vector2 groundNormal;

	// - Contact filter
	protected ContactFilter2D contactFilter;

	// - Components
	protected Rigidbody2D rb2d;

	// - Constants
	protected const float minGroundNormalY = 0.65f;
	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
		contactFilter.useLayerMask = true;
	}

	void Update()
	{
		targetVelocity = Vector2.zero;

		ComputeVelocity();
	}

	protected virtual void ComputeVelocity()
	{

	}

	void FixedUpdate()
	{
		currentVelocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		currentVelocity.x = targetVelocity.x;

		isGrounded = false;

		Vector2 deltaPosition = currentVelocity * Time.deltaTime;

		Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

		Vector2 move = moveAlongGround * deltaPosition.x;

		Movement(move, false);

		move = Vector2.up * deltaPosition.y;

		Movement(move, true);
	}

	void Movement(Vector2 move, bool yMovement)
	{
		float distance = move.magnitude;

		RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
		List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

		if (distance > minMoveDistance)
		{
			int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

			for (int i = 0; i < count; i++)
				hitBufferList.Add(hitBuffer[i]);

			for (int i = 0; i < hitBufferList.Count; i++)
			{
				Vector2 currentNormal = hitBufferList[i].normal;
				if (currentNormal.y > minGroundNormalY)
				{
					isGrounded = true;

					if (yMovement)
					{
						groundNormal = currentNormal;
						currentNormal.x = 0;
					}
				}

				float projection = Vector2.Dot(currentVelocity, currentNormal);

				if (projection < 0)
					currentVelocity -= projection * currentNormal;

				float modifiedDistance = hitBufferList[i].distance - shellRadius;

				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}
		}

		rb2d.position += move.normalized * distance;
	}
}