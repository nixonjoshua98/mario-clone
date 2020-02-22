using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBackground : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		if (GameManager.instance.assetMode == AssetMode.PRIMITIVE)
		{
			Destroy(gameObject);
		}

	}
}
