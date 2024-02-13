using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("You whacked a Dot!!!");

        transform.position = new Vector2(
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f)
            );

        GameManager.instance.Score++;
    }
}
