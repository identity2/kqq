using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//a singleton to save and load data, the gameobject persists between different scenes
public class GameDataLoaderAndSaver : MonoBehaviour 
{
	public static GameDataLoaderAndSaver dataControl;

	private GameData data;

	private const int Galaxies = 5;
	private const int Levels = 13;

	void Awake()
	{
		//for debug use to init data
		//InitDataAndSave();
		//

		if (dataControl == null) {
			DontDestroyOnLoad (gameObject);
			dataControl = this;
		} else if (dataControl != this) {
			Destroy (gameObject);
		}

		Load ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			data = (GameData) bf.Deserialize (file);
			file.Close ();

		} else {
			InitDataAndSave();
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		bf.Serialize (file, data);
		file.Close ();
	}

	//Level hasn't completed has a score of -1
	void InitDataAndSave()
	{
		data = new GameData ();
		data.levelData = new float[Galaxies, Levels];

		for (int i = 0; i < Galaxies; i++) {
			for (int j = 0; j < Levels; j++) {
				data.levelData[i, j] = -1f;
			}
		}
		Save ();
	}

	//return the highscore of the level
	public float GetHighScore(int galaxy, int level)
	{
		return data.levelData [galaxy, level];
	}

	public void SetHighScoreAndSave(int galaxy, int level, float score)
	{
		data.levelData[galaxy, level] = score;
		Save ();
	}
}

[Serializable]
class GameData
{
	//maps level to highscore
	//Galaxy of Geometry: 0
	//Galaxy of Emotions: 1
	//Galaxy of Time	: 2
	//Galaxy of Colors	: 3
	//Galaxy of Formulas: 4

	//Level 0: Animation, 1~12: Game Levels

	public float[,] levelData;
}
