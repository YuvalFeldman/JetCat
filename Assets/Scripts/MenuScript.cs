using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public GameObject menu, score;
	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = menu.GetComponent<Animator> ();

		HideScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enter(){
		animator.SetBool("Enter", true);
		animator.SetBool("Exit", false);
	}

	public void Exit(){
		animator.SetBool("Exit", true);
		animator.SetBool("Enter", false);
	}

	public void ShowScore(){
		score.SetActive (true);
	}

	public void HideScore(){
		score.SetActive (false);
	}
}
