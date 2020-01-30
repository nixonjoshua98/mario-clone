using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float lifetime;

	public Text timerText;

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
