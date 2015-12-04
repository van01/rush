﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTextEffect : MonoBehaviour
{
    public float ScoreDelay = 0.5f;

    private Vector3 pos;
    private Vector3 scale;
    private RectTransform rectTransform;
    private Rect rect;
    private float baseX;
    private float angleX;
    private float baseY;
    private float angleY;

    private enum HitType
    {
        Player,
        Enemy,
        Coin,
        Item,
    }

    private HitType currentHitType;

    private enum AttackType
    {
        Normal,
        Critical,
        Skill,
    }

    private AttackType currentAttackType;

    private float colorR;
    private float colorG;
    private float colorB;

    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        pos = rectTransform.localPosition;
        StartCoroutine("DisplayScore");

        AttackTypeValueSetting();

        HitTypeValueSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHitType == HitType.Enemy)
        {
            angleX += Mathf.Sign(baseX);
            angleY += Mathf.Sign(baseY);

            pos.x += Time.deltaTime * angleX * baseX;
            pos.y = Mathf.Cos(angleY * 0.1f) * baseY;

            rectTransform.localPosition = pos;
        }
        else if (currentHitType == HitType.Player)
        {
            angleX += Mathf.Sign(baseX);
            angleY += Mathf.Sign(baseY);

            pos.x -= Time.deltaTime * angleX * baseX;
            pos.y = Mathf.Cos(angleY * 0.1f) * baseY;

            rectTransform.localPosition = pos;
        }
        else
        {
            pos.y += 1.0f;

            rectTransform.localPosition = pos;
        }
    }

    IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(ScoreDelay);

        for (float i = 1; i >= 0; i -= 0.05f)
        {
            GetComponent<Text>().color = new Vector4(colorR, colorG, colorB, i);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }

    public void HitTypeSetting(string type)
    {
        if (type == "Player")
            currentHitType = HitType.Player;
        if (type == "Enemy")
            currentHitType = HitType.Enemy;
        if (type == "Coin")
            currentHitType = HitType.Coin;
        if (type == "Item")
            currentHitType = HitType.Item;
    }

    public void AttackTypeSetting(string type)
    {
        if (type == "Normal")
            currentAttackType = AttackType.Normal;
        if (type == "Critical")
            currentAttackType = AttackType.Critical;
        if (type == "Skill")
            currentAttackType = AttackType.Skill;
    }

    protected void HitTypeValueSetting()
    {
        if (currentHitType == HitType.Enemy)
        {
            colorR = 1.0f;
            colorG = 1.0f;
            colorB = 1.0f;
            
            GetComponent<Text>().color = new Vector4(colorR, colorG, colorB, 1.0f);
            
        } else if (currentHitType == HitType.Player){
            colorR = 0.5f;
            colorG = 0f;
            colorB = 0f;

            GetComponent<Text>().color = new Vector4(colorR, colorG, colorB, 1.0f);
        } else if (currentHitType == HitType.Coin){
            colorR = 1.0f;
            colorG = 0.9f;
            colorB = 0f;

            GetComponent<Text>().color = new Vector4(colorR, colorG, colorB, 1.0f);
        } else {
            colorR = 1.0f;
            colorG = 1.0f;
            colorB = 1.0f;

            GetComponent<Text>().color = new Vector4(colorR, colorG, colorB, 1.0f);
        }
    }

    protected void AttackTypeValueSetting()
    {
        if (currentAttackType == AttackType.Normal)
        {
            baseX = 3.0f;
            baseY = pos.y / 2;

            GetComponent<Text>().fontSize = 30;
        }
        else if (currentAttackType == AttackType.Critical)
        {
            baseX = 3.0f;
            baseY = pos.y / 2;

            GetComponent<Text>().fontSize = 30;
        }
        else if (currentAttackType == AttackType.Skill)
        {
            baseX = 15.0f;
            baseY = pos.y;

            GetComponent<Text>().fontSize = 50;
        }
        else
        {
            baseX = 3.0f;
            baseY = pos.y / 2;
        }
    }

    public void BaseValueSetting()
    {
        baseX = 3.0f;
        baseY = pos.y / 2;
    }

    public void SkillBaseValueSetting()
    {
        baseX = 5.0f;
        baseY = pos.y;
    }
}