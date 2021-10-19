using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ApplicationStart : MonoBehaviour
{
    public Transform monster_turtle;
    public Transform monster_lord;
    public Transform monster_lizard;
    public Transform monster_crab;
    public Transform monster_slime;
    void Start()
    {
        StartCoroutine(TurtleSpawn());
        StartCoroutine(LizardSpawn());
        StartCoroutine(CrabSpawn());
        StartCoroutine(SlimeSpawn());
    }

    IEnumerator TurtleSpawn()
    {
        yield return new WaitForSeconds(15f);
        Debug.Log("15 seconds passed...");
        Instantiate(monster_turtle, new Vector3(40f, monster_turtle.position.y, 40f), Quaternion.identity);
        Instantiate(monster_turtle, new Vector3(-40f, monster_turtle.position.y, -40f), Quaternion.identity);
    }
    
    IEnumerator LizardSpawn()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("10 seconds passed...");
        Instantiate(monster_lizard, new Vector3(15f, monster_lizard.position.y, -55f), Quaternion.identity);
        Instantiate(monster_lizard, new Vector3(-15f, monster_lizard.position.y, 55f), Quaternion.identity);
    }
    
    IEnumerator CrabSpawn()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("6 seconds passed...");
        Instantiate(monster_crab, new Vector3(15f, monster_crab.position.y, 15f), Quaternion.identity);
        Instantiate(monster_crab, new Vector3(-15f, monster_crab.position.y, -15f), Quaternion.identity);
    }
    
    IEnumerator SlimeSpawn()
    {
        yield return new WaitForSeconds(8f);
        Debug.Log("8 seconds passed...");
        Instantiate(monster_slime, new Vector3(55f, monster_slime.position.y, 5f), Quaternion.identity);
        Instantiate(monster_slime, new Vector3(-55f, monster_slime.position.y, -5f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
