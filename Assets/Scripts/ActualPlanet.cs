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
                float scale = spawnedObj.transform.localScale.x;
                if (foliage[i].isRandomScale)
                {
                    scale = Random.Range(foliage[i].minScale, foliage[i].maxScale);
                    spawnedObj.transform.localScale = new Vector3(scale, scale, scale);
                }

                if (foliage[i].isOnTopOfEachOther)
                {
                    var randOnTop = Random.Range(1, foliage[i].maxOnTop + 1);
                   
                    for (var m = 0; m < randOnTop; m++)
                    {
                        var onTopObject = Instantiate(foliage[i].prefab, Vector3.zero, rot, spawnedObj.transform);
                        onTopObject.transform.localScale /= scale;
                        onTopObject.transform.localPosition = new Vector3(0f, ((m +1) * foliage[i].onTopMargin), 0f);
                        var randomRotation = Random.Range(foliage[i].o_minRotation, foliage[i].o_maxRotation);
                        onTopObject.transform.Rotate(new Vector3(0f, randomRotation, 0f), Space.Self); 
                    }
                }
            }
        }
    }

 
   
}
