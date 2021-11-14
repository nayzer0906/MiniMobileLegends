using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

public class TeamColorMenu : MonoBehaviour
{
    private SkinnedMeshRenderer hoodieColor;
    private Button redBtn, greenBtn, blueBtn, yellowBtn;
    [SerializeField] private Image chosenColor;
    [SerializeField] private RectTransform allyBackground;
    [SerializeField] private TMP_Text chosenColorTxt;
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
        
        allyBackground.gameObject.SetActive(true);
    }

    private void Start()
    {
        redBtn.onClick.AddListener(() => SetHoodieColor(Color.red));
        greenBtn.onClick.AddListener(() => SetHoodieColor(Color.green));
        blueBtn.onClick.AddListener(() => SetHoodieColor(Color.blue));
        yellowBtn.onClick.AddListener(() => SetHoodieColor(Color.yellow));
    }

    private void SetHoodieColor(Color color)
    {
        hoodieColor.material.color = color;
    }

    public void OnClickEnemyColorMenu()
    {
        ShowChosenColor();
    }

    private async void ShowChosenColor()
    {
        chosenColor.gameObject.SetActive(true);
        
        string yourTeamTxt = "YOUR TEAM: ";
        if (hoodieColor.material.color == Color.blue)
        {
            chosenColorTxt.text = yourTeamTxt + "BLUE";
            chosenColor.color = Color.blue;
        }
        else if (hoodieColor.material.color == Color.red)
        {
            chosenColorTxt.text = yourTeamTxt + "RED";
            chosenColor.color = Color.red;
        }
        else if (hoodieColor.material.color == Color.green)
        {
            chosenColorTxt.text = yourTeamTxt + "GREEN";
            chosenColor.color = Color.green;
        }
        else
        {
            chosenColorTxt.text = yourTeamTxt + "YELLOW";
            chosenColor.color = Color.yellow;
        }
        await Task.Delay(1500);
        chosenColor.gameObject.SetActive(false);
        MenuManager.OpenMenu(Menu.EnemyColor, gameObject);
        allyBackground.gameObject.SetActive(false);
    }
}
