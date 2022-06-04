using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Prefs
{
    public static int PlayerLV
    {
        get => PlayerPrefs.GetInt(GameConst.PlayerLv, 1);

        set => PlayerPrefs.SetInt(GameConst.PlayerLv, value);
    }

    public static string NamePlayer
    {
        get => PlayerPrefs.GetString(GameConst.NamePlayer);

        set => PlayerPrefs.SetString(GameConst.NamePlayer, value);
    }
    public static int PlayerHP
    {
        get => PlayerPrefs.GetInt(GameConst.PlayerHP, 1);

        set => PlayerPrefs.SetInt(GameConst.PlayerHP, value);
    }
    public static int OriginalHP
    {
        get => PlayerPrefs.GetInt(GameConst.OriginalHP, 10);

        set => PlayerPrefs.SetInt(GameConst.OriginalHP, value);
    }
    public static int PlayerMP
    {
        get => PlayerPrefs.GetInt(GameConst.PlayerMP, 1);

        set => PlayerPrefs.SetInt(GameConst.PlayerMP, value);
    }
    public static int OriginalMP
    {
        get => PlayerPrefs.GetInt(GameConst.OriginalMP, 10);

        set => PlayerPrefs.SetInt(GameConst.OriginalMP, value);
    }
    public static float PlayerExp
    {
        get => PlayerPrefs.GetFloat(GameConst.PlayerExp);

        set => PlayerPrefs.SetFloat(GameConst.PlayerExp, value);
    }
    public static float OriginalExp
    {
        get => PlayerPrefs.GetFloat(GameConst.OriginalExp, 15);

        set => PlayerPrefs.SetFloat(GameConst.OriginalExp, value);
    }
    public static int PlayerCoin
    {
        get => PlayerPrefs.GetInt(GameConst.PlayerCoin);

        set => PlayerPrefs.SetInt(GameConst.PlayerCoin, value);
    }
    public static int PlayerDamage
    {
        get => PlayerPrefs.GetInt(GameConst.PlayerDamage, 1);

        set => PlayerPrefs.SetInt(GameConst.PlayerDamage, value);
    }


    public static int ScenePlayer
    {
        get => PlayerPrefs.GetInt(GameConst.ScenePlayer, 1);

        set => PlayerPrefs.SetInt(GameConst.ScenePlayer, value);
    }

    public static float PosXPlayer
    {
        get => PlayerPrefs.GetFloat(GameConst.PosXPlayer, -18);

        set => PlayerPrefs.SetFloat(GameConst.PosXPlayer, value);
    }

    public static float PosYPlayer
    {
        get => PlayerPrefs.GetFloat(GameConst.PosYPlayer, 3);

        set => PlayerPrefs.SetFloat(GameConst.PosYPlayer, value);
    }
    public static int CurrentQuest
    {
        get => PlayerPrefs.GetInt(GameConst.CurrentQuest);

        set => PlayerPrefs.SetInt(GameConst.CurrentQuest, value);
    }
    public static int CurrentQuantity
    {
        get => PlayerPrefs.GetInt(GameConst.CurrentQuantity);

        set => PlayerPrefs.SetInt(GameConst.CurrentQuantity, value);
    }

    public static int NumberRequests
    {
        get => PlayerPrefs.GetInt(GameConst.NumberRequests, 1);

        set => PlayerPrefs.SetInt(GameConst.NumberRequests, value);
    }
}
