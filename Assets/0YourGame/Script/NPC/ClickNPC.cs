using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickNPC : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] Text txt;
    public void EnablePopup()
    {
        ChangePopup();
        if (Prefs.NumberRequests == 0)
        {
            txt.text = "Trời thật đẹp !";
            return;
        }
        if (Prefs.CurrentQuantity >= Prefs.NumberRequests || Prefs.CurrentQuest == 0)
        {
            //hoan thanh nvu
            txt.text = "Con đã hoàn thành nhiệm vụ!";
            DOVirtual.DelayedCall(0.8f, SetText);
            return;
        }
        else
        {
            txt.text = "Con hãy đi làm nhiệm vụ đi!";
            DOVirtual.DelayedCall(1f, ChangePopup);
        }
    }

    void SetText()
    {
        txt.text = "Hãy nhận phần thưởng của con!";
        Prefs.PlayerExp += 5;
        CanvasController.instance.UpdateExp(5);
        DOVirtual.DelayedCall(0.8f, QuestNew);
    }

    void QuestNew()
    {
        txt.text = "Và nhận nhiệm vụ mới!";
        Prefs.CurrentQuest++;
        Prefs.CurrentQuantity = 0;
        CanvasController.instance.EnableQuest(Questions.lstQuest[Prefs.CurrentQuest]);
        CanvasController.instance.UpdateQuest();
        DOVirtual.DelayedCall(1f, ChangePopup);
    }

    void ChangePopup()
    {
        popup.SetActive(!popup.activeInHierarchy);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
