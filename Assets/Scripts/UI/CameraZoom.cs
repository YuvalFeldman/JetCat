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
	public Sprite[] mics;

	public Button muteButton;
	public Button muteButtonLose;
	public Button micMenu;
	public Button micLose;

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

		if (!LevelManager.manager.touch) {
			micMenu.image.sprite = mics [1];
			micMenu.GetComponent<MicMenu>().slider.alpha = 0;
			micLose.image.sprite = mics[1];
			micLose.GetComponent<MicLose>().slider.alpha = 0;
		} else {
			micMenu.image.sprite = mics [0];
			micMenu.GetComponent<MicMenu>().slider.alpha = 1;
			micLose.image.sprite = mics[0];
			micLose.GetComponent<MicLose>().slider.alpha = 1;
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

		if (!LevelManager.manager.touch) {
			micMenu.image.sprite = mics [1];
			micMenu.GetComponent<MicMenu> ().slider.alpha = 0;
			micLose.image.sprite = mics[1];
			micLose.GetComponent<MicLose> ().slider.alpha = 0;

		} else {
			micMenu.image.sprite = mics [0];
			micMenu.GetComponent<MicMenu> ().slider.alpha = 1;
			micLose.image.sprite = mics[0];
			micLose.GetComponent<MicLose> ().slider.alpha = 1;
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

	public void MicButtonOnClick() { 
		if (!LevelManager.manager.touch) {
			LevelManager.manager.touch = true;
			LevelManager.manager.Save ();
		} else {
			LevelManager.manager.touch = false;
			LevelManager.manager.Save ();
		}
	}

	public void Play () {
		LevelManager.manager.disableMicMenuSlider = true;
		micMenu.GetComponent<MicMenu> ().enabled = false;
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

	public void TouchButton() {
		if (LevelManager.manager.touch) {

		}
		LevelManager.manager.touch = !LevelManager.manager.touch;
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
