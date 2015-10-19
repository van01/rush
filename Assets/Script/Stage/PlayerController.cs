﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float CharacterPositionInializeTime = 1.0f;

    private GameObject[] tmpPlayer;
    private bool characterEnterCheckTrueValue = false;

    private bool characterMovePredicate = false;
    private bool characterBattlePredicate = false;

    private float[] RWbeginCharacterTransform;

    private int PlayerEquipHelmetNumber;

    public enum States
    {
        Spawns,		//자기자리 찾아가기
        Idles,		//대기
        Moves,		//이동
        Runs,		//달리기
        Battles,		//전투
        Attacks,		//공격
        Skills,		//스킬
        Guards,		//방어
        Backs,		//후퇴
        Downs,	//앉기
        DownMoves,	//앉기
        DownBacks,	//앉기
        Deads,		//죽음
        Jumps,		//점프 시작
        Midairs,		//공중
        Landings,	//착지
    }

    public States currentStates;
    public States previousStates;

    void Awake()
    {
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        RWbeginCharacterTransform = new float[tmpPlayer.Length];

        characterMovePredicate = true;
    }

    void Start()
    {
        PlayerCharacterSorting();
        if (GetComponent<StageController>().isRWStage == true)
            RWBeginCharacterTransform();
    }

    // 캐릭터 초기화
    public void CharacterInialize()
    {
        GetPlayerEquipHelmetNumber();
        //캐릭터 자리잡기

        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterPositionInialize", CharacterPositionInializeTime);
            tmpPlayer[i].gameObject.SendMessage("EquipHelmet", PlayerEquipHelmetNumber);
            tmpPlayer[i].SendMessage("CharacterStateControll", "RWPlay");   ////
        }
    }

    private void CharacterStateChange(string s)
    {
        //모든 캐릭터 상태 전환
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterStateControll", s);
        }
    }

    public void CharacterEnterCheck()
    {
        //캐릭터 충돌체크
        if (characterEnterCheckTrueValue == true)
        {
            characterMovePredicate = false;
            characterBattlePredicate = true;
        }
    }

    public void CharacterEnterCheckTrue()
    {
        characterEnterCheckTrueValue = true;
    }

    public void CharacterActionCheck()
    {
        switch (currentStates)
        {
            case States.Spawns:
                CharacterStateChange("Spawn");
                break;
            case States.Idles:
                CharacterStateChange("Idle");
                break;
            case States.Moves:
                CharacterStateChange("Move");
                break;
            case States.Runs:
                CharacterStateChange("Run");
                break;
            case States.Battles:
                CharacterStateChange("Battle");
                break;
            case States.Guards:
                CharacterStateChange("Guard");
                break;
            case States.Backs:
                CharacterStateChange("Back");
                break;
            case States.Downs:
                CharacterStateChange("Down");
                break;
            case States.DownMoves:
                CharacterStateChange("DownMove");
                break;
            case States.DownBacks:
                CharacterStateChange("DownBack");
                break;
        }
    }

    public void CharacterMovePredicateOn()
    {
        previousStates = currentStates;
        currentStates = States.Moves;
        //SendMessage("GameStateControll", "Playing");
        CharacterActionCheck();
    }

    public void CharacterMovePredicateOff()
    {
        currentStates = previousStates;
        CharacterActionCheck();
    }

    public void CharacterGuardPredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.Guards;
        CharacterActionCheck();
    }

    public void CharacterGuardPredicateOff()
    {
        if (characterBattlePredicate == true)
            SendMessage("GameStateControll", "Hold");
        else
            SendMessage("GameStateControll", "Playing");

        //currentStates = previousStates;	-- ㄱㅐㅅㅓㄴ ㅍㅣㄹㅇㅛ
        currentStates = States.Moves;
        CharacterActionCheck();
    }

    public void CharacterBattlePredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        characterBattlePredicate = true;
        previousStates = currentStates;
        //currentStates = States.Battles;
        //CharacterActionCheck();
    }

    public void CharacterBattlePredicateOff()
    {
        characterBattlePredicate = false;
        currentStates = previousStates;
        CharacterActionCheck();
    }

    public void CharacterRunPredicateOn()
    {
        if (characterBattlePredicate == false)
        {
            SendMessage("GameStateControll", "Playing");
            SendMessage("RunScrollOn");
        }

        previousStates = currentStates;
        currentStates = States.Runs;
        CharacterActionCheck();
    }

    public void CharacterDownPredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.Downs;
        CharacterActionCheck();
    }

    public void CharacterDownMovePredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.DownMoves;
        CharacterActionCheck();
    }

    public void CharacterDownBackPredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.DownBacks;
        CharacterActionCheck();
    }

    public void CharacterRunPredicateOff()
    {
        if (characterBattlePredicate == true)
            SendMessage("GameStateControll", "Hold");
        else
            SendMessage("GameStateControll", "Playing");
        //currentStates = previousStates; -- 개선필요
        currentStates = States.Moves;
        CharacterActionCheck();
    }

    private void CharacterBattleStop()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("BattleStop");
        }
    }

    public void CharacterBackPredicateOn()
    {
        SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.Backs;
        CharacterActionCheck();
    }

    public void CharacterBackPredicateOff()
    {
        currentStates = States.Moves;
        CharacterActionCheck();
    }

    public void CharacterDownPredicateOff()
    {
        //currentStates = previousStates;	-- ㄱㅐㅅㅓㄴ ㅍㅣㄹㅇㅛ
        currentStates = States.Moves;
        CharacterActionCheck();
        CharacterFowardColliderOff();
    }

    //public void CharacterBattlingOn()
    //{
    //    for (int i = 0; i < tmpPlayer.Length; i++)
    //    {
    //        tmpPlayer[i].gameObject.SendMessage("BattlingOn");
    //    }
    //}

    //public void CharacterBattlingOff()
    //{
    //    for (int i = 0; i < tmpPlayer.Length; i++)
    //    {
    //        tmpPlayer[i].gameObject.SendMessage("BattlingOff");
    //    }
    //}

    public void CharacterAttactDistanceOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("AttDistanceOn");
        }
    }

    public void CharacterAttactDistanceOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("AttDistanceOff");
        }
    }

    public void CharacterFowardColliderOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("WeaponColliderOff");
        }
    }

    public void CharacterFowardColliderOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("FowardColliderOff");
            tmpPlayer[i].gameObject.SendMessage("WeaponColliderReset");
        }
    }

    void PlayerCharacterSorting()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterSorting", i);
        }
    }


    void PlyaerCharacterControllStateOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterControllStateOn");
        }
    }

    void PlyaerCharacterControllStateOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterControllStateOff");
        }
    }

    public void PlayerHealthBarOff()
    {
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("HealthBarInitOff");
            tmpPlayer[i].gameObject.SendMessage("HealthBarUpdateOff");
        }
    }



    /// <summary>
    /// Lapick ~ Rushing to Witch ~
    /// </summary>
    public void RWCharacterJumpAddforce()
    {
        for (int i = 0; i<tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("RWJumpAddforce");
        }
    }

    void RWBeginCharacterTransform()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            RWbeginCharacterTransform[i] = tmpPlayer[i].transform.position.y;
        }
    }

    public void RWCharacterPositionInit()
    {
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].transform.position = new Vector3(-1.5f, RWbeginCharacterTransform[i], 0);
        }
    }

    public void PlayerGravityScaleOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].GetComponent<Rigidbody2D>().drag = 3.0f;
            tmpPlayer[i].GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }

    public void PlayerGravityScaleOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].GetComponent<Rigidbody2D>().drag = 0f;
            tmpPlayer[i].GetComponent<Rigidbody2D>().gravityScale = 9.0f;
        }
    }

    void GetPlayerEquipHelmetNumber()
    {
        PlayerEquipHelmetNumber = PlayerPrefs.GetInt("CurrentHelmetNumber");
    }

    public void SetPlayerEquipHelmetNumber(int nPlayerEquipHelmetNumber)
    {
        PlayerEquipHelmetNumber = nPlayerEquipHelmetNumber;

        PlayerPrefs.SetInt("CurrentHelmetNumber", PlayerEquipHelmetNumber);

        SetPlayerEquipHelmet();
    }

    void SetPlayerEquipHelmet()
    {
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("EquipHelmet", PlayerEquipHelmetNumber);
        }
    }
}
