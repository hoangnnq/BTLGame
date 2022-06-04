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
    List<GameObject> coin_pooling = new List<GameObject>();
    public int questNeedItem;
    public GameObject itemQuest;
    List<GameObject> itemQuest_pooling = new List<GameObject>();


    GameObject bullet;
    List<GameObject> bullet_pooling = new List<GameObject>();

    public bool ECanMove { get => eCanMove; set => eCanMove = value; }
    public byte ESpeed { get => eSpeed; set => eSpeed = value; }
    public bool EIsHorizonal { get => eIsHorizonal; set => eIsHorizonal = value; }
    public bool EIsLeftToRight { get => eIsLeftToRight; set => eIsLeftToRight = value; }
    public int EPosLimit { get => ePosLimit; set => ePosLimit = value; }
    public int EDmg { get => edmg; set => edmg = value; }

    public void SetData()
    {
        bullet = GameController.instance.bulletEnemy;
    }

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

    protected virtual void Fire(AnimalEnemy enemy)
    {
        foreach (GameObject g in bullet_pooling)
        {
            if (g.activeSelf)
                continue;
            g.transform.position = enemy.transform.position;
            g.GetComponent<BulletEnemy>().damage = enemy.EDmg;
            g.SetActive(true);
            return;
        }
        GameObject obj = Instantiate(bullet, enemy.transform.position, Quaternion.identity);
        obj.GetComponent<BulletEnemy>().damage = enemy.EDmg;
        bullet_pooling.Add(obj);
    }

    protected override void Die(GameObject enemy)
    {
        int random = Random.Range(0, 100);
        Vector2 posEnemy = enemy.transform.position;
        if (random < 80)
        {
            checkPooling(coin_pooling, new Vector2(posEnemy.x, posEnemy.y + 1), coin);
        }
        if (questNeedItem == Prefs.CurrentQuest && Prefs.CurrentQuantity < Prefs.NumberRequests && random < 30)
        {
            checkPooling(itemQuest_pooling, posEnemy, itemQuest);
        }
        base.Die(enemy);
    }

    void checkPooling(List<GameObject> lst, Vector2 pos, GameObject obj)
    {
        foreach (GameObject g in lst)
        {
            if (g.activeSelf)
                continue;
            g.transform.position = pos;
            g.SetActive(true);       
            return;
        }
        Instantiate(obj, pos, Quaternion.identity);
        lst.Add(obj);
    }

}
