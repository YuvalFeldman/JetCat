using UnityEngine;
using System.Collections;
using System; 
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Advertisements;

public class LevelManager : MonoBehaviour {
	public static LevelManager manager;
	public int bestPillarScore;

	public bool cameraFinished;

	public int adsCounter;
	
	private string fileEnding = ".dat";
	
	void Awake () {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("30796", false);
		}

		if(manager == null){
			DontDestroyOnLoad(gameObject);
			manager = this;
		} else if(manager != this){
			Destroy(gameObject);
		}
	}

	void Start(){
		cameraFinished = false;

		adsCounter = 10;

		bestPillarScore = 0;
	}
	//Overwrites data, need to fix
	public void Save(int newBestScore)
	{	
		if (newBestScore > bestPillarScore) {
				BinaryFormatter bFormatter = new BinaryFormatter ();
				FileStream file = File.Create (Application.persistentDataPath + "/scoreInfo" + fileEnding);

				LevelData dataToSave = new LevelData ();
				bestPillarScore = newBestScore;
				dataToSave.bestPillarScore = newBestScore;


				bFormatter.Serialize (file, dataToSave);
				file.Close ();
		}
	}

	public void DisplayAd() {
		adsCounter = 7;
		Advertisement.Show(null, new ShowOptions{pause = true, resultCallback = result => {}});
	}

	public int Load()
	{
		if (File.Exists (Application.persistentDataPath + "/scoreInfo" + fileEnding)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/scoreInfo" + fileEnding, FileMode.Open);

			LevelData dataToLoad = (LevelData)bf.Deserialize (file);


			this.bestPillarScore = dataToLoad.bestPillarScore;
			file.Close ();
			return bestPillarScore;
		} else {
			return 0;
		}
	}

}



[Serializable]
class LevelData{
	public int bestPillarScore;
}