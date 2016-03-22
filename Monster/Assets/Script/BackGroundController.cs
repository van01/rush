using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {
	public GameObject backGroundBasket;

	public GameObject _currentBackGround;

	void Start(){
		BackGroundInitialize ();
	}


	public void BackGroundInitialize(){
		//현재 상태 체크 후 세팅


	}

	public void BackGroundSetting(string state){
		if (state == "Home") {
			backGroundBasket.GetComponent<BackGroundBasket> ().currentBackGroundState = BackGroundBasket.BackGroundState.Home;
		} else if (state == "TPow") {
			backGroundBasket.GetComponent<BackGroundBasket> ().currentBackGroundState = BackGroundBasket.BackGroundState.TPow;
		}

		backGroundBasket.GetComponent<BackGroundBasket> ().CheckcurrentBackGroundState ();
	}
		
	public void CurrentBackGroundInitialize(){
		//기존 배경 찾아 지우기
		ChildDestroyer();

		//새로운 배경 생성
		_currentBackGround =  Instantiate(backGroundBasket.GetComponent<BackGroundBasket> ().currentBackGround, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		_currentBackGround.transform.SetParent(backGroundBasket.transform);
	}

	void ChildDestroyer()
	{
		Transform[] prevBackground = backGroundBasket.transform.GetComponentsInChildren<Transform>(true);

		if (prevBackground != null)
		{
			for (int i = 1; i < prevBackground.Length; i++)
			{
				if (prevBackground[i] != transform)
					Destroy(prevBackground[i].gameObject);
			}
		}
	}
}
