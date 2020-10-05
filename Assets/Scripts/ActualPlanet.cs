using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualPlanet : MonoBehaviour
{
    public string planetName = "Tomato";
    public PlanetFoliage[] foliage;

    
    private void Start()
    {
        UIManager.inst.setPlanetUIDetails(planetName);


        Invoke("createFoliages", 1f);


    }

    private void createFoliages()
    {
        Vector3 center = transform.position;

        for (int i = 0; i < foliage.Length; i++)
        {
            for (var x = 0; x < foliage[i].count; x++)
            {
                Vector3 pos = GameManager.inst.RandomCircle(center, .97f + foliage[i].offsetRad);
                Quaternion rot = Quaternion.FromToRotation(Vector3.down, center - pos);
                var spawnedObj = Instantiate(foliage[i].prefab, pos, rot, transform);

                if (foliage[i].isRandomScale)
                {
                    float scale = Random.Range(foliage[i].minScale, foliage[i].maxScale);

                    spawnedObj.transform.localScale = new Vector3(scale, scale, scale);
                }
            }
        }
    }

 
   
}
