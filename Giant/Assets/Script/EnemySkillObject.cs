using UnityEngine;
using System.Collections;

public class EnemySkillObject : MonoBehaviour {

    public GameObject dangerEffectPrefab;
    public GameObject trigerPrefab;
    public GameObject skillEffect;

    public float dangerNoticeTime;
    public float delayTime;
    public float lifeTime;
    

    private GameObject currentDangerEffect;
    private GameObject currentTrigger;
    private GameObject currentSkillEffect;

    void Start()
    {
        InvokeEnemySkill();
    }

    public void InvokeEnemySkill()
    {
        currentDangerEffect = Instantiate(dangerEffectPrefab, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
        currentDangerEffect.transform.parent = transform;

        StartCoroutine(DangerDisable());

    }

    IEnumerator DangerDisable()
    {
        yield return new WaitForSeconds(dangerNoticeTime);
        currentDangerEffect.SetActive(false);

        //이펙트 관련 내용 추가 필요

        yield return new WaitForSeconds(delayTime);
        currentTrigger = Instantiate(trigerPrefab, transform.position, transform.rotation) as GameObject;
        currentTrigger.transform.parent = transform;

        yield return new WaitForSeconds(lifeTime);
        currentTrigger.SetActive(false);
    }

    public void EnemySkillPlayerHit()
    {
        print("Player Hit");
    }
}
