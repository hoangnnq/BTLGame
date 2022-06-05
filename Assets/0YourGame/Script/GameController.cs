using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum music
{
    none, attack, loot, lvUp, hitEnemy
}

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public AudioSource backgroundSound;

    public GameObject player;
    public AudioSource audioPlayer;
    public AudioClip attackPlayer;
    public AudioClip lootPlayer;
    public AudioClip lvUpPlayer;

    public GameObject bullet;
    public GameObject bulletEnemy;
    public AudioSource audioEnemy;
    public AudioClip hitEnemy;

    public LayerMask itemLayer;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        UpdateSound();
    }

    public void EnableAudio(music a)
    {
        switch (a)
        {
            case music.none:
                break;
            case music.attack:
                audioPlayer.clip = attackPlayer;
                audioPlayer.Play();
                break;
            case music.loot:
                audioPlayer.clip = lootPlayer;
                audioPlayer.Play();
                break;
            case music.lvUp:
                audioPlayer.clip = lvUpPlayer;
                audioPlayer.Play();
                break;
            case music.hitEnemy:
                audioEnemy.clip = hitEnemy;
                audioEnemy.Play();
                break;
            default:
                break;
        }
    } 

    public void UpdateSound()
    {
        backgroundSound.volume = Prefs.BackgroundSound;
        audioPlayer.volume = Prefs.EffectSound;
        audioEnemy.volume = Prefs.EffectSound;
    } 

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CheckMouseClick();
        }
    }

    void CheckMouseClick()
    {
        Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(posMouse, Vector2.zero, 1, itemLayer);
        if (hit.collider == null)
        {
            return;
        }
        if (hit.collider.CompareTag("Coin"))
        {
            int randomCoin = Random.Range(1, 3);
            Prefs.PlayerCoin += randomCoin;
            CanvasController.instance.UpdateCoin();
        }
        else if (hit.collider.name.Contains("itemSnail") && Prefs.CurrentQuest == 2 && Prefs.CurrentQuantity < Prefs.NumberRequests)
        {
            Prefs.CurrentQuantity++;
            CanvasController.instance.UpdateQuest();
        }
        else if (hit.collider.name.Contains("itemSnake") && Prefs.CurrentQuest == 3 && Prefs.CurrentQuantity < Prefs.NumberRequests)
        {
            Prefs.CurrentQuantity++;
            CanvasController.instance.UpdateQuest();
        }
        else if (hit.collider.name.Contains("itemBat") && Prefs.CurrentQuest == 4 && Prefs.CurrentQuantity < Prefs.NumberRequests)
        {
            Prefs.CurrentQuantity++;
            CanvasController.instance.UpdateQuest();
        }
        EnableAudio(music.loot);
        hit.collider.gameObject.SetActive(false);

    }
}
