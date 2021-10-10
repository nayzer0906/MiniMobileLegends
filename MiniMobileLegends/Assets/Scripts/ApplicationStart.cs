using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationStart : MonoBehaviour
{
    [SerializeField] private Transform[] environment = new Transform[3];
    private void Awake()
    {
        var map = Instantiate(environment[0], transform.position, Quaternion.identity);
        var castleAlly = Instantiate(environment[1], new Vector3(-63f, 0f, -63f), Quaternion.identity);
        var castleEnemy = Instantiate(environment[2], new Vector3(63f, 0f, 63f), Quaternion.identity);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
