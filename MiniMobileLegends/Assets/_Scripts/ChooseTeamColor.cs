using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTeamColor : MonoBehaviour
{
    [SerializeField]
    private List<Button> colors = new List<Button>();
    [SerializeField]
    private SkinnedMeshRenderer hoodieColor;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private TMP_Text chosenColorTxt;
    [SerializeField] 
    private Image teamColorChoicePnl;

    private EnemyChoosesColor _enemyChoosesColor;
    [SerializeField]
    //private Sprite xSprite;

    private void OnEnable()
    {
        hoodieColor.material.color = Color.blue;
        _enemyChoosesColor = new EnemyChoosesColor();
    }

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

    private async void OnTeamColorChosen()
    {
        string yourTeamTxt = "YOUR TEAM: ";
        teamColorChoicePnl.gameObject.SetActive(true);
        if (hoodieColor.material.color == Color.blue)
        {
            chosenColorTxt.text = yourTeamTxt + "BLUE";
            teamColorChoicePnl.color = Color.blue;
            //_enemyChoosesColor.colors[2].sprite = xSprite;
        }
        else if (hoodieColor.material.color == Color.red)
        {
            chosenColorTxt.text = yourTeamTxt + "RED";
            teamColorChoicePnl.color = Color.red;
            //_enemyChoosesColor.colors[0].sprite = xSprite;
        }
        else if (hoodieColor.material.color == Color.green)
        {
            chosenColorTxt.text = yourTeamTxt + "GREEN";
            teamColorChoicePnl.color = Color.green;
            //_enemyChoosesColor.colors[1].sprite = xSprite;
        }
        else
        {
            chosenColorTxt.text = yourTeamTxt + "YELLOW";
            teamColorChoicePnl.color = Color.yellow;
            //_enemyChoosesColor.colors[3].sprite = xSprite;
        }
        await Task.Delay(1500);
        teamColorChoicePnl.gameObject.SetActive(false);
    }

    public void Start()
    {
        foreach (var color in colors)
        {
            color.onClick.AddListener(() => ChangeHoodieColor(colors.IndexOf(color)));
        }
        
        confirmButton.onClick.AddListener(OnTeamColorChosen);
    }
}
