using DG.Tweening;
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

    public AudioSource audioMenu;

    public Slider backgroundSound;
    public Slider effectSound;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundSound.value = Prefs.BackgroundSound;
        effectSound.value = Prefs.EffectSound;
        if (Prefs.NamePlayer != "")
        {
            btnResume.SetActive(true);
        }
        else
        {
            btnResume.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void SetAudio(float volume)
    {
        audioMenu.volume = volume;
    }

}
