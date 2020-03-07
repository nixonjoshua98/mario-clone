using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UserEvaluation : MonoBehaviour
{
	public int currentScene = 0;

	public Text IDText;

	public DataLogger logger;

	public AssetMode assetMode;

	List<int> ids;


	private void Awake()
	{
		logger = new DataLogger();

		ids = new List<int>() { 0, 1, 2 };

		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		IDText.text = "ID: " + PlayerPrefs.GetInt("id").ToString();
	}

	public void StartStudy()
	{
		NextScene();
	}

	public void NextScene()
	{
		if (ids.Count == 0)
			currentScene = 3;
		else
		{
			int index = Random.Range(0, ids.Count);

			currentScene = ids[index];

			ids.RemoveAt(index);
		}

		switch (currentScene)
		{
			case 0:
				SceneManager.LoadSceneAsync("GameScene");

				assetMode = AssetMode.SPRITE;

				break;

			case 1:
				SceneManager.LoadSceneAsync("GameScene");

				assetMode = AssetMode.BLACK_WHITE;

				break;

			case 2:
				SceneManager.LoadSceneAsync("GameScene");

				assetMode = AssetMode.PRIMITIVE;

				break;

			case 3:
				logger.Save();

				PlayerPrefs.SetInt("id", PlayerPrefs.GetInt("id", -1) + 1);

				SceneManager.LoadScene("MenuScene");

				Destroy(gameObject);

				break;
		}
	}
}
