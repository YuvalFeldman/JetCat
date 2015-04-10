using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour {
	private const int countReset = 10;
	public static int countforads = countReset;
	
	void Awake(){
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("30796", false);
		}
	}
	
	
	// Use this for initialization
	void Start () {
		countforads--;
		if (countforads <= 0) {
			countforads = countReset;
			Advertisement.Show(null, new ShowOptions{pause = true, resultCallback = result => {}});
		}	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyUp (KeyCode.Space)) {
			countforads--;
		}
		Debug.Log (countforads);
		
		if (countforads <= 0) {
			countforads = countReset;
			Advertisement.Show(null, new ShowOptions{pause = true, resultCallback = result => {}});
		}	*/
		
		
	}
}
