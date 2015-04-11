using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RateButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener(delegate {LevelManager.manager.GetComponentInParent<CameraZoom> ().Rate();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
