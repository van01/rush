using UnityEngine;
using System.Collections;

public class BackGroundBasket : MonoBehaviour {

	public GameObject currentBackGround;

	public GameObject[] homeBackGround;
	public GameObject[] trainingPowBackGround;

	public enum BackGroundState
	{
		Home,    	       //홈
		TPow,              //힘훈련
	}

	public BackGroundState currentBackGroundState;

	public void CheckcurrentBackGroundState()
	{
		switch (currentBackGroundState)
		{
		//레벨 체크 후 해당 리소스 세팅
		//playerprefab에서 리소스 id 파씽
		case BackGroundState.Home:
			currentBackGround = homeBackGround [0];
			break;
		case BackGroundState.TPow:
			currentBackGround = trainingPowBackGround [0];
			break;
		}
	}

}
