using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    Quaternion rotation;
    private void Start()
    {
        rotation = transform.localRotation;
    }
    void Update()
    {

        transform.localRotation = rotation;
    }
}
