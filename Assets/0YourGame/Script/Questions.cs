using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Questions 
{
    public static List<KeyValuePair<int, KeyValuePair<int, string>>> lstQuest = new List<KeyValuePair<int, KeyValuePair<int, string>>>();

    //moinvu 5exp
    public static void AddListQuest()
    {
        AddQuest(lstQuest, 0, 1, "Hãy gặp trưởng làng và nói chuyện vs ông ấy!");
        AddQuest(lstQuest, 1, 3, "Collect");
        AddQuest(lstQuest, 2, 3, "Attack");
    }
    public static void AddQuest(List<KeyValuePair<int, KeyValuePair<int, string>>> lst,int cur, int number, string quest)
    {
        lst.Add(new KeyValuePair<int, KeyValuePair<int, string>> (cur, new KeyValuePair<int, string> (number, quest)));
    }

}
