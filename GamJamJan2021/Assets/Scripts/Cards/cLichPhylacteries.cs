using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLichPhylacteries : CardScript
{

    public new EnumTypeCards enumTypeCard = EnumTypeCards.cLichPhylactery;
    public eLichBoss enemy;
    private int damageToLich = 1;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CLichPhylactery") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;
        enemy = GameObject.FindGameObjectWithTag("LichBoss").GetComponent<eLichBoss>();
    }

    public override void SpecialEffect()
    {
        enemy.LichTakeDamage(damageToLich);
    }
}
