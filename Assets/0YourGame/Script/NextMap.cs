using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMap : MonoBehaviour
{
    public int scene;
    public float posX;
    public float posY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Prefs.ScenePlayer = scene;
            Prefs.PosXPlayer = posX;
            Prefs.PosYPlayer = posY;
            SceneManager.LoadScene(scene);
        }
    }
}
