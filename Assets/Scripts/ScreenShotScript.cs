﻿using UnityEngine;
using System.Collections;

public class ScreenShotScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Application.CaptureScreenshot("Screenshot.png");
	}
}
