using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickNPC : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] GameObject popup;
    [SerializeField] Text txt;
    public void EnablePopup()
    {
        ChangePopup();
        if (Prefs.CurrentQuantity >= Prefs.NumberRequests || Prefs.CurrentQuest == 0)
        {
            //hoan thanh nvu
            txt.text = "Con đã hoàn thành nhiệm vụ!";
            Prefs.CurrentQuest++;
            Prefs.CurrentQuantity = 0;
            DOVirtual.DelayedCall(1f, SetText);
            return;
        }
        else
        {
            txt.text = "Con hãy đi làm nhiệm vụ đi!";
        }
    }

    void SetText()
    {
        txt.text = "Hãy nhận phần thưởng của con!";
        Prefs.PlayerExp += 5;
        CanvasController.instance.UpdateExp("5");
        DOVirtual.DelayedCall(1f, QuestNew);
    }

    void QuestNew()
    {
        txt.text = "Và nhận nhiệm vụ mới!";
        CanvasController.instance.EnableQuest(Questions.lstQuest[Prefs.CurrentQuest]);
        CanvasController.instance.UpdateQuest();
        DOVirtual.DelayedCall(1f, ChangePopup);
    }

    void ChangePopup()
    {
        popup.SetActive(!popup.activeInHierarchy);
    }
}
