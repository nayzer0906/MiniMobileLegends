using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyChoosesColor : MonoBehaviour
{
    public Image[] colors = new Image[4];
    [SerializeField]
    private SkinnedMeshRenderer hoodieColor;
    [SerializeField]
    private TMP_Text chosenColorTxt;
    [SerializeField] 
    private Image teamColorChoicePnl;
    [SerializeField]
    private RectTransform loadingScreen;

    public GameObject enemyBackground;
    public GameObject enemyMesh;
    public GameObject enemyColorChoosePnl;
    public GameObject map;

    private void Start()
    {
        EnemyChooses();
    }

    async void EnemyChooses()
    {
        foreach (var color in colors)
        {
            hoodieColor.material.color = color.color;
            await Task.Delay(Random.Range(2000, 4000));
        }
        teamColorChoicePnl.gameObject.SetActive(true);
        OnTeamColorChosen();
    }
    
    private async void OnTeamColorChosen()
    {
        string yourTeamTxt = "ENEMY TEAM: ";
        teamColorChoicePnl.gameObject.SetActive(true);
        if (hoodieColor.material.color == Color.blue)
        {
            chosenColorTxt.text = yourTeamTxt + "BLUE";
            teamColorChoicePnl.color = Color.blue;
        }
        else if (hoodieColor.material.color == Color.red)
        {
            chosenColorTxt.text = yourTeamTxt + "RED";
            teamColorChoicePnl.color = Color.red;
        }
        else if (hoodieColor.material.color == Color.green)
        {
            chosenColorTxt.text = yourTeamTxt + "GREEN";
            teamColorChoicePnl.color = Color.green;
        }
        else
        {
            chosenColorTxt.text = yourTeamTxt + "YELLOW";
            teamColorChoicePnl.color = Color.yellow;
        }
        await Task.Delay(1500);
        teamColorChoicePnl.gameObject.SetActive(false);
        enemyBackground.SetActive(false);
        enemyMesh.SetActive(false);
        enemyColorChoosePnl.SetActive(false);
        map.SetActive(false);
        loadingScreen.gameObject.SetActive(true);
    }
}
