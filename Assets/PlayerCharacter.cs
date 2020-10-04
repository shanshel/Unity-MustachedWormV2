using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    [SerializeField]
    private GameObject head;
    [SerializeField]
    private BodyPiece bodyPiecePrefab;
    [SerializeField]
    private int startWith = 3;
    private List<BodyPiece> bodyPartList = new List<BodyPiece>();

    [SerializeField]
    float minDistance = .012f;
    [SerializeField]
    float commonSpeed = 1f;
    [SerializeField]
    float minDistanceBetweenPieces = .5f;
    // Start is called before the first frame update
    void Start()
    {
        for (var x = 0; x < startWith; x++){
            var go = Instantiate(bodyPiecePrefab, transform);
            go.index = x;
            bodyPartList.Add(go);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {


        foreach (var bodyPart in bodyPartList)
        {
            
            if (bodyPart.index == 0)
            {
                float distanceToHead = Vector3.Distance(head.transform.position, bodyPart.transform.position);
                float headTimeCal = Time.smoothDeltaTime * distanceToHead / minDistance * commonSpeed;


                if (distanceToHead < minDistanceBetweenPieces)
                {
                    headTimeCal /= 100f;
                }

                if (headTimeCal > .5f)
                {
                    headTimeCal = .5f;
                }

                bodyPart.transform.position = Vector3.Slerp(bodyPart.transform.position, head.transform.position, headTimeCal);
            }
            else
            {
                var objectToFollow = bodyPartList[bodyPart.index - 1];

                float distanceToTarget = Vector3.Distance(objectToFollow.transform.position, bodyPart.transform.position);
              


                float headTimeCal = Time.smoothDeltaTime * distanceToTarget / minDistance * commonSpeed;
                if (distanceToTarget < minDistanceBetweenPieces)
                {
                    headTimeCal /= 100f;
                }
                if (headTimeCal > .5f)
                {
                    headTimeCal = .5f;
                }

                bodyPart.transform.position = Vector3.Slerp(bodyPart.transform.position, objectToFollow.transform.position, headTimeCal);




            }
        }
       
    }
}
