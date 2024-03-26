using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;

    public LocationScriptableObject currentLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonWest;
    public Button buttonEast;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDir(string dirChar)
    {
        switch (dirChar)
        {
           case "N":
               currentLocation = currentLocation.north;
               break;
           case "S":
               currentLocation = currentLocation.south;
               break;
           case "W":
               currentLocation = currentLocation.west;
               break;
           case "E":
               currentLocation = currentLocation.east;
               break;
          default:
              Debug.Log("WTF? That's a valid dir");
              break;
        }
        
        currentLocation.UpdateCurrentLocation(this);
    }
}
