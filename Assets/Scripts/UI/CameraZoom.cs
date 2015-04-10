using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	public Animator animator;
	private float timer;
	public bool firstRun;

	// Use this for initialization
	void Start () {
		timer = 3;
		firstRun = true;
		animator.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(firstRun){
			timer -= Time.deltaTime;
			if ( timer< 0 )
			{
				animator.SetBool("Zoom", true);
				firstRun = false;
				this.enabled = false;
			}
		} else {
			this.enabled = false;
		}
	}
}
