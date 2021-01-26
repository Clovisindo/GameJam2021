using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGoblinMonster : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cGoblinMonster;
    //private int attackBonus = 1;
    public GameObject enemy;
    public GameObject ini_enemy;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("cGoblinMonster") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;
        ini_enemy = GameObject.FindGameObjectWithTag("ini_enemy");
        enemy = Resources.Load<GameObject>("cGoblinMonster") as GameObject;
        //falta añadir las referencias a enemy e ini_enemy??

    }

    public override void SpecialEffect()
    {
        Instantiate(enemy, ini_enemy.transform.position, Quaternion.identity);
    }

    public void AttackPlayer()
    {
    }
}
