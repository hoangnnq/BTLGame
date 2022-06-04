using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletEnemy;

    public LayerMask itemLayer;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        hit.collider.gameObject.SetActive(false);

    }
}
