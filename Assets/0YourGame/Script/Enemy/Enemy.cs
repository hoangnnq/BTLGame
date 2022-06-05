using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    int eHp;
    int eExp;
    float eTimeRevival;

    public int EHp { get => eHp; set => eHp = value; }
    public int EExp { get => eExp; set => eExp = value; }
    public float ETimeRevival { get => eTimeRevival; set => eTimeRevival = value; }

    protected virtual void Die(GameObject enemy)
    {
        if (Prefs.CurrentQuest == 2 && Prefs.PlayerLV >= 3)
        {
            goto endmethod;
        }
        Prefs.PlayerExp += eExp;
        CanvasController.instance.UpdateExp(eExp);

    endmethod:;
        enemy.SetActive(false);
        if (Prefs.ScenePlayer < 4)
        {
            DOVirtual.DelayedCall(eTimeRevival, () => { enemy.SetActive(true); });
        }
    } 

    public void OnDestroy()
    {
        transform.DOKill();
    }


}
