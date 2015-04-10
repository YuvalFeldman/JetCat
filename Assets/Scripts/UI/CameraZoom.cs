using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	public Animator animator;
	//public bool firstRun;
	public Canvas menu;
	
	void Start () {
		animator.enabled = true;
		menu.enabled = true;
	}

	public void Play () {
		animator.SetBool("Zoom", true);
		menu.enabled = false;
	}
}
