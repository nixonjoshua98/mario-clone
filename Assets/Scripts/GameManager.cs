using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AssetMode
{
	SPRITE,
	PRIMITIVE,
	BLACK_WHITE
}

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	public float lifetime;

	public Text timerText;

	public AssetMode assetMode;

	private void Awake()
	{
		instance = this;

		GameObject obj = GameObject.FindGameObjectWithTag("UserEvaluation");

		UserEvaluation eval = obj.GetComponent<UserEvaluation>();

		assetMode = eval.assetMode;
	}

	private void Start()
	{
		lifetime = 0.0f;
	}

	private void FixedUpdate()
	{
		lifetime += Time.deltaTime;

		timerText.text = Mathf.FloorToInt(lifetime).ToString();
	}
}
