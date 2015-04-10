using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FloorOfDeath : MonoBehaviour {
	public Canvas loseScreen;
	public Text text;
	public Text highScore;

	void Start(){
		text = GameObject.Find ("ScoreText").GetComponent<Text>();
		highScore.text = "" + LevelManager.manager.Load ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		LevelManager.manager.Save (int.Parse(text.text));
		LevelManager.manager.adsCounter--;
		if (LevelManager.manager.adsCounter <= 0) {
			LevelManager.manager.DisplayAd();
		}
		loseScreen.enabled = true;
	}
}
