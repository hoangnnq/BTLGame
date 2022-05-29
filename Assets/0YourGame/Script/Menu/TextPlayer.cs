using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextPlayer : MonoBehaviour
{

    public void GetName()
    {
        Text placeHolder = MenuController.instance.placeHolderName;
        Text inputName = MenuController.instance.inputName;
        if(inputName.text != "")
        {
            PlayerPrefs.DeleteAll();
            Prefs.NamePlayer = inputName.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            if (placeHolder != null)
            {
                placeHolder.text = "You haven't named!";
            }
        }
    }
}
