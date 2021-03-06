﻿using UnityEngine;
using System.Collections;
using System;

public class ScreenShotScript : MonoBehaviour
{
	public AudioSource meowSource;
	public RenderTexture overviewTexture;
	public GameObject OVcamera;
	public string path = "";
	private Camera camera;

	void Start() {
		camera = OVcamera.GetComponent<Camera> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		meowSource.Play ();

		//StartCoroutine(TakeScreenShot());

	}
	
	// return file name
	

	public IEnumerator TakeScreenShot()
	{
		yield return new WaitForEndOfFrame();
		
		Camera camOV = OVcamera.GetComponent<Camera>();
		
		RenderTexture currentRT = RenderTexture.active;
		
		RenderTexture.active = camOV.targetTexture;
		camOV.Render();
		Texture2D imageOverview = new Texture2D(camOV.targetTexture.width, camOV.targetTexture.height, TextureFormat.RGB24, false);
		imageOverview.ReadPixels(new Rect(0, 0, camOV.targetTexture.width, camOV.targetTexture.height), 0, 0);
		imageOverview.Apply();
		
		RenderTexture.active = currentRT;
		
		
		// Encode texture into PNG
		byte[] bytes = imageOverview.EncodeToPNG();
		
		// save in memory
		path = Application.persistentDataPath + "/Screenshot.png";

		Debug.Log (path);
		
		System.IO.File.WriteAllBytes(path, bytes);
	}

}

