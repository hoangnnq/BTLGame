using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletPlayer : MonoBehaviour
{
    public float speed = 8;
    Rigidbody2D bulletRigid;
    SpriteRenderer bulletSprite;
    int angle = 0;


    // Update is called once per frame
    void Update()
    {
        if (bulletSprite.flipX && transform.rotation.z < 181)
        {
            angle += 5;

        }
        else if(!bulletSprite.flipX && transform.rotation.z >- 181)
        {
            angle -= 5;
        }
        else
        {
            angle = 0;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnEnable()
    {
        CheckDir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    void CheckDir()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
        bulletSprite = GetComponent<SpriteRenderer>();
        if (GameController.instance.player.GetComponent<SpriteRenderer>().flipX)
        {
            bulletRigid.velocity = new Vector2(-speed, 0);
            bulletSprite.flipX = true;
        }
        else
        {
            bulletRigid.velocity = new Vector2(speed, 0);
            bulletSprite.flipX = false;
        }
    }
}
