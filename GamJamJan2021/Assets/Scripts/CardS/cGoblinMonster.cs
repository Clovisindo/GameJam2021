using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGoblinMonster : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cGoblinMonster;
    public GameObject enemy;
    public GameObject ini_enemy;

    public AudioClip footSteps;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("cGoblinMonster") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        DO_NOT = false;
        cardValue = (int)enumTypeCard;
        ini_enemy = GameObject.FindGameObjectWithTag("ini_enemy");
        enemy = Resources.Load<GameObject>("cGoblinMonster") as GameObject;
        footSteps = Resources.Load<AudioClip>("boots-leather-step-01");

    }

    public override void SpecialEffect()
    {
        GameManager.instance.SetDescriptionText("You kill a goblin, but The Lich is now much stronger...");
        SoundManager.instance.PlaySingle(footSteps);
        Instantiate(enemy, ini_enemy.transform.position, Quaternion.identity);
        GameManager.instance.UpdateMonsterKilled();//sumamos los monstruos matados
    }
}
