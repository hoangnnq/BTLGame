using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    bool eCanMove;
    byte eSpeed;
    bool eIsHorizonal;
    int ePosLimit;
    bool eIsLeftToRight;
    int eHp;
    int eExp;

    public bool ECanMove { get => eCanMove; set => eCanMove = value; }
    public byte ESpeed { get => eSpeed; set => eSpeed = value; }
    public bool EIsHorizonal { get => eIsHorizonal; set => eIsHorizonal = value; }
    public int EPosLimit { get => ePosLimit; set => ePosLimit = value; }
    public bool EIsLeftToRight { get => eIsLeftToRight; set => eIsLeftToRight = value; }
    public int EHp { get => eHp; set => eHp = value; }
    public int EExp { get => eExp; set => eExp = value; }

    protected virtual void Move(Transform transf)
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
                transform.localScale *= new Vector2(-1, 1);
            });
            //myRigid.velocity = new Vector2(0, speed);
        }
        else
        {
            transf.DOMove(new Vector2(transf.position.x + ePosLimit, transf.position.y + ePosLimit), eSpeed).SetSpeedBased().SetLoops(-1, LoopType.Yoyo).OnStepComplete(() =>
            {
                transform.localScale *= new Vector2(-1, 1);
            });
            //myRigid.velocity = new Vector2(speed, 0);
        }
    }

    public void OnDestroy()
    {
        transform.DOKill();
    }
}
