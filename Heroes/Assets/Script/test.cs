using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();


        login();
    }

    public void login()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success) Debug.Log("Sign in Success");
            else Debug.Log("Sign in Fail");
        });
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}
