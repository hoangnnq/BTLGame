using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed = 8;
    public float jumpHeight = 20;
    public float timeHeal = 10;

    List<GameObject> lstBullet = new List<GameObject>();

    public GameObject txtHpPlayer;
    public GameObject txtMpPlayer;
    public GameObject txtExpPlayer;
    public GameObject LvUpPlayer;
    public GameObject EffectPlayer;
    public LayerMask groundLayer;

    public int heal = 1;
    public int mpDesAtk = 1;

    bool grounded;
    float countdownTime;
    GameObject bullet;

    SpriteRenderer mySpri;
    Rigidbody2D myRigid;
    Animator myAnim;
    Collider2D myColli;
    TextMesh txtHp,txtMp;
    Transform transfTxtExp;

    List<GameObject> lstTxtExp = new List<GameObject>();
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
        bullet = GameController.instance.bullet;
        countdownTime = timeHeal;
        mySpri = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myColli = GetComponent<Collider2D>();
        txtHp = txtHpPlayer.GetComponent<TextMesh>();
        txtMp = txtMpPlayer.GetComponent<TextMesh>();
        transfTxtExp = txtExpPlayer.transform;
        lstTxtExp.Add(txtExpPlayer);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckHeal();

        CheckRaycast();

        MovePlayer();

        Jump();

        Fire();
    }

    //method

    public void CheckHeal()//auto hoi mau va mana moi khoang thoi gian coutdowntime
    {
        countdownTime -= Time.fixedDeltaTime;
        if (countdownTime < 0)
        {
            countdownTime = timeHeal;
            if (Prefs.PlayerHP < Prefs.OriginalHP)
            {
                Prefs.PlayerHP += heal;
                EnableHp(heal, "+hp");
                CanvasController.instance.UpdateHP();
            }
            if (Prefs.PlayerMP < Prefs.OriginalMP)
            {
                Prefs.PlayerMP += heal;
                EnableMp(heal, "+mp");
                CanvasController.instance.UpdateMP();
            }
        }
       
    }

    public void EnableHp(int hp, string s)
    {
        SetData(txtHpPlayer, s, txtHp, hp);
    }
    public void EnableMp(int mp, string s)
    {
        SetData(txtMpPlayer, s, txtMp, mp);
    }

    void SetData(GameObject obj, string s = null, TextMesh txt = null, int number = 0)// gan thong tin vao txt
    {
        if (txt != null && number != 0)
        {
            txt.text = s.Substring(0,1) + " " + number.ToString() + s.Substring(1);
        }
        obj.SetActive(true);
        obj.transform.DOLocalMoveY(1.6f, 2).SetSpeedBased().SetRelative(true).OnStepComplete(() =>
        {
            obj.transform.DOPause();
            obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 1.6f);
            obj.SetActive(false);
        });
    }

    public void EnableExp(int exp)//hien text exp mau xanh la
    {
        foreach (GameObject g in lstTxtExp)
        {
            if (g.activeSelf)
                continue;
            g.transform.position = transfTxtExp.position;
            SetData(g, "+exp", g.GetComponent<TextMesh>(), exp);
            return;
        }
        GameObject objExp = Instantiate(txtExpPlayer, transfTxtExp.position, Quaternion.identity, transfTxtExp.parent);
        SetData(objExp, "+exp", objExp.GetComponent<TextMesh>(), exp);
        lstTxtExp.Add(objExp);

    }

    public void EnableLvUp()
    {
        SetData(LvUpPlayer);
    }
    void CheckRaycast()//check duoi chan co phai ground k de thay doi animation
    {
        var hit = Physics2D.BoxCast(transform.position, new Vector2(myColli.bounds.size.x, 0.1f), 0, Vector2.zero, 1, groundLayer);
        if (hit.collider != null)
        {
            EffectPlayer.SetActive(true);
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

            EffectPlayer.SetActive(false);
        }
        myAnim.SetBool("grounded", grounded);
    }
    void SetIsUp(bool b)
    {
        myAnim.SetBool("isup", b);

    }

    void MovePlayer()//di chuyen nhan vat
    {
        //D= 1; A = -1
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        if (move == 0)
        {
            return;
        }
        EffectPlayer.SetActive(false);
        myRigid.velocity = new Vector2(move * speed, myRigid.velocity.y);


        if (move > 0 && mySpri.flipX || move < 0 && !mySpri.flipX)
        {
            mySpri.flipX = !mySpri.flipX;
        }

        Prefs.PosXPlayer = transform.position.x;
        Prefs.PosYPlayer = transform.position.y;
    }

    void Jump()// nhay
    {
        if (Input.GetAxisRaw("Vertical") == 1 && grounded == true)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpHeight);
        }
    }
    void Fire()// phong phi tieu tan cong
    {
        if (Input.GetMouseButtonDown(1) && Prefs.PlayerMP >= mpDesAtk)
        {
            Prefs.PlayerMP -= mpDesAtk;
            CanvasController.instance.UpdateMP();
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 1f);
            foreach (GameObject g in lstBullet)
            {
                if (g.activeSelf)
                    continue;
                g.transform.position = pos;
                g.SetActive(true);
                return;
            }
            GameObject b = Instantiate(bullet, pos, Quaternion.identity);
            lstBullet.Add(b);
        }
    }

    // physical
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundTrigger") && transform.position.y > collision.transform.position.y)//nhay xuyen 
        {
            collision.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GroundTrigger"))
        {
            collision.collider.isTrigger = true;
        }

    }

}
