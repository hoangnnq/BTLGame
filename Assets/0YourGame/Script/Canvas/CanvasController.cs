using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    public List<Text> txtLv;
    public Slider hp;
    public Text txtHP;
    public Slider mp;
    public Text txtMP;
    public Slider exp;
    public Text txtEXP;
    public Text txtQuestBag;

    public GameObject objQuest;
    public Text txtQuest;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLv();
        UpdateHP();
        UpdateMP();
        UpdateExp();
        UpdateQuest();
        if (Prefs.CurrentQuest == 0 && Prefs.ScenePlayer == 1)
        {
            EnableQuest(Questions.lstQuest[0]);
        }
    }
    public void UpdateLv()
    {
        foreach (Text item in txtLv)
        {
            item.text = "Lv: " + Prefs.PlayerLV;
        }        
    }

    public void UpdateHP()
    {
        hp.value = Prefs.PlayerHP;
        hp.maxValue = Prefs.OriginalHP;
        txtHP.text = "HP: " + Prefs.PlayerHP + "/" + Prefs.OriginalHP;
    }
    public void UpdateMP()
    {
        mp.value = Prefs.PlayerMP;
        mp.maxValue = Prefs.OriginalMP;
        txtMP.text = "MP: " + Prefs.PlayerMP + "/" + Prefs.OriginalMP;
    }
    public void UpdateExp(string numberExp = null)
    {
        exp.value = Prefs.PlayerExp;
        exp.maxValue = Prefs.OriginalExp;
        if (numberExp != null)
        {
            PlayerController.instance.EnableExp(numberExp);
        }
        txtEXP.text = "EXP: " + Prefs.PlayerExp + "/" + Prefs.OriginalExp;
    }

    public void UpdateQuest()
    {
        txtQuestBag.text = "Nhiệm vụ của bạn: " + Questions.lstQuest[Prefs.CurrentQuest].Value.Value +
            "(" + Prefs.CurrentQuantity + "/" + Prefs.NumberRequests + ")";
    }

    public void EnableQuest(KeyValuePair<int, KeyValuePair<int, string>> q)
    {
        objQuest.SetActive(true);
        txtQuest.text = "Nhiệm vụ " + (q.Key + 1) + ":" + q.Value.Value;
    }
}
