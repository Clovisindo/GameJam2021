using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cOrcMonster : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cOrcMonster;
    public GameObject enemy;
    public GameObject ini_enemy;

    public AudioClip footSteps;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("cOrcMonster") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;
        ini_enemy = GameObject.FindGameObjectWithTag("ini_enemy");
        enemy = Resources.Load<GameObject>("cOgre") as GameObject;
        footSteps = Resources.Load<AudioClip>("boots-leather-jump-01");


    }

    public override void SpecialEffect()
    {
        SoundManager.instance.PlaySingle(footSteps);
        Instantiate(enemy, ini_enemy.transform.position, Quaternion.identity);
        GameManager.instance.UpdateMonsterKilled();//sumamos los monstruos matados
    }
}
