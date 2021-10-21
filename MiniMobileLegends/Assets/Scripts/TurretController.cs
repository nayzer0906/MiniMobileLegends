using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject ring_particle;

    private void Start()
    {
        ring_particle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ShootIntruders(other);
    }

    private void ShootIntruders(Collider intruder)
    {
        ring_particle.SetActive(true);
        Destroy(intruder.gameObject);
    }
}
