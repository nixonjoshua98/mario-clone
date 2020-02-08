using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogger
{
	List<List<int>> data = new List<List<int>>();

	int participant_id;

	public DataLogger()
	{
		participant_id = PlayerPrefs.GetInt("id", -1);

		if (participant_id == -1)
			PlayerPrefs.SetInt("id", 0);

		participant_id = PlayerPrefs.GetInt("id");
	}

	public void Log()
	{
		var player		= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		var userEval	= GameObject.FindGameObjectWithTag("UserEvaluation").GetComponent<UserEvaluation>();
		var gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		int gameVarient				= userEval.currentScene;
		int levelCompletetionTime	= (int)gameManager.lifetime;
		int mushrooms				= player.mushrooms;
		int deathes					= player.deathes;
		int coins					= player.coins;

		data.Add(new List<int> { participant_id, gameVarient, levelCompletetionTime, mushrooms, deathes, coins });
	}

	public void Save()
	{
		List<string> stringData = new List<string>
		{
			"participant_id, gameVarient, levelCompletetionTime, mushrooms, deathes, coins"
		};

		foreach (List<int> row in data)
		{
			string str = "";

			foreach (int val in row)
			{
				str += val.ToString() + ",";
			}

			stringData.Add(str);
		}

		string dataDir = System.IO.Directory.GetCurrentDirectory() + "\\" + "Results";

		if (!System.IO.Directory.Exists(dataDir))
		{
			System.IO.Directory.CreateDirectory(dataDir);
		}

		string filename = "participant-" + participant_id.ToString() + ".csv";
		string path = dataDir + "\\" + filename;

		System.IO.File.WriteAllLines(path, stringData);
	}
}
