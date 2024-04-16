using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageShield : BaseShield
{
    public override float AdjustDamage(float damage)
    {
        return damage/2f;
    }
}
