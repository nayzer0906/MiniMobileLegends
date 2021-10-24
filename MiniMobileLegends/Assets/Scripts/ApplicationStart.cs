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
    public Transform creep_ally;
    public Transform creep_enemy;
    void Start()
    {
        StartCoroutine(TurtleSpawn());
        StartCoroutine(LizardSpawn());
        StartCoroutine(CrabSpawn());
        StartCoroutine(SlimeSpawn());
        StartCoroutine(CreepSpawn());
    }
    
    IEnumerator CreepSpawn()
    {
        yield return new WaitForSeconds(12f);
        Debug.Log("12 seconds passed...");
        Instantiate(creep_ally, new Vector3(-75f, creep_ally.position.y, -75f), new Quaternion(0f, 40f, 0f, 0f));
        Instantiate(creep_ally, new Vector3(-65f, creep_ally.position.y, -85f), new Quaternion(0f, 90f, 0f, 0f));
        Instantiate(creep_ally, new Vector3(-85f, creep_ally.position.y, -65f), new Quaternion(0f, 0f, 0f, 0f));
        
        Instantiate(creep_enemy, new Vector3(75f, creep_enemy.position.y, 75f), new Quaternion(0f, -140f, 0f, 0f));
        Instantiate(creep_enemy, new Vector3(65f, creep_enemy.position.y, 85f), new Quaternion(0f, -90f, 0f, 0f));
        Instantiate(creep_enemy, new Vector3(85f, creep_enemy.position.y, 65f), new Quaternion(0f, -180f, 0f, 0f));
    }

    IEnumerator TurtleSpawn()
    {
        yield return new WaitForSeconds(15f);
        Debug.Log("15 seconds passed...");
        Instantiate(monster_turtle, new Vector3(-40f, monster_turtle.position.y, 40f), Quaternion.identity);
        Instantiate(monster_turtle, new Vector3(40f, monster_turtle.position.y, -40f), Quaternion.identity);
    }
    
    IEnumerator LizardSpawn()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("10 seconds passed...");
        Instantiate(monster_lizard, new Vector3(-5f, monster_lizard.position.y, 55f), Quaternion.identity);
        Instantiate(monster_lizard, new Vector3(5f, monster_lizard.position.y, -55f), Quaternion.identity);
    }
    
    IEnumerator CrabSpawn()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("6 seconds passed...");
        Instantiate(monster_crab, new Vector3(-15f, monster_crab.position.y, 15f), Quaternion.identity);
        Instantiate(monster_crab, new Vector3(15f, monster_crab.position.y, -15f), Quaternion.identity);
    }
    
    IEnumerator SlimeSpawn()
    {
        yield return new WaitForSeconds(8f);
        Debug.Log("8 seconds passed...");
        Instantiate(monster_slime, new Vector3(-55f, monster_slime.position.y, -15f), Quaternion.identity);
        Instantiate(monster_slime, new Vector3(55f, monster_slime.position.y, 15f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
