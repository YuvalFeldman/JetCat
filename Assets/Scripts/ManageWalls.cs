using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManageWalls : MonoBehaviour {

	public GameObject wallOne;
	public GameObject wallTwo;
	public GameObject wallThree;
	public GameObject wallFour;
	public GameObject wallFive;
	
	GameObject lastWall;

	float xRange;
	float yRange;
	float yStandard;

	// Use this for initialization
	void Start () {

		yStandard = wallOne.transform.position.y;

		refreshRandom ();

		wallTwo.transform.position = new Vector3 (wallOne.transform.position.x + xRange, yStandard + yRange, 0);

		refreshRandom ();

		wallThree.transform.position = new Vector3 (wallTwo.transform.position.x + xRange, yStandard + yRange, 0);

		refreshRandom ();

		wallFour.transform.position = new Vector3 (wallThree.transform.position.x + xRange, yStandard + yRange, 0);

		refreshRandom ();

		wallFive.transform.position = new Vector3 (wallFour.transform.position.x + xRange, yStandard + yRange, 0);

		lastWall = wallFive;

	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.layer == 11) {

			GameObject wall = other.gameObject;

			refreshRandom ();

			wall.transform.position = new Vector3 (lastWall.transform.position.x + xRange, yStandard + yRange, 0);

			lastWall = wall;

		}
	}

	void refreshRandom() {

		xRange = Random.Range (1.5f, 4.4f);

		if (xRange < 2.5f) {
			yRange = Random.Range (0, 0.3f);
		} else if (xRange < 3.3f) {
			yRange = Random.Range (0, 1.7f);
		} else {
			yRange = Random.Range (0, 3.4f);
		}
	}
}
