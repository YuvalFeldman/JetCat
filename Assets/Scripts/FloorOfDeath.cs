using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FloorOfDeath : MonoBehaviour {
	public Canvas loseScreen;
	public Text text;
	public Animator scoreAnimator;

	void Start(){
		text = GameObject.Find ("ScoreText").GetComponent<Text>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.GetComponent<Collider2D> ());
		other.GetComponent<Jump> ().enabled = false;
		other.GetComponent<Rigidbody2D> ().isKinematic = true;
		scoreAnimator.SetBool("FadeBar", true);
		LevelManager.manager.adsCounter--;
		if (LevelManager.manager.adsCounter <= 0) {
			LevelManager.manager.DisplayAd();
		}
		LevelManager.manager.Save (int.Parse(text.text));
		loseScreen.enabled = true;
	}
}
