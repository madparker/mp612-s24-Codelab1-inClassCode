using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireShield : BaseShield
{
    // Start is called before the first frame update
    void Start()
    {
        shieldStrength = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float AdjustDamage(float damage)
    {
        shieldStrength--;

        if (shieldStrength > 0)
        {
            return -damage;
        }
        else
        {
            return damage;
        }
    }
}
