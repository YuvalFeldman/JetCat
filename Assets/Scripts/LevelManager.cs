using UnityEngine;
using System.Collections;
using System; 
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Advertisements;

public class LevelManager : MonoBehaviour {
	public static LevelManager manager;
	public int bestPillarScore;
	public bool cameraFinished, mute;
	public int highScore;
	public int adsCounter;
	
	private string fileEnding = ".dat";
	
	void Awake () {
		highScore = Load ();
		mute = false;
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
		if(adsCounter == 0){
			adsCounter = 10;
		}
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
				dataToSave.mute = mute;
				dataToSave.adCount = adsCounter;
				bFormatter.Serialize (file, dataToSave);
				file.Close ();
		}
	}

	public void DisplayAd() {
		adsCounter = 10;
		Advertisement.Show(null, new ShowOptions{pause = true, resultCallback = result => {}});
	}

	public int Load()
	{
		if (File.Exists (Application.persistentDataPath + "/scoreInfo" + fileEnding)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/scoreInfo" + fileEnding, FileMode.Open);

			LevelData dataToLoad = (LevelData)bf.Deserialize (file);
			this.adsCounter = dataToLoad.adCount;
			this.mute = dataToLoad.mute;
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
	public bool mute;
	public int adCount;
}