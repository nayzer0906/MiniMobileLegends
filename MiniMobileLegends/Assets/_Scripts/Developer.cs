using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Developer
{
    [MenuItem("Developer/Clear Saves")]

    public static void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All saves have been cleared.");
    }
}
