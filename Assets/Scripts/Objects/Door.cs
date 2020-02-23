using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GameObject obj		= GameObject.FindGameObjectWithTag("UserEvaluation");
			UserEvaluation eval = obj.GetComponent<UserEvaluation>();

			eval.NextScene();
		}
	}
}
