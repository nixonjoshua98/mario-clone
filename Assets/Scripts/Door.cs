using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GameObject.FindGameObjectWithTag("UserEvaluation").GetComponent<UserEvaluation>().NextScene();
		}
	}
}
