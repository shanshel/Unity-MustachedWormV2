using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatablePlaceDetector : MonoBehaviour
{
    public EatableMargin parentObject;
    bool isAlreadyDetected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isAlreadyDetected && other.gameObject.layer == 13)
        {
            isAlreadyDetected = true;
            parentObject._spCollider.enabled = false;
            parentObject._meshRenderer.enabled = false;
            parentObject.pointText.enabled = false;
            gameObject.SetActive(false);
        }
    }
  
}
