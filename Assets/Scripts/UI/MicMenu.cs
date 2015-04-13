using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MicMenu : MonoBehaviour {

	public CanvasGroup slider;
	public Slider MenuSlider;
	public Slider loseSlider;

	// Use this for initialization
	void Start () {
		if (LevelManager.manager.disableMicMenuSlider) {
			this.enabled = false;
		}
		MenuSlider.value = LevelManager.manager.sliderValue;
		loseSlider.value = LevelManager.manager.sliderValue;
		LevelManager.manager.GetComponentInParent<CameraZoom> ().micMenu = GetComponent<Button> ();
		GetComponent<Button> ().onClick.AddListener(delegate {LevelManager.manager.GetComponentInParent<CameraZoom> ().MicButtonOnClick();});
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuSlider.value != LevelManager.manager.sliderValue) {
			LevelManager.manager.sliderValue = MenuSlider.value;
			loseSlider.value = MenuSlider.value;
			LevelManager.manager.Save ();
		}
	}
}
