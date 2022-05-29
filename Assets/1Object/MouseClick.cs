using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    //[SerializeField] GameObject popup;
    //float time = 0;
    //GameObject popupComplete;
    //private void Start()
    //{
    //    popupComplete = GameController.Instance.popupCompleteQuest;
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    //chuyển đổi tọa độ trên màn hình sang tọa độ unity
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastMouseClick(mousePos);
    //    if(popup.activeInHierarchy == true || popupComplete.activeInHierarchy == true)
    //    {
    //        time += Time.deltaTime;
    //        if(time > 2)
    //        {
    //            popup.SetActive(false);
    //            popupComplete.SetActive(false);
    //        }
    //    }
    //}

    //void RaycastMouseClick(Vector3 mousePos)
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        time = 0;
    //        //Vector3 clickDir = Camera.main.transform.position - mousePos;
    //        Vector3 clickDir = new Vector3(0,0,1);
    //        clickDir.Normalize();//lược giản vecto

    //        RaycastHit2D hit = Physics2D.Raycast(mousePos, clickDir);
    //        Debug.DrawRay(mousePos, clickDir, Color.green);
    //        if (hit.collider == null || hit.collider.tag != "NPC")
    //        {
    //            return;
    //        }
    //        if(Prefs.CompleteQuest == 0)
    //        {
    //            popup.SetActive(true);
    //        }
    //        else
    //        {
    //            //hoan thanh nvu
    //            popupComplete.SetActive(true);
    //            Prefs.QuestNow++;
    //            Prefs.CompleteQuest = 0;
    //        }

    //    }
    //}
}
