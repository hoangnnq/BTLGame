using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
    public void SetBackgroundSound(float val)
    {
        Prefs.BackgroundSound = val;
        MenuController.instance.SetAudio(val);
    }
    public void SetEffectSound(float val)
    {
        Prefs.EffectSound = val;
    }

    public void TeleportPlayer()
    {
        if (Prefs.ScenePlayer != 1 )
        {
            Prefs.PosXPlayer = -18;
            Prefs.PosYPlayer = 3;
            Prefs.ScenePlayer = 1;
            LoadIndexScene(1);

        }
    }

    public void LoadPlayer()
    {
        SceneManager.LoadScene(Prefs.ScenePlayer);
    }

    public void LoadIndexScene(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }
    public void VisiableUI(GameObject gameobj)
    {
        gameobj.SetActive(!gameobj.activeInHierarchy);
    }
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
