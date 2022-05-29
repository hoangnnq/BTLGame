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
    // Start is called before the first frame update
    void Start()
    {
        txtHp.GetComponent<TextMesh>().text = hp + "/" + hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
