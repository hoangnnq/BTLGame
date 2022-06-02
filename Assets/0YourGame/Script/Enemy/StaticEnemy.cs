using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticEnemy : Enemy
{
    public GameObject txtHp;

    public bool canMove = true;
    public int hp = 5;
    public int exp = 1;

    TextMesh txt;
    int hpNow;
    float time = 4;
    // Start is called before the first frame update
    void Start()
    {
        hpNow = hp;
        txt = txtHp.GetComponent<TextMesh>();
        SetTextHp();
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
            time = 4;
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
            Prefs.PlayerExp++;
            CanvasController.instance.UpdateExp(1);
            hpNow = hp;
            SetTextHp();
            Die(gameObject);
            DOVirtual.DelayedCall(2f, ()=> { gameObject.SetActive(true); });
        }
    }

    void SetTextHp()
    {
        txt.text = hpNow + "/" + hp;
    }
}
