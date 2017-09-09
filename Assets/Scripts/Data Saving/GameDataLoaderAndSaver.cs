using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//a singleton to save and load data, the gameobject persists between different scenes
public class GameDataLoaderAndSaver : MonoBehaviour 
{
	public static GameDataLoaderAndSaver dataControl;

	private GameDataWithAds data;

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
			// Old data (without ads).
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			GameData oldData = (GameData) bf.Deserialize (file);
			file.Close ();

			// Migrate to the new data.
			data = new GameDataWithAds();
			data.levelData = oldData.levelData;
			data.showAds = false;
			Save();
		} else if (File.Exists (Application.persistentDataPath + "/playerInfo2.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo2.dat", FileMode.Open);
			data = (GameDataWithAds) bf.Deserialize (file);
			file.Close ();
		} else {
			InitDataAndSave();
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo2.dat");
		bf.Serialize (file, data);
		file.Close ();
	}

	//Level hasn't completed has a score of -1
	void InitDataAndSave()
	{
		data = new GameDataWithAds ();
		data.levelData = new float[Galaxies, Levels];

		for (int i = 0; i < Galaxies; i++) {
			for (int j = 0; j < Levels; j++) {
				data.levelData[i, j] = -1f;
			}
		}

		data.showAds = true;
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

	public bool SholdShowAds() {
		return data.showAds;
	}

	public void SetShowAdsAndSave(bool b) {
		data.showAds = b;
		Save();
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

// Will be serialized as "PlayerInfo2.dat"
[Serializable]
class GameDataWithAds
{
	public float[,] levelData;
	public bool showAds;
}