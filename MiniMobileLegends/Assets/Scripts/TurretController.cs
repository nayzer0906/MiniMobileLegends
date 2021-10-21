using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ShootIntruders(other);
    }

    private void ShootIntruders(Collider intruder)
    {
        Destroy(intruder.gameObject);
    }
}
