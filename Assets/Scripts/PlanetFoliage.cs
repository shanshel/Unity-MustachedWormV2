using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetFoliage
{
    public int count;

    public bool isRandomScale;
    [Range(0.01f, 3f)]
    public float minScale = 1f, maxScale = 1f;

    public GameObject prefab;
    public float offsetRad = 0f;

    public bool isOnTopOfEachOther = false;
    public int maxOnTop = 3;
    public float onTopMargin;
    public float o_minRotation = 0f, o_maxRotation = 80f;

}
