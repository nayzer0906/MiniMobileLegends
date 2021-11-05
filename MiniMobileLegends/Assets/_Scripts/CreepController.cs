using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepController : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
