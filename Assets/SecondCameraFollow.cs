using UnityEngine;
using System.Collections;

public class SecondCameraFollow : MonoBehaviour {

	public GameObject mainCameraToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = mainCameraToFollow.transform.position;
	}
}
