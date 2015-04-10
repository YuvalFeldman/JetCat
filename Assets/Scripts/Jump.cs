using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jump : MonoBehaviour {

	public Image powerBar;
	private Rigidbody2D Player;
	private Animator CatAnimator;
	private float SoundPower, jumpPower, tempCounter;
	private bool time, jumpyReady, grounded;

	public GameObject WallOfScore, smallJetStream, largeJetStream, startSmallJetStream;

	private ParticleSystem smallJetEmitter;
	private ParticleSystem largeJetEmitter;

	bool firstParticleDestroy = true;

	public Text scoreText;
	private bool firstPlatform = true;

	// Use this for initialization
	void Start () {

		smallJetStream = null;
		largeJetEmitter = largeJetStream.GetComponent<ParticleSystem> ();
		largeJetEmitter.Pause ();

		powerBar.fillAmount = 0;
		CatAnimator = GetComponent<Animator> ();
		Player = GetComponent<Rigidbody2D>();
		CatAnimator.SetBool("notgrounded", false);
		grounded = true;
		time = true;
		jumpyReady = false;
		tempCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		SoundPower = GetComponent<SoundForm> ().getLoudness () * 5;


		if (SoundPower >= 5 && grounded) {
			if (!time) {
				jumpyReady = true;
				if (SoundPower > jumpPower) {
					jumpPower = SoundPower;
				}
			} else {
				if (smallJetStream == null) {
					if (firstParticleDestroy) {
						smallJetStream = (GameObject)Instantiate (startSmallJetStream, new Vector3(-2.277f, -6.872f, -3.25f), startSmallJetStream.transform.rotation);
					} else {

					}

					smallJetEmitter = smallJetStream.GetComponent<ParticleSystem> ();
				}
				jumpyReady = true;
				powerBar.fillAmount = jumpPower / 10;
				jumpPower += 0.2f;
				//Debug.Log(jumpPower);
			}
		}

		if (jumpyReady && SoundPower < 1 && grounded) {
			Destroy (smallJetStream);
			largeJetEmitter.Play ();
			jumpPower = Mathf.Clamp (jumpPower, 2.5f, 10f);

			Player.velocity = new Vector3 (0, jumpPower, 0);
			jumpPower = 0;
			CatAnimator.SetBool ("notgrounded", true);
			grounded = false;
			jumpyReady = false;
		} 

		//Debug.Log(SoundPower);
		/*if (Input.GetKeyUp (KeyCode.Space) ) {
			grounded = false;
			power = GetComponent<SoundForm>().getLoudness() * 20f;
			power = Mathf.Clamp(power, 3, 10);
			Player.velocity = new Vector3(0, power, 0);
		}
		*/
		if (!grounded) {
			Vector3 newPos = new Vector3(0.045f,0, 0);
			transform.position += newPos;
		}
	}

	public void OnCollisionEnter2D (Collision2D collision){

		scoreText.text = "" + WallOfScore.GetComponent<WallOfScore>().score;



		if (collision.gameObject.tag == "Terrain") {

			CatAnimator.SetBool("notgrounded", false);
			Debug.Log ("no?");
			grounded = true;
			powerBar.fillAmount = 0;
		}
	}

}
