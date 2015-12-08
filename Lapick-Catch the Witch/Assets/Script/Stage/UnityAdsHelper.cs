using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UnityAdsHelper : MonoBehaviour
{

    //public Button _BtnUnityAds;

    //public GameObject adsPopupCallButton;
    //public GameObject adsSuccessMark;

    //ShowOptions _ShowOpt = new ShowOptions();
    //int _Gold = 0;

    //private bool isAdsInit;

    //void Awake()
    //{
    //    Advertisement.Initialize("89499", false);
    //    _ShowOpt.resultCallback = OnAdsShowResultCallBack;
    //    UpdateButton();
    //}

    //public void AdsOn()
    //{
    //    isAdsInit = true;
    //}


    //public void AdsOff()
    //{
    //    isAdsInit = false;
    //}

    //void OnAdsShowResultCallBack(ShowResult result)
    //{
    //    if (result == ShowResult.Finished)
    //    {
    //        _Gold += 100;
    //        adsPopupCallButton.SetActive(false);
    //        adsSuccessMark.SetActive(true);
    //        transform.root.SendMessage("AdsPopupOff");
    //        // 광고 종료 후 처리할 내용 넣기 -> 현재 보여지는 부분만 처리한 상태
    //        // 보상 늘리기 함수호출
    //        // 다음 광고 볼 수 있을 때 까지 시간 체크
    //    }

    //}

    //void UpdateButton()
    //{
    //    _BtnUnityAds.interactable = Advertisement.IsReady();
    //    _BtnUnityAds.GetComponentInChildren<Text>().text = "See ads and earn gold\r\nGold = " + _Gold.ToString();   //해당 부분은 필요 없는 부분
    //}

    //public void OnBtnUnityAds()
    //{
    //    Advertisement.Show(null, _ShowOpt);
    //    print("sdfsdfsdf");
    //}

    //void Update()
    //{
    //    if (isAdsInit == true)
    //        UpdateButton();
    //}
}