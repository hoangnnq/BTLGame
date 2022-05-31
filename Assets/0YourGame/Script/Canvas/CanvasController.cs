using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    public List<Text> txtLv;
    public Text txtNamePlayer;
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
        txtNamePlayer.text = "Name: " + Prefs.NamePlayer;
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
        hp.maxValue = Prefs.OriginalHP;
        hp.value = Prefs.PlayerHP;
        txtHP.text = "HP: " + Prefs.PlayerHP + "/" + Prefs.OriginalHP;
    }
    public void UpdateMP()
    {
        mp.maxValue = Prefs.OriginalMP;
        mp.value = Prefs.PlayerMP;
        txtMP.text = "MP: " + Prefs.PlayerMP + "/" + Prefs.OriginalMP;
    }
    public void UpdateExp(string numberExp = null)
    {
        if (numberExp != null)
        {
            PlayerController.instance.EnableExp(numberExp);
        }
        if (Prefs.PlayerExp >= Prefs.OriginalExp)
        {
            Prefs.PlayerLV++;
            Prefs.PlayerExp -= Prefs.OriginalExp;
            Prefs.OriginalExp += 10;
            Prefs.OriginalHP += 5;
            UpdateLv();
            UpdateHP();
        }
        exp.maxValue = Prefs.OriginalExp;
        exp.value = Prefs.PlayerExp;
        txtEXP.text = "EXP: " + Prefs.PlayerExp + "/" + Prefs.OriginalExp;
    }

    public void UpdateQuest()
    {
        Prefs.NumberRequests = Questions.lstQuest[Prefs.CurrentQuest].Value.Key;
        txtQuestBag.text = "Nhiệm vụ của bạn: " + Questions.lstQuest[Prefs.CurrentQuest].Value.Value +
            "(" + Prefs.CurrentQuantity + "/" + Prefs.NumberRequests + ")";
    }

    public void EnableQuest(KeyValuePair<int, KeyValuePair<int, string>> q)
    {
        objQuest.SetActive(true);
        txtQuest.text = "Nhiệm vụ " + (q.Key + 1) + ":" + q.Value.Value;
    }
}
