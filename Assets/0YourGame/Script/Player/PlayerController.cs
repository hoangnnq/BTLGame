using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed = 8;
    public float jumpHeight = 20;

    public GameObject txtExp;
    public LayerMask groundLayer;


    bool grounded;

    SpriteRenderer mySpri;
    Rigidbody2D myRigid;
    Animator myAnim;
    TextMesh txt;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {

        mySpri = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        txt = txtExp.GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckRaycast();

        MovePlayer();

        Jump();
    }

    //method
    public void EnableExp(string exp)
    {
        txt.text = "+ " + exp + "exp";
        txtExp.SetActive(true); 
        txtExp.transform.DOMoveY(txtExp.transform.position.y + 3, 2).SetSpeedBased().SetLoops(-1, LoopType.Restart).OnStepComplete(() =>
        {
            txtExp.transform.DOPause();
            txtExp.SetActive(false);
        });
    }

    void CheckRaycast()
    {
        var hit = Physics2D.BoxCast(transform.position, new Vector2(0.4f, 0.1f), 0, Vector2.zero, 1, groundLayer);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
            if (myRigid.velocity.y > 0)
            {
                SetIsUp(true);
            }
            else
            {
                SetIsUp(false);
            }
        }
        myAnim.SetBool("grounded", grounded);
    }
    void SetIsUp(bool b)
    {
        myAnim.SetBool("isup", b);

    }

    void MovePlayer()
    {
        //D= 1; A = -1
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        if (move == 0)
        {
            return;
        }
        myRigid.velocity = new Vector2(move * speed, myRigid.velocity.y);


        if (move > 0 && mySpri.flipX || move < 0 && !mySpri.flipX)
        {
            mySpri.flipX = !mySpri.flipX;
        }

        Prefs.PosXPlayer = transform.position.x;
        Prefs.PosYPlayer = transform.position.y;
    }

    void Jump()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && grounded == true)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpHeight);
        }
    }
    // physical
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GroundTrigger"))
        {
            collision.collider.isTrigger = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundTrigger") && transform.position.y > collision.transform.position.y)
        {
            collision.isTrigger = false;
        }
    }

}
