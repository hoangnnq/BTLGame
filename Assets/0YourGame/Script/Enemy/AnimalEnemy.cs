using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEnemy : Enemy
{
    bool eCanMove;
    byte eSpeed;
    bool eIsHorizonal;
    bool eIsLeftToRight;
    int ePosLimit;
    int edmg;

    public GameObject coin;
    public int questNeedItem;
    public GameObject itemQuest;

    public bool ECanMove { get => eCanMove; set => eCanMove = value; }
    public byte ESpeed { get => eSpeed; set => eSpeed = value; }
    public bool EIsHorizonal { get => eIsHorizonal; set => eIsHorizonal = value; }
    public bool EIsLeftToRight { get => eIsLeftToRight; set => eIsLeftToRight = value; }
    public int EPosLimit { get => ePosLimit; set => ePosLimit = value; }
    public int EDmg { get => edmg; set => edmg = value; }

    protected virtual void Move(Transform transf, SpriteRenderer eSprite)
    {
        if (!eCanMove)
        {
            return;
        }
        if (!eIsLeftToRight)
        {
            ePosLimit = -ePosLimit;
        }
        if (eIsHorizonal)
        {
            transf.DOMoveX(transf.position.x + ePosLimit, eSpeed).SetSpeedBased().SetLoops(-1, LoopType.Yoyo).OnStepComplete(() =>
            {
                eSprite.flipX = !eSprite.flipX;
            });
            //myRigid.velocity = new Vector2(0, speed);
        }
        else
        {
            transf.DOMove(new Vector2(transf.position.x + ePosLimit, transf.position.y + ePosLimit), eSpeed).SetSpeedBased().SetLoops(-1, LoopType.Yoyo).OnStepComplete(() =>
            {
                eSprite.flipX = !eSprite.flipX;
            });
            //myRigid.velocity = new Vector2(speed, 0);
        }
    }

    protected override void Die(GameObject enemy)
    {
        int random = Random.Range(0, 100);
        Vector2 pos = enemy.transform.position;
        if (random < 80)
        {
            Instantiate(coin, new Vector2(pos.x, pos.y + 1) , Quaternion.identity);
        }
        if (questNeedItem == Prefs.CurrentQuest && Prefs.CurrentQuantity < Prefs.NumberRequests && random < 30)
        {
            Instantiate(itemQuest, pos, Quaternion.identity);
        }
        base.Die(enemy);
    }

}
