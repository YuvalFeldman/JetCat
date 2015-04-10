using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public GameObject BackGround;
	public Sprite BackGroundSprite1;
	public Sprite BackGroundSprite2;

	public GameObject davidSucks;

	public GameObject Pyramid1;
	public GameObject Pyramid2;
	public GameObject Pyramid3;
	public GameObject Pyramid4;
	public GameObject Pyramid5;
	public GameObject Pyramid6;
	public GameObject Pyramid7;
	public GameObject Pyramid8;
	public GameObject LastPyramid;

	bool firstPyramidCollision = true;

	public GameObject Tree1;
	public GameObject Tree2;
	public GameObject Tree3;
	public GameObject Tree4;
	public GameObject Tree5;
	public GameObject Tree6;
	public GameObject Tree7;
	public GameObject Tree8;
	public GameObject Tree9;
	public GameObject Tree10;
	public GameObject LastTree;

	bool firstTree = true;

	public GameObject Cloud1;
	public GameObject Cloud2;
	public GameObject Cloud3;
	public GameObject Cloud4;
	public GameObject Cloud5;

	private float Cloud1Speed;
	private float Cloud2Speed;
	private float Cloud3Speed;
	private float Cloud4Speed;
	private float Cloud5Speed;

	GameObject LastCloud;

	public Sprite CloudSprite1;
	public Sprite CloudSprite2;
	public Sprite CloudSprite3;
	public Sprite CloudSprite4;
	public Sprite CloudSprite5;

	Sprite[] arrayCloudSprites = new Sprite[5];

	GameObject[] arrayOfTrees = new GameObject[10];
	GameObject[] arrayOfRandomTrees = new GameObject[10];
	bool[] treesExist = new bool[10];
	int filledTrees = 0;

	int DEATH_COLLISION_LAYER = 17;

	bool theme1;

	float yPyramidMax = -12;
	float yPramidMin = -8;


	// Use this for initialization
	void Start () {

		if (Random.Range (1, 10) < 5) {
			theme1 = true;
		} else {
			theme1 = false;
		}

		if (theme1) {

			InitTreesLayer();

			foreach (GameObject tree in arrayOfTrees) {
				int pick = Random.Range (0, 10);

				while (treesExist[pick] == true) {
					pick = (pick + 1) % 10;
				}

				treesExist[pick] = true;
				arrayOfRandomTrees[pick] = tree;
			}


			for (int i = 0; i < 10; i++) {
				if (i == 0) {
					arrayOfRandomTrees[i].transform.position = new Vector3(-3.3f, arrayOfRandomTrees[i].transform.position.y, 0);
				} else {
					arrayOfRandomTrees[i].transform.position = new Vector3(LastTree.transform.position.x + Random.Range (1.6f, 2.1f), -10.4f, 0);
				}

				LastTree = arrayOfRandomTrees[i];
			}

			BackGround.GetComponent<SpriteRenderer> ().sprite = BackGroundSprite1;

		} else {
			DeactivateTrees();
			BackGround.GetComponent<SpriteRenderer>().sprite = BackGroundSprite2;

			Pyramid1.transform.position = new Vector3(Random.Range (-1f, 2f), Random.Range (-12f, -8f), 0);

			Pyramid2.transform.position = new Vector3(Pyramid1.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);

			Pyramid3.transform.position = new Vector3(Pyramid2.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);

			Pyramid4.transform.position = new Vector3(Pyramid3.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);

			Pyramid5.transform.position = new Vector3(Pyramid4.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);
			
			Pyramid6.transform.position = new Vector3(Pyramid5.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);
			
			Pyramid7.transform.position = new Vector3(Pyramid6.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);
			
			Pyramid8.transform.position = new Vector3(Pyramid7.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);


			LastPyramid = Pyramid4;

			InitPyramidLayer();
		}

		InitCloudArray ();

		Cloud1.transform.position = new Vector3 (Random.Range (2.8f, 5.8f), Random.Range (-2.22f, -5.28f), 0);
		Cloud1.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];

		Cloud2.transform.position = new Vector3 (Cloud1.transform.position.x + Random.Range (4.4f, 7.35f), Random.Range (-2.22f, -5.28f), 0);
		Cloud2.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];

		Cloud3.transform.position = new Vector3 (Cloud2.transform.position.x + Random.Range (4.4f, 7.35f), Random.Range (-2.22f, -5.28f), 0);
		Cloud3.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];

		Cloud4.transform.position = new Vector3 (Cloud3.transform.position.x + Random.Range (4.4f, 7.35f), Random.Range (-2.22f, -5.28f), 0);
		Cloud4.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];

		Cloud5.transform.position = new Vector3 (Cloud4.transform.position.x + Random.Range (4.4f, 7.35f), Random.Range (-2.22f, -5.28f), 0);
		Cloud5.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];

		LastCloud = Cloud5;

		Cloud1Speed = Random.Range (0.0015f, 0.004f);
		Cloud2Speed = Random.Range (0.0015f, 0.004f);
		Cloud3Speed = Random.Range (0.0015f, 0.004f);
		Cloud4Speed = Random.Range (0.0015f, 0.004f);
		Cloud5Speed = Random.Range (0.0015f, 0.004f);

	}

	void Update() {
		Cloud1.transform.position = new Vector3 (Cloud1.transform.position.x - Cloud1Speed, Cloud1.transform.position.y, 0);
		Cloud2.transform.position = new Vector3 (Cloud2.transform.position.x - Cloud2Speed, Cloud2.transform.position.y, 0);
		Cloud3.transform.position = new Vector3 (Cloud3.transform.position.x - Cloud3Speed, Cloud3.transform.position.y, 0);
		Cloud4.transform.position = new Vector3 (Cloud4.transform.position.x - Cloud4Speed, Cloud4.transform.position.y, 0);
		Cloud5.transform.position = new Vector3 (Cloud5.transform.position.x - Cloud5Speed, Cloud5.transform.position.y, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.layer == 17) {
			
			if (theme1) {
			// Tree Collision
				GameObject tree = other.gameObject;
				tree.transform.position = new Vector3(LastTree.transform.position.x + Random.Range (1.6f, 2.1f), -10.4f, 0);
				LastTree = tree;
			} else {
				GameObject pyramid = other.gameObject;

				pyramid.transform.position = new Vector3(LastPyramid.transform.position.x + Random.Range (0, 7f), Random.Range (-12f, -8f), 0);
				LastPyramid = pyramid;

			}
		} else if (other.gameObject.layer == 16) {
			// Cloud Collision
			GameObject cloud = other.gameObject;
			cloud.transform.position = new Vector3(LastCloud.transform.position.x + Random.Range (4.4f, 7.35f), Random.Range (-2.22f, -5.28f), 0);
			cloud.GetComponent<SpriteRenderer> ().sprite = arrayCloudSprites [Random.Range (0, 4)];
			LastCloud = cloud;
		}
	}

	void RandomPyramids() {

	}

	void RandomTrees() {

	}

	void InitPyramidLayer() {
		Pyramid1.layer = DEATH_COLLISION_LAYER;
		Pyramid2.layer = DEATH_COLLISION_LAYER;
		Pyramid3.layer = DEATH_COLLISION_LAYER;
		Pyramid4.layer = DEATH_COLLISION_LAYER;
		Pyramid5.layer = DEATH_COLLISION_LAYER;
		Pyramid6.layer = DEATH_COLLISION_LAYER;
		Pyramid7.layer = DEATH_COLLISION_LAYER;
		Pyramid8.layer = DEATH_COLLISION_LAYER;

	}

	void InitCloudArray() {
		arrayCloudSprites [0] = CloudSprite1;
		arrayCloudSprites [1] = CloudSprite2;
		arrayCloudSprites [2] = CloudSprite3;
		arrayCloudSprites [3] = CloudSprite4;
		arrayCloudSprites [4] = CloudSprite5;
	}

	void DeactivateTrees() {
		Tree1.SetActive (false);
		Tree2.SetActive (false);
		Tree3.SetActive (false);
		Tree4.SetActive (false);
		Tree5.SetActive (false);
		Tree6.SetActive (false);
		Tree7.SetActive (false);
		Tree8.SetActive (false);
		Tree9.SetActive (false);
		Tree10.SetActive (false);
	}

	void InitTreesLayer() {

		arrayOfTrees [0] = Tree1;
		arrayOfTrees [1] = Tree2;
		arrayOfTrees [2] = Tree3;
		arrayOfTrees [3] = Tree4;
		arrayOfTrees [4] = Tree5;
		arrayOfTrees [5] = Tree6;
		arrayOfTrees [6] = Tree7;
		arrayOfTrees [7] = Tree8;
		arrayOfTrees [8] = Tree9;
		arrayOfTrees [9] = Tree10;

		Tree1.layer = DEATH_COLLISION_LAYER;
		Tree2.layer = DEATH_COLLISION_LAYER;
		Tree3.layer = DEATH_COLLISION_LAYER;
		Tree4.layer = DEATH_COLLISION_LAYER;
		Tree5.layer = DEATH_COLLISION_LAYER;
		Tree6.layer = DEATH_COLLISION_LAYER;
		Tree7.layer = DEATH_COLLISION_LAYER;
		Tree8.layer = DEATH_COLLISION_LAYER;
		Tree9.layer = DEATH_COLLISION_LAYER;
		Tree10.layer = DEATH_COLLISION_LAYER;
	}

}
