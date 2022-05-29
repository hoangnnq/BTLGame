using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Prefs.NamePlayer != "")
        {
            GetComponentInChildren<TextMesh>().text = Prefs.NamePlayer;
            transform.position = new Vector2(Prefs.PosXPlayer, Prefs.PosYPlayer);
        }
    }
}
