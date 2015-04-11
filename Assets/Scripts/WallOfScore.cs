using UnityEngine;
using System.Collections;

public class WallOfScore : MonoBehaviour {

	public int platformCount;
	private bool firstPlatform;

	// Use this for initialization
	void Start () {
		platformCount = 0;
		firstPlatform = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (firstPlatform) {
			firstPlatform = !firstPlatform;
		} else {
			platformCount++;
		}
	}
}
