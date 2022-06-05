using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Questions 
{
    public static List<KeyValuePair<int, KeyValuePair<int, string>>> lstQuest = new List<KeyValuePair<int, KeyValuePair<int, string>>>();


    //moinvu 5exp
    public static void AddListQuest()
    {
        //list, quest thu bn, so luong can dat dc, thong tin nvu
        AddQuest(lstQuest, 0, 1, "Hãy gặp trưởng làng và nói chuyện vs ông ấy!");
        AddQuest(lstQuest, 1, 3, "Đánh 3 con mộc nhân!");
        AddQuest(lstQuest, 2, 3, "Nhặt 3 vỏ ốc sên!");
        AddQuest(lstQuest, 3, 3, "Nhặt 3 da rắn!");
        AddQuest(lstQuest, 4, 3, "Nhặt 3 xác dơi!");
        AddQuest(lstQuest, 5, 1, "Giết boss và trả tự do cho ngôi làng!");
        AddQuest(lstQuest, 6, 0, "Con đã trưởng thành rồi, hãy đi theo hướng con đường của con!");
    }
    public static void AddQuest(List<KeyValuePair<int, KeyValuePair<int, string>>> lst,int cur, int number, string quest)
    {
        lst.Add(new KeyValuePair<int, KeyValuePair<int, string>> (cur, new KeyValuePair<int, string> (number, quest)));
    }

}
