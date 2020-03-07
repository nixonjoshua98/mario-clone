using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : PhysicsObject
{
	public float movementSpeed = 1.0f;
	public float jumpMultiplier = 1.0f;

	private Vector3 startPoint;

	private int hp;

	[Header("Components")]
	public SpriteRenderer spriteRenderer;
	public Animator anim;

	[Header("Collectables")]
	public int coins; // Used for UI only
	public int collectables;
	public int hits;
	public int kills;

	[Header("Objects")]
	public Text coinText;

	[Header("Sprites")]
	public Sprite primSprite;

	public override void Start()
	{
		base.Start();

		startPoint = transform.position;

		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			anim.enabled = false;

			spriteRenderer.sprite = primSprite;
		}
	}

	IEnumerator IPlayerGrow()
	{
		const float COOLDOWN = 1.0f;
		const float INTERVAL = 0.25f;

		float timer = 0.0f;

		Vector3 startScale = transform.localScale;
		Vector3 finalScale = new Vector3(0.9f, 0.9f, 1.0f);

		if (transform.localScale != finalScale)
		{
			while (timer <= COOLDOWN)
			{
				transform.localScale = Vector3.Lerp(startScale, finalScale, timer / COOLDOWN);

				timer += INTERVAL;

				spriteRenderer.enabled = !spriteRenderer.enabled;

				yield return new WaitForSeconds(INTERVAL);
			}

			spriteRenderer.enabled = true;
			transform.localScale = finalScale;
		}
	}
	IEnumerator IPlayerShrink()
	{
		const float COOLDOWN = 1.0f;
		const float INTERVAL = 0.25f;

		float timer = 0.0f;

		Vector3 startScale = transform.localScale;
		Vector3 finalScale = new Vector3(0.75f, 0.75f, 1.0f);

		while (timer <= COOLDOWN)
		{
			transform.localScale = Vector3.Lerp(startScale, finalScale, timer / COOLDOWN);

			timer += INTERVAL;

			spriteRenderer.enabled = !spriteRenderer.enabled;

			yield return new WaitForSeconds(INTERVAL);
		}

		spriteRenderer.enabled = true;
		transform.localScale = finalScale;

	}



	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("Mushroom"))
		{
			collectables++;

			hp = 1;

			Destroy(collision.gameObject);

			StartCoroutine(IPlayerGrow());
		}

		else if (collision.gameObject.CompareTag("Enemy"))
		{
			float offset = hp == 0 ? 0.7f : 0.9f;

			Destroy(collision.gameObject);

			if (transform.position.y >= (collision.gameObject.transform.position.y + offset))
			{
				kills++;
			}
			else
			{
				hp--;

				hits++;

				// Die
				if (hp == -1)
					OnDeath();

				// Hit
				else
				{
					StartCoroutine(IPlayerShrink());
				}
			}
		}
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

	private new void FixedUpdate()  
	{
		base.FixedUpdate();

		coinText.text = coins.ToString();
	}

	private void LateUpdate()
	{
		if (currentVelocity.x != 0)
		{
			spriteRenderer.flipX = currentVelocity.x < 0.0f;
		}

		anim.SetFloat("VelocityX", Mathf.Abs(currentVelocity.x));

		// Fall off
		if (transform.position.y <= -10.0f)
		{
			hits++;

			OnDeath();
		}
	}

	private void OnDeath()
	{
		StartCoroutine("IPlayerShrink");

		GameObject cam = GameObject.Find("CM vcam1");

		hp = 0;

		transform.localScale = new Vector3(0.75f, 0.75f, 1.0f);

		cam.SetActive(false);

		transform.position = startPoint;

		cam.SetActive(true);
	}
}