using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyShield : BaseShield
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float AdjustDamage(float damage)
    {
        Camera.main.backgroundColor = Random.ColorHSV();
        return base.AdjustDamage(damage);
    }
}
