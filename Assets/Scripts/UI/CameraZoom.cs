using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {



	public Animator animator;
	public bool firstRun;
	public Canvas menuCanvas, scoreCanvas;
	
	void Start () {
		animator.enabled = true;
		scoreCanvas.enabled = false;
		menuCanvas.enabled = false;
		firstRun = true;
	}

	void Update(){

		if (animator != null) {

			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Finished")) {
				animator.enabled = false;
			}

			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Keep State") && firstRun) {
				menuCanvas.enabled = true;
			}

		}
	}

	public void Play () {
		animator.SetBool("Zoom", true);
		firstRun = false;
		scoreCanvas.enabled = true;
		menuCanvas.enabled = false;
	}
}
