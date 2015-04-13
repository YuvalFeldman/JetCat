using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MicLose : MonoBehaviour {

	public CanvasGroup slider;
	public Slider loseSlider;

	// Use this for initialization
	void Start () {
		LevelManager.manager.GetComponentInParent<CameraZoom> ().micLose = GetComponent<Button> ();
		GetComponent<Button> ().onClick.AddListener(delegate {LevelManager.manager.GetComponentInParent<CameraZoom> ().MicButtonOnClick();});
	}
	
	// Update is called once per frame
	void Update () {
		if (loseSlider.value != LevelManager.manager.sliderValue) {
			LevelManager.manager.sliderValue = loseSlider.value;
			LevelManager.manager.Save ();
		}
	}
}
