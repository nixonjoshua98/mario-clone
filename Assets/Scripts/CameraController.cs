using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	[Space]
	public float minY;
	public float maxY;

	private void LateUpdate()
	{
		Vector3 pos = player.transform.position;

		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		pos.z = transform.position.z;

		transform.position = pos;
	}
}
