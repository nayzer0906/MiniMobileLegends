using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 5f * Time.deltaTime, 0, Space.Self);
    }
}
