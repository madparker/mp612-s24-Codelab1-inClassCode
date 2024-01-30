using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrizeScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //score goes up by 1
        GameManager.instance.score++;
        //prize relocates to random new location
        transform.position = new Vector3(
           Random.Range(-10,10),
           Random.Range(-10, 10)
        );
    }
}
