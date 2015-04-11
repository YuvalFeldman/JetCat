using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LoseScreen : MonoBehaviour {
	public Canvas loseScreen;
	public Text  highScoreText;

	void Start(){
		loseScreen.enabled = false;
		highScoreText.text = "" + LevelManager.manager.highScore;
	}
	// Use this for initialization
	public void ShareImage () {
		#if UNITY_ANDROID
			string destination = Application.persistentDataPath + "/Screenshot.png";
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "testo");
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			
			// option one:
			currentActivity.Call("startActivity", intentObject);
		#endif
	}
	
	// Update is called once per frame
	public void RestartLevel () {
		Application.LoadLevel (Application.loadedLevel);
		loseScreen.enabled = false;
	}
}
