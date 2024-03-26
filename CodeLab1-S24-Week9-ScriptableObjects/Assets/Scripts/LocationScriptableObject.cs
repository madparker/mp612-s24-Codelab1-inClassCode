using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
    (
        fileName = "New Location",
        menuName = "New Location",
        order = 0)
]

public class LocationScriptableObject : ScriptableObject
{
    public string locationName;
    public string locationDesc;

    public LocationScriptableObject north;
    
    public void PrintLocation()
    {
        string printStr =
            "\nLocation Name: " + locationName +
            "\nLocation Description: " + locationDesc;
        
        Debug.Log(printStr);
    }

    public void UpdateCurrentLocation(GameManager gm)
    {
        gm.titleUI.text = locationName;
        gm.descriptionUI.text = locationDesc;
    }
}
