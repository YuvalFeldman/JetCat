using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteLose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LevelManager.manager.GetComponentInParent<CameraZoom> ().muteButtonLose = GetComponent<Button> ();
		GetComponent<Button> ().onClick.AddListener(delegate {LevelManager.manager.GetComponentInParent<CameraZoom> ().MuteButtonOnClick();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
