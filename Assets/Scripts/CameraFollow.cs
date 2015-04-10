using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Cat;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Cat.transform.position.x + 1.5f, transform.position.y, -10);
	}
}
