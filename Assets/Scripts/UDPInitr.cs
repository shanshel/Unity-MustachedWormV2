using UnityEngine;
using UnityEngine.UDP;

public class UDPInitr : IInitListener
{
    public void OnInitialized(UserInfo userInfo)
    {
        // You can call the QueryInventory method here
        // to check whether there are purchases that haven’t be consumed.    
    }

    public void OnInitializeFailed(string message)
    {
    }
}