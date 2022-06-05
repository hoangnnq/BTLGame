using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float speed = 8;
    public float posLimit = 7;
    Vector2 myPos;


    Rigidbody2D bulletRigid;
    SpriteRenderer bulletSprite;
    int angle = 0; 

    private void Awake()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
        bulletSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > myPos.x + posLimit || transform.position.x < myPos.x - posLimit)
        {
            gameObject.SetActive(false);
        }
        //xoay phi tieu
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
        myPos = transform.position;
        CheckDir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    void CheckDir()
    {
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
