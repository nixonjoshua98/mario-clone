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


	private void Awake()
	{
		logger = new DataLogger();

		PlayerPrefs.SetInt("id", PlayerPrefs.GetInt("id", -1) + 1);

		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		IDText.text = "ID: " + PlayerPrefs.GetInt("id").ToString();
	}

	public void StartStudy()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void NextScene()
	{
		++currentScene;

		logger.Log();

		switch (currentScene)
		{
			case 1:
				SceneManager.LoadScene("GameScene");
				break;

			case 2:
				logger.Save();
				SceneManager.LoadScene("MenuScene");
				Destroy(gameObject);
				break;
		}
	}
}
