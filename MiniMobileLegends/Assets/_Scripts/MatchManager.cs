using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public PlayerController playerController;
    private void Start()
    {
        playerController.Init();
        StartMatch();
    }
    public void StartMatch()
    {
        playerController.SpawnPlayer();
    }
}
