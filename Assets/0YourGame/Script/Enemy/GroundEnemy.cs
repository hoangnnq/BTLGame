using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    public bool canMove = true;
    public byte speed = 1;
    public bool isHorizontal = true;
    public bool isLeftToRight = true;
    public int posLimit = 4;
    public int hp = 8;
    public int exp = 1;


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
