using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDCharacterInfoController : MonoBehaviour {

    public GameObject playerNameTxt;
    public GameObject playerHPTxt;
    public GameObject enemyNameTxt;
    public GameObject enemyHPTxt;

    PlayerParams currentPlayerParams;
    EnemyParams currentEnemyParams;

    void Start()
    {
        CharacterInfoUpdate();
    }

    public void CharacterInfoUpdate()
    {
        currentPlayerParams = GetComponent<CharacterHandler>().playerObject.GetComponent<PlayerAbility>().GetParams();
        currentEnemyParams = GetComponent<CharacterHandler>().targetObject.GetComponent<EnemyAbility>().GetParams();

        playerNameTxt.GetComponent<Text>().text = currentPlayerParams.name;
        playerHPTxt.GetComponent<Text>().text = currentPlayerParams.curHP + " / " + currentPlayerParams.maxHP;

        enemyNameTxt.GetComponent<Text>().text = currentEnemyParams.name;
        enemyHPTxt.GetComponent<Text>().text = currentEnemyParams.curHP + " / " + currentEnemyParams.maxHP;
    }
}
