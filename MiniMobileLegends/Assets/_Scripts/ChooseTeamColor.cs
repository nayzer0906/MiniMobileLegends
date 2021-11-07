using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTeamColor : MonoBehaviour
{
    private SkinnedMeshRenderer hoodieColor;

    private void OnEnable()
    {
        hoodieColor = GetComponent<SkinnedMeshRenderer>();
    }

    private void Awake()
    {
        
    }
}
