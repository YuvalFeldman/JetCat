using UnityEngine;
using System.Collections;

public class MockBackground : MonoBehaviour {

	public GameObject backGround;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = backGround.transform.position;
	}
}
