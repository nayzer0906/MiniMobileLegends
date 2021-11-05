using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject ringParticle;
    private PlayerMovement player;

    private void Start()
    {
        ringParticle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ringParticle.SetActive(true);
        //ShootIntruders(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ringParticle.SetActive(false);
    }

    private void ShootIntruders(Collider intruder)
    {
        Destroy(intruder.gameObject);
    }
}
