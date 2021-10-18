using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ApplicationStart : MonoBehaviour
{
    [SerializeField] private Transform turtle_monster;
    void Start()
    {
        StartCoroutine(MonsterSpawn());
    }

    IEnumerator MonsterSpawn()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("10 seconds passed...");
        Instantiate(turtle_monster, new Vector3(40f, turtle_monster.position.y, 40f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
