using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public Text placeHolderName;
    public Text inputName;
    public GameObject btnResume;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Prefs.NamePlayer != "")
        {
            btnResume.SetActive(true);
        }
        else
        {
            btnResume.SetActive(false);
        }
    }

}
