using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public AudioSource music, purr, meow;
	public Animator animatorCamera, menuAnimator, logoAnimator, scoreAnimator;
	public bool firstRun;
	public Canvas menuCanvas, scoreCanvas, logoCanvas;
	public Text text;
	public Sprite[] mutes;
	public Button muteButton;
	public Button muteButtonLose;

	void Start () {
		//text = GameObject.Find ("ScoreText").GetComponent<Text>();
		//text.text = "" + highScore;
		if(LevelManager.manager.mute){
			Mute ();
			muteButton.image.sprite = mutes[1];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[0];
			}
		} else {
			Unmute();
			muteButton.image.sprite  = mutes[0];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[0];
			}
		}

		logoCanvas.GetComponent<CanvasGroup>().alpha = 1;
		scoreAnimator.enabled = false;
		logoAnimator.enabled = true;
		animatorCamera.enabled = true;
		scoreCanvas.enabled = false;
		menuCanvas.enabled = true;
		menuCanvas.GetComponent<CanvasGroup>().alpha = 0;
		menuAnimator.enabled = false;
		firstRun = true;
	}

	void Update(){

		if (meow == null || purr == null) {
			meow = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			purr = GameObject.Find ("WallOfScore").GetComponent<AudioSource>();
		}

		if(LevelManager.manager.mute){
			Mute ();
			muteButton.image.sprite = mutes[1];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[1];
			} 

		} else {
			Unmute();
			muteButton.image.sprite  = mutes[0];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[0];
		
			} 
		}

		if (animatorCamera != null) {

			if (animatorCamera.GetCurrentAnimatorStateInfo (0).IsName ("Finished")) {
				animatorCamera.enabled = false;
				scoreCanvas.enabled = true;
				scoreAnimator.enabled = true;
				LevelManager.manager.cameraFinished = true;
			}

			if (animatorCamera.GetCurrentAnimatorStateInfo (0).IsName ("Keep State") && firstRun) {
				menuAnimator.enabled = true;
				menuAnimator.SetBool("Fade", true);
			}

		}
	}

	public void Play () {
		menuAnimator.SetBool("Fade", false);
		animatorCamera.SetBool("Zoom", true);
		firstRun = false;
		menuCanvas.enabled = false;
	}

	public void Rate(){
		Application.OpenURL("market://details?id="+"com.whoopstudios.jetcat");
	}

	public void MuteButtonOnClick(){
		if(LevelManager.manager.mute){
			Unmute();
			muteButton.image.sprite = mutes[0];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[0];
			}
		} else {
			Mute ();
			muteButton.image.sprite =  mutes[1];
			if (muteButtonLose != null) {
				muteButtonLose.image.sprite = mutes[1];
			}
		}
	}


	public void Mute(){
		music.enabled = false;
		purr.enabled = false;
		meow.enabled = false;
		LevelManager.manager.mute = true;
		LevelManager.manager.Save ();
	}

	public void Unmute(){
		music.enabled = true;
		purr.enabled = true;
		meow.enabled = true;
		LevelManager.manager.mute = false;
		LevelManager.manager.Save ();
	}
}
