using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NativeShareWithImageHandler : MonoBehaviour {

    private Texture2D tex;

    void ShareImageInit()
    {
        print(tex);
    }

    void ShareImageDestroy()
    {
        DestroyImmediate(tex);
    }

    public void NativeShareWithImage()
    {
        StartCoroutine(ScreenShot());
    }

    IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();

        tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        tex.Apply();

        //SPShareUtility.ShareMedia("Share Caption", "Share Message", tex);

        //ShareImageDestroy();
        //신규 모자 습득 시 카톡 공유가 안됨, 확인 필요 다른 sns 공유는 됨 
    }
}
