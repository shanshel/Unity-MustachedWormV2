using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumsData;

public class DeathDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.inst.isGameStarted || 
            GameManager.inst.isLevelingUp ||
            GameManager.inst.isInProtection ||
            GameManager.inst.isPlayerDied
            )
            return;


        GameManager.inst.isAboutToDie = true;

        if (GameManager.inst.numberOfRespawn >= 2)
        {
            UnityAdsShan.inst.setPlayerDeciction(WatchAdOption.NoPlayerNotInterested);
            GameManager.inst.deathCheckBasedonAds();
        }
        else
        {
            UIManager.inst.showAdsPanel();
        }
        
    }
}
