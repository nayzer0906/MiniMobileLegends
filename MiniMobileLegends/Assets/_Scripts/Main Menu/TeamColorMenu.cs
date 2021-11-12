using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamColorMenu : MonoBehaviour
{
    private SkinnedMeshRenderer hoodieColor;
    private Button redBtn, greenBtn, blueBtn, yellowBtn;
    private void OnEnable()
    {
        hoodieColor = GameObject.Find("Hoodie").GetComponent<SkinnedMeshRenderer>();
        hoodieColor.material.color = Color.blue;

        redBtn = GameObject.Find("RedBtn").GetComponent<Button>();
        greenBtn = GameObject.Find("GreenBtn").GetComponent<Button>();
        blueBtn = GameObject.Find("BlueBtn").GetComponent<Button>();
        yellowBtn = GameObject.Find("YellowBtn").GetComponent<Button>();
        
        redBtn.image.color = Color.red;
        greenBtn.image.color = Color.green;
        blueBtn.image.color = Color.blue;
        yellowBtn.image.color = Color.yellow;
    }

    private void Start()
    {
        
    }

    public void OnClickEnemyColorMenu()
    {
        MenuManager.OpenMenu(Menu.EnemyColor, gameObject);
    }
}
