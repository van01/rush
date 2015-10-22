﻿using UnityEngine;
using System.Collections;

public class RWHelmetRafflePanelHandler : MonoBehaviour {
    public GameObject tmpGameController;
    public GameObject HUD;

    public GameObject PlayerCharacter;
    private GameObject presentPlayerCharacter;

    public GameObject[] StartPosition;

    public GameObject disAblePanel;
    public GameObject helmetFullPanel;
    public GameObject resultPanel;

    private int currentPlayerCharacterNumber;


    void Start()
    {
        currentPlayerCharacterNumber = PlayerPrefs.GetInt("PlayerCharacterNumber");
        RaffleCharacterDraw();
        DisAblePanelOff();
    }

    public void RaffleCharacterDraw()
    {
        int randomPosition = (int)Random.RandomRange(0, StartPosition.Length);
        
        for (int i = 0; i < tmpGameController.GetComponent<RWPlayerController>().playerCharacter.Length; i++)
        {
            if (currentPlayerCharacterNumber == i)
            {
                PlayerCharacter = tmpGameController.GetComponent<RWPlayerController>().playerCharacter[i];
            }

        }

        presentPlayerCharacter = Instantiate(PlayerCharacter, transform.position, transform.rotation) as GameObject;
        
        tmpGameController.SendMessage("PlayerHealthBarOff");


        //Destroy(presentPlayerCharacter.GetComponent<PlayerAI>());
        //Destroy(presentPlayerCharacter.GetComponent<PlayerAbility>());
        //Destroy(presentPlayerCharacter.GetComponent<PlayerBattle>());

        Destroy(presentPlayerCharacter.GetComponent<Rigidbody2D>());
        presentPlayerCharacter.GetComponent<BoxCollider2D>().isTrigger = true;

        presentPlayerCharacter.GetComponent<CharacterWeaponHandler>().weponRNumber = 0;
        presentPlayerCharacter.GetComponent<CharacterWeaponHandler>().UseWeaponInialize();
        presentPlayerCharacter.GetComponent<CharacterWeaponHandler>().weaponR.transform.FindChild("weaponR").GetComponent<SpriteRenderer>().sortingLayerName = "UI";

        
        presentPlayerCharacter.transform.SetParent(transform);
        presentPlayerCharacter.transform.localScale = new Vector3(200f, 200f, 200f);
        presentPlayerCharacter.transform.position = StartPosition[0].transform.position;        //작업 후 randomPosition로 교체 필요
        
        ChangeLayersRecursively(presentPlayerCharacter.transform, "UI");
        presentPlayerCharacter.SendMessage("AllSpriteRendererSortingLayerUI");
    }

    public static void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }


    public void CompulsionTargetDelivery(Transform nButtonTransform)
    {
        
            presentPlayerCharacter.SendMessage("CompulsionTarget", nButtonTransform);
    }

    public void CharacterDestroy()
    {
        Destroy(presentPlayerCharacter);
    }

    public void DisAblePanelOn()
    {
        disAblePanel.SetActive(true);
    }

    public void DisAblePanelOff()
    {
        disAblePanel.SetActive(false);
    }

    public void ItemfullPanelOn()
    {
        helmetFullPanel.SetActive(true);
    }

    public void ItemfullPanelOff()
    {
        helmetFullPanel.SetActive(false);
    }

    public void TotalCoinRefreshDelivery()
    {
        HUD.SendMessage("TotalCoinRefresh");
    }

    public void AlertPanelActiveDelivery(int nAlertType)
    {
        HUD.SendMessage("AlertPanelActive", nAlertType);
    }
}
