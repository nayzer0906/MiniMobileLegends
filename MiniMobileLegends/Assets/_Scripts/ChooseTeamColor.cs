using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTeamColor : MonoBehaviour
{
    [SerializeField]
    private List<Button> colors = new List<Button>();
    [SerializeField]
    private SkinnedMeshRenderer hoodieColor;

    private void ChangeHoodieColor(int color)
    {
        switch (color)
        {
            case 0:
                hoodieColor.material.color = Color.red;
                break;
            case 1:
                hoodieColor.material.color = Color.green;
                break;
            case 2:
                hoodieColor.material.color = Color.blue;
                break;
            case 3:
                hoodieColor.material.color = Color.yellow;
                break;
        }
    }

    public void Start()
    {
        foreach (var color in colors)
        {
            color.onClick.AddListener(() => ChangeHoodieColor(colors.IndexOf(color)));
        }
    }
}
