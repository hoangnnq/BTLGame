using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackBoss : MonoBehaviour
{
    public static CheckAttackBoss instance;

    public int childKey;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        childKey = Random.Range(0, transform.childCount);
    }

    public bool CheckDie()
    {
        if (!transform.GetChild(childKey).gameObject.activeInHierarchy)
        {
            return true;
        }
        return false;
    }
}
