using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelScript : MonoBehaviour {

	public GameObject Cat;

	public GameObject soundObject, optionWheel, LoadingBar, Menu;
	private Image menuUI;
	public Sprite[] sprites;
	private Image loadingBar;
	private float soundPower, delayTimer;
	private bool readyForAction, chosen, active, firstSpin, play, mute, credits, exit, canChoose;
	private int countSoundTime, animatorStage;
	private Animator animator;

	// Use this for initialization
	void Start () {
		menuUI = LoadingBar.GetComponent<Image> ();
		animatorStage = 0;
		delayTimer = 0;
		loadingBar = LoadingBar.GetComponent<Image> ();
		loadingBar.fillAmount = 0;
		animator = optionWheel.GetComponent<Animator> ();
		readyForAction = false;
		soundPower = 0;
		countSoundTime = 0;
		canChoose = true;
		active = true;
		chosen = false;
		firstSpin = true;
		play = false;
		mute = false;
		exit = false;
		credits = false;
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			delayTimer -= Time.deltaTime;
			if(delayTimer < 0)
			{
				canChoose = true;
			}if(canChoose){
				soundPower = soundObject.GetComponent<SoundForm> ().getLoudness () * 6;
				if (soundPower >= 3) {
					chosen = false;
					countSoundTime++;
					loadingBar.fillAmount += 0.04f;
				} else if (countSoundTime > 0) {
					if(countSoundTime < 5){
						loadingBar.fillAmount = 0;
						countSoundTime = 0;
					} else if (countSoundTime >= 5 && canChoose){ //Short
						chosen = true;
						loadingBar.fillAmount = 0;



						if (animatorStage == 0) {

							Menu.GetComponent<MenuScript>().Exit ();

							if (GameObject.Find ("SoundHolderForWheel") != null) {
								GameObject.Find ("SoundHolderForWheel").SetActive(false);
							} 

							Cat.SetActive(true);

						} else if (animatorStage == 1) {

						} else if (animatorStage == 2) {

						}
						else if (animatorStage == 3) {
							Application.Quit();
						}
					}
				}	
				if (loadingBar.fillAmount >= 1 && !chosen) {
					canChoose = false;
					loadingBar.fillAmount = 0;
					SpinWheel();
					readyForAction = false;
					countSoundTime = 0;
					delayTimer = 2;

				}
			}
		}
		/*if (Input.GetKeyDown(KeyCode.Space)) {
			SpinWheel();
		}*/
	}

	private void reset(){
	
		delayTimer = 0;
		loadingBar.fillAmount = 0;
		readyForAction = false;
		soundPower = 0;
		countSoundTime = 0;
		canChoose = true;
		active = false;
		chosen = false;
		while (animatorStage != 0) {
			SpinWheel ();
		}
		firstSpin = true;
		play = false;
		mute = false;
		exit = false;
		credits = false;
	}

	private void SpinWheel(){
		animatorStage++;
		Debug.Log (credits);
		if (animatorStage == 4) {
			animatorStage = 0;
		}
		if (firstSpin) {
			firstSpin = !firstSpin;
			play = true;
			animator.SetBool("Play", true);
		} else if (play) {
			play = !play;
			animator.SetBool("Play", false);
			animator.SetBool ("Mute", true);
			mute = true;
		} else if (mute) {
			animator.SetBool ("Mute", false);
			animator.SetBool ("Credits", true);
			mute = !mute;
			credits = true;

		}	else if (credits) {
				credits = !credits;
				animator.SetBool ("Credits", false);
				animator.SetBool("Exit", true);
				exit = true;
		}
		 else if (exit) {
			animator.SetBool ("Exit", false);
			animator.SetBool("Play", true);
			exit = !exit;
			play = true;
		} 
	}


	public void spriteChanger(int Menu){
		menuUI.sprite = sprites[Menu];
		if (Menu == 2) {
			this.Menu.GetComponent<MenuScript> ().ShowScore ();
		} else {
			this.Menu.GetComponent<MenuScript> ().HideScore ();
		}
	}
	public void takeAction(){}
}
