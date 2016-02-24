using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTrainingResultPopupHandler : MonoBehaviour {

    public GameObject basePanel;
    public GameObject detailPanel;

    public float basePanelPosY;
    public float detailPanelPosY;

    public GameObject detailCallButton;
    public GameObject detailCloseButton;

    public GameObject[] prevStat;
    public GameObject[] crrentStat;
    public GameObject[] changeStat;

    private bool isDetailPanelOn;

    private float currentBasePanelPosY;
    private float currentDetailPanelPosY;


    void Start()
    {
        currentBasePanelPosY = 0;
    }

    void Update()
    {
        if (isDetailPanelOn == true)
        {
            if (basePanelPosY > currentBasePanelPosY)
            {
                currentBasePanelPosY += 5.0f;
                basePanel.transform.localPosition = new Vector3(0, currentBasePanelPosY, 0);
            }
            if (detailPanelPosY < currentDetailPanelPosY)
            {
                currentDetailPanelPosY -= 5.0f;
                detailPanel.transform.localPosition = new Vector3(0, currentDetailPanelPosY, 0);
            }
        }
        else
        {
            if (currentBasePanelPosY != 0)
            {
                currentBasePanelPosY -= 5.0f;
                basePanel.transform.localPosition = new Vector3(0, currentBasePanelPosY, 0);
            }
            if (currentDetailPanelPosY != 0)
            {
                currentDetailPanelPosY += 5.0f;
                detailPanel.transform.localPosition = new Vector3(0, currentDetailPanelPosY, 0);
            }
        }
    }

	public void TrainingResultPopup()
	{
		
	}

    public void DetailpanelOn()
    {
        //디테일 패널 초기화
        //패널 이동
        isDetailPanelOn = true;

        detailCallButton.SetActive(false);
        detailCloseButton.SetActive(true);
    }

    public void DetailpanelOff()
    {
        //패널 이동
        isDetailPanelOn = false;

        detailCallButton.SetActive(true);
        detailCloseButton.SetActive(false);
    }
}
