using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticEnemy : Enemy
{
    public GameObject txtHp;

    public int hp = 5;
    public int exp = 1;
    public float timeRevival = 3f;

    TextMesh txt;
    int hpNow;
    float timeEnavleHp = 4;
    // Start is called before the first frame update
    void Start()
    {
        EHp = hp;
        EExp = exp;
        ETimeRevival = timeRevival;

        hpNow = hp;
        txt = txtHp.GetComponent<TextMesh>();
        SetTextHp();
    }

    void SetTextHp()
    {
        txt.text = hpNow + "/" + hp;
    }

    private void Update()
    {
        timeEnavleHp -= Time.deltaTime;
        if (timeEnavleHp < 0 && txtHp.activeInHierarchy)
        {
            txtHp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameController.instance.EnableAudio(music.hitEnemy);
            timeEnavleHp = 4;
            hpNow--;
            txtHp.SetActive(true);
            SetTextHp();
        }
        if (hpNow == 0)
        {
            if (Prefs.CurrentQuest == 1 )
            {
                Prefs.CurrentQuantity++;
                CanvasController.instance.UpdateQuest();
            }
            hpNow = hp;
            SetTextHp();
            Die(gameObject);
        }
    }
}
