using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UserEvaluation : MonoBehaviour
{
	public int currentScene = 0;

	public Text IDText;

	private DataLogger logger;

	public AssetMode assetMode;


	private void Awake()
	{
		logger = new DataLogger();

		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		IDText.text = "ID: " + PlayerPrefs.GetInt("id").ToString();
	}

	public void StartStudy()
	{
		SceneManager.LoadSceneAsync("GameScene");

		assetMode = AssetMode.SPRITE;
	}

	public void NextScene()
	{
		++currentScene;

		logger.Log();

		switch (currentScene)
		{
			case 1:
				SceneManager.LoadSceneAsync("GameScene");

				assetMode = AssetMode.PRIMITIVE;

				break;

			case 2:
				logger.Save();

				PlayerPrefs.SetInt("id", PlayerPrefs.GetInt("id", -1) + 1);

				SceneManager.LoadScene("MenuScene");

				Destroy(gameObject);

				break;
		}
	}
}
