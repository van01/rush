using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPGSBtn : MonoBehaviour
{
    private string m_strLeaderBoard = "CgkI-cOhqfwPEAIQAQ"; // 리더보드 ID..

    void Start()
    {
        GPGSMng.GetInstance.InitializeGPGS(); // 초기화
    }

    //void Update()
    //{
    //    if (GPGSMng.GetInstance.bLogin == false)
    //    {
    //        print("Login");
    //    }
    //    else
    //    {
    //        print("Logout");
    //        //SettingUser();
    //    }
    //}

    public void GPGSClickEvent()
    {
        if (GPGSMng.GetInstance.bLogin == false)
        {
            GPGSMng.GetInstance.LoginGPGS(); // 로그인
        }
        //else
        //{
        //    GPGSMng.GetInstance.LogoutGPGS(); // 로그아웃
        //}
        
    }

    public void ShowLeaderBoard()
    {
        GPGSClickEvent();
        Social.ShowLeaderboardUI();
    }

    //void SettingUser()
    //{
    //    if (User_Texture.mainTexture != null)
    //        return;

    //    User_Label.enabled = true;
    //    User_Texture.enabled = true;

    //    User_Label.text = GPGSMng.GetInstance.GetNameGPGS();
    //    User_Texture.mainTexture = GPGSMng.GetInstance.GetImageGPGS();
    //}
}
