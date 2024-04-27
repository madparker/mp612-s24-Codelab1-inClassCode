using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public bool isPlaced = false;
    public int type;
    
    void Update()
    {
        if (!isPlaced)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePos);

            newPosition.x = Mathf.Round(newPosition.x);
            newPosition.y = Mathf.Round(newPosition.y);

            transform.position = newPosition;

            if (Input.GetMouseButtonUp(0))
            {
                isPlaced = true;
                LevelManager.instance.PlaceTile(gameObject);
            }
        }
    }
}
