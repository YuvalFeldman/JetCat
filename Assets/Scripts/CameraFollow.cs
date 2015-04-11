using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Cat;

	Jump catJump;

	private bool stopPurring = false;

	// Use this for initialization
	void Start () {
		catJump = Cat.GetComponent<Jump> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (stopPurring) {
			GetComponent<AudioSource> ().Stop ();
		} else {
			stopPurring = catJump.firstJumpHappened;
		}

		if (Cat != null) {
			transform.position = new Vector3 (Cat.transform.position.x + 1.5f, transform.position.y, -10);
		}
	}
}
