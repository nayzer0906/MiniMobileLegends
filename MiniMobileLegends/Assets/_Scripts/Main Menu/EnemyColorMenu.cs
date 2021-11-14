using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyColorMenu : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer hoodieColor;
    [SerializeField] private Image chosenColor;
    [SerializeField] private RectTransform enemyBackground;
    [SerializeField] private TMP_Text chosenColorTxt;
    [SerializeField] private GameObject map;
    [SerializeField] private RectTransform loadingScreen;
    private void OnEnable()
    {
        EnemyChoosing();
    }

    private async void EnemyChoosing()
    {
        enemyBackground.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            var rnd = Random.Range(1, 4);
            switch (rnd)
            {
                case 1: hoodieColor.material.color = Color.red;
                    break;
                case 2: hoodieColor.material.color = Color.green;
                    break;
                case 3: hoodieColor.material.color = Color.blue;
                    break;
                case 4: hoodieColor.material.color = Color.yellow;
                    break;
            }
            await Task.Delay(Random.Range(600, 1000));
        }
        ShowChosenColor();
    }
    
    private async void ShowChosenColor()
    {
        chosenColor.gameObject.SetActive(true);
        
        string yourTeamTxt = "ENEMY TEAM: ";
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
        this.gameObject.SetActive(false);
        chosenColor.gameObject.SetActive(false);
        enemyBackground.gameObject.SetActive(false);
        map.SetActive(false);
        loadingScreen.gameObject.SetActive(true);
    }
}
