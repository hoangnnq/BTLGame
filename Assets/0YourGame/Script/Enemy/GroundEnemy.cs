using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : AnimalEnemy
{
    public GameObject txtHp;

    public bool canMove = true;
    public byte speed = 1;
    public bool isHorizontal = true;
    public bool isLeftToRight = true;
    public int posLimit = 4;
    public int hp = 6;
    public int exp = 2;
    public int dmg = 1;
    public float timeRevival = 5f;


    TextMesh txt;
    SpriteRenderer sprite;
    int hpNow;
    float time = 4;

    // Start is called before the first frame update
    void Start()
    {
        SetData();

        hpNow = hp;
        txt = txtHp.GetComponent<TextMesh>();
        sprite = GetComponent<SpriteRenderer>();
        SetTextHp();

        ECanMove = canMove;
        ESpeed = speed;
        EIsHorizonal = isHorizontal;
        EIsLeftToRight = isLeftToRight;
        EPosLimit = posLimit;
        EHp = hp;
        EExp = exp;
        EDmg = dmg;
        ETimeRevival = timeRevival;

        Move(transform, sprite);
    }
    void SetTextHp()
    {
        txt.text = hpNow + "/" + hp;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && txtHp.activeInHierarchy)
        {
            txtHp.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameController.instance.EnableAudio(music.hitEnemy);
            Fire(this);
            time = 4;
            hpNow -= Prefs.PlayerDamage;
            txtHp.SetActive(true);
            SetTextHp();
        }
        if (hpNow <= 0)
        {
            hpNow = hp;
            Die(gameObject);
            SetTextHp();
        }
    }
}
