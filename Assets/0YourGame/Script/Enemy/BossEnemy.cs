using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    public Slider sliderHp;
    public int hp = 30;
    public int exp = 20;
    public float speed = 5;
    public int damage = 5;

    SpriteRenderer sprite;
    Rigidbody2D rigid;
    int hpNow;

    bool check = false;
    float time = 2;

    GameObject bullet;
    List<GameObject> bullet_poolingb = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        hpNow = hp;
        UpdateHp();
        Move();
        bullet = GameController.instance.bulletEnemy;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (check == true && time <= 0)
        {
            Ban(transform.position);
            time = 2;
        }
    }

    void UpdateHp()
    {
        sliderHp.maxValue = hp;
        sliderHp.value = hpNow;
    }

    void Move()
    {
        rigid.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ChangeDirection"))
        {
            ChangeDir();
            Move();
        }
    }

    void ChangeDir()
    {
        sprite.flipX = !sprite.flipX;
        speed = -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameController.instance.EnableAudio(music.hitEnemy);
            hpNow -= Prefs.PlayerDamage;
            UpdateHp();
            check = true;
        }
        if (hpNow <= 0)
        {
            Prefs.PlayerExp += exp;
            CanvasController.instance.UpdateExp(exp);
            gameObject.SetActive(false);
        }
    }

    void Ban(Vector2 pos)
    {
        foreach (GameObject g in bullet_poolingb)
        {
            if (g.activeSelf)
                continue;
            g.transform.position = pos;
            g.GetComponent<BulletEnemy>().damage = damage;
            g.SetActive(true);
            return;
        }
        Debug.Log(pos);
        GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
        obj.GetComponent<BulletEnemy>().damage = damage;
        bullet_poolingb.Add(obj);
    }
}
