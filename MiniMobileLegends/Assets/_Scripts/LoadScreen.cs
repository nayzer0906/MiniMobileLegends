using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    private Slider slider;
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        StartCoroutine(ProgressBar());
    }
    
    IEnumerator ProgressBar()
    {
        while (slider.value < slider.maxValue)
        {
            slider.value += 0.2f;
            yield return new WaitForSeconds(0.3f);
            if (slider.value >= slider.maxValue)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
}
