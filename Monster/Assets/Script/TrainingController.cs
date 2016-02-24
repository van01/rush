using UnityEngine;
using System.Collections;

public class TrainingController : MonoBehaviour {

    private GameObject currentMonster;

    public enum TrainingType
    {
        Pow,
        Vit,
        Dex,
        Agr,
        Int,
    }

    public TrainingType currentTraining;

    public void CheckTrainingType()
    {
        switch (currentTraining)
        {
            case TrainingType.Pow:
                PowAction();
                break;
            case TrainingType.Vit:
                VitAction();
                break;
            case TrainingType.Dex:
                DexAction();
                break;
            case TrainingType.Agr:
                AgrAction();
                break;
            case TrainingType.Int:
                IntAction();
                break;
        }
    }

    public GameObject trainingDramaticHandler;

    public void MonsterPowTraining()
    {
        TrainingInitialize();

        currentTraining = TrainingType.Pow;
        CheckTrainingType();
    }

    public void TrainingInitialize()
    {
        //훈련 시작
        currentMonster = GetComponent<MonsterController>().currentMonster;

        //모든 UIclose
        SendMessage("HUDHideDelivery");

        GetComponent<GameState>().currentState = GameState.State.RoomOut;
        GetComponent<GameState>().CheckGameState();

        //훈련 시작 시 배고픔 멈춤
        SendMessage("CurrentMonsterHungryStopDilevery");
    }

    public void TrainingEnd()
    {
        //훈련 완료

        SendMessage("HUDInitializeDelivery"); //UI 복원
        GetComponent<MonsterController>().currentMonster.SendMessage("TrainingComplete");
        GetComponent<MonsterController>().currentMonster.SendMessage("HungryPlay");

        GetComponent<GameState>().currentState = GameState.State.MonsterEnd;
        GetComponent<GameState>().CheckGameState();


        switch (currentTraining)
        {
            case TrainingType.Pow:
                trainingDramaticHandler.GetComponent<TrainingDramaticHandler>().SendMessage("PowDirectionDestroy");
                break;
            case TrainingType.Vit:
                VitAction();
                break;
            case TrainingType.Dex:
                DexAction();
                break;
            case TrainingType.Agr:
                AgrAction();
                break;
            case TrainingType.Int:
                IntAction();
                break;
        }
        SendMessage("MonsterRestorePosition");     //진짜 현재 몬스터 복구
    }


    void PowAction()
    {
        //현재 트레이닝 비용 및 레벨 불러오기, 이번 트레이닝에서 증가될 능력치 계산
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
        trainingDramaticHandler.SendMessage("PowDirectionStart");
        //연출 호출
    }

    void VitAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void DexAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void AgrAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void IntAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }
}
