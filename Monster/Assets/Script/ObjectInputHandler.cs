using UnityEngine;
using System.Collections;

public class ObjectInputHandler : MonoBehaviour {

    protected int _clickCount;

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
            ClickPosProc(Input.mousePosition);
            _clickCount = 0;
        }
#else
        for(int i = 0; i < Input.touchCount; i++){
            ClickPosProc(Input.touches[i].position);
        }
        _clickCount = 0;
#endif
    }

    void ClickPosProc(Vector3 tPos)
    {
        _clickCount++;
        Ray ray = Camera.main.ScreenPointToRay(tPos);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Egg")
            {
                //print("Egg");
                
                hit.collider.gameObject.SendMessage("CurrentEggItchyDelivery");     //egg 움직이기itchy
                SendMessage("TimerAccel");      //시간 단축
            }

        }
    }
}
