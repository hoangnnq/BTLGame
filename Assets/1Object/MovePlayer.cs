using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float MaxSpeed;
    public float JumpHeight;
    public GameObject pointup;
    public GameObject pointdown;

    bool facingRight;
    bool grounded;

    Rigidbody2D myBody;
    Animator myAnim;

    GameObject[] grTrigger;
    // Start is called before the first frame update

    void Start()
    {
        GameObject.Find("NamePlayer").GetComponent<TextMesh>().text = Prefs.NamePlayer;

        myBody = GetComponent<Rigidbody2D> ();
        myAnim = GetComponent<Animator> ();

        facingRight = true;
        grTrigger = GameObject.FindGameObjectsWithTag("GroundTrigger");
    }

    void FixedUpdate()
    {
        //D= 1; A = -1
        float move = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(move* MaxSpeed, myBody.velocity.y);

        if(move > 0 && !facingRight)
        {
            flip();
        }
        else if(move < 0 && facingRight)
        {
            flip();
        }

        myAnim.SetFloat("speed", Mathf.Abs(move));
        myAnim.SetBool("grounded", grounded);

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, JumpHeight);
            }
        }
        jumpState();

        Prefs.PosXPlayer = transform.position.x;
        Prefs.PosYPlayer = transform.position.y;
    }

    void flip()//xoay mặt
    {
        facingRight = !facingRight;
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }

    void jumpState()
    {
        float veloy = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (veloy > 0.01)
        {
            jumpover(pointup, Vector2.up, true);
        }
        else if (veloy < 0)
        {
            jumpover(pointdown,Vector2.down, false);
        }
        else
        {
            grounded = true;
        }

    }

    void jumpover(GameObject point,Vector2 v, bool b)
    {
        grounded = false;
        myAnim.SetBool("isup", b);
        RaycastHit2D hit = Physics2D.Raycast(point.transform.position,v, 20);
        Debug.DrawRay(point.transform.position, v, Color.green);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            hit.collider.isTrigger = b;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        if(collision.gameObject.tag == "Ground" && grTrigger.Length != 0)
        {
            VisiableGroundTrigger(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
        if (collision.gameObject.tag == "GroundTrigger" && grTrigger.Length != 0)
        {
            if(collision.transform.position.y < pointdown.transform.position.y)
                VisiableGroundTrigger(false);
        }
    }

    void VisiableGroundTrigger( bool b)
    {
        if (grTrigger[0].GetComponent<Collider2D>().isTrigger == !b)
        {
            foreach (var item in grTrigger)
            {
                item.GetComponent<Collider2D>().isTrigger = b;
            }
        }
    }
}
