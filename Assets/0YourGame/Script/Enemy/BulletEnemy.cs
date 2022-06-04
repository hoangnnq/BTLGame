using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int damage;
    bool collidePlayer;
    GameObject player;

    private void Awake()
    {
        player = GameController.instance.player;

    }

    void Update()
    {
        if (!collidePlayer)
        {
            transform.DOMove(player.transform.position, 1);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collidePlayer = true;
            Prefs.PlayerHP -= damage;
            PlayerController.instance.EnableHp(damage,"-hp");
            CanvasController.instance.UpdateHP();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        collidePlayer = false;
    }
}
