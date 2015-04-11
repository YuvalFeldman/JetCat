using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LevelManager.manager.GetComponentInParent<CameraZoom> ().muteButton = GetComponent<Button> ();
		GetComponent<Button> ().onClick.AddListener(delegate {LevelManager.manager.GetComponentInParent<CameraZoom> ().MuteButtonOnClick();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
