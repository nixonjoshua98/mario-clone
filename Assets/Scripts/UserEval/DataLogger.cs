﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogger
{
	List<List<int>> data = new List<List<int>>();

	public DataLogger()
	{
		if (PlayerPrefs.GetInt("id", -1) == -1)
			PlayerPrefs.SetInt("id", 0);
	}

	public void Log()
	{
		var player		= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		var userEval	= GameObject.FindGameObjectWithTag("UserEvaluation").GetComponent<UserEvaluation>();
		var gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		int gameVariant				= (int) userEval.assetMode;
		int levelCompletionTime		= (int)gameManager.lifetime;
		int collectables			= player.collectables;
		int hits					= player.hits;
		int kills					= player.kills;

		int participant_id = PlayerPrefs.GetInt("id");

		data.Add(new List<int> { participant_id, gameVariant, levelCompletionTime, collectables, hits, kills });
	}

	public void Save()
	{
		List<string> stringData = new List<string>
		{
			"participant_id, gameVariant, levelCompletionTime, collectables, hits, kills"
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

		int participant_id = PlayerPrefs.GetInt("id");

		string filename = "participant-" + participant_id.ToString() + ".csv";
		string path = dataDir + "\\" + filename;

		System.IO.File.WriteAllLines(path, stringData);
	}
}
