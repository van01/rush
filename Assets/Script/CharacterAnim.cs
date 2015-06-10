using UnityEngine;
using System.Collections;

public class CharacterAnim : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetInteger("aniNumber", 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
