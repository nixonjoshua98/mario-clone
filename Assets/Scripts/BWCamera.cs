using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;

public class BWCamera : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance.assetMode == AssetMode.BLACK_WHITE)
		{
			GetComponent<PostProcessLayer>().enabled = true;
		}
    }
}
