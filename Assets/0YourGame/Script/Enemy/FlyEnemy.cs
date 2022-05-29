using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public bool canMove = true;
    public byte speed = 1;
    public bool isHorizontal = false;
    public bool isLeftToRight = true;
    public int posLimit = 3;
    public int hp = 5;
    public int exp = 2;


    // Start is called before the first frame update
    void Start()
    {
        ECanMove = canMove;
        ESpeed = speed;
        EIsHorizonal = isHorizontal;
        EPosLimit = posLimit;
        EIsLeftToRight = isLeftToRight;
        EHp = hp;
        EExp = exp;
        Move(transform);
    }

}
