using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject tmpCharacter;	//임시
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CharacterStateChange(string s){
		tmpCharacter.gameObject.SendMessage("CharacterStateControll", s);
	}
}
