using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;

    public LocationScriptableObject currentLocation;
    
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
}
