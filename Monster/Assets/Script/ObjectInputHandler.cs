using UnityEngine;
using System.Collections;

public class ObjectInputHandler : MonoBehaviour {

    void Update()
    {
        ProcClick();
    }

    //마우스 일경우 와 터치 일경우 따로 처리 한다.
    void ProcClick()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            //print(Input.mousePosition);
            ClickPosProc();
        }
#else
        for(int i = 0; i < Input.touchCount; i++){
            ClickPosProc();
        }
#endif
    }

    void ClickPosProc()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider == null)
        {
            //print("Null");
        }
        else if (hit.collider.gameObject.tag == "Egg")
        {
            hit.collider.gameObject.SendMessage("CurrentEggItchyDelivery");     //egg 움직이기itchy
            SendMessage("TimerAccel");      //시간 단축
        }
    }
}
