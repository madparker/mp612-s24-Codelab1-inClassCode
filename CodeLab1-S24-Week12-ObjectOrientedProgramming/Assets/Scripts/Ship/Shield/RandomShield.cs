using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShield : BaseShield
{
    public override float AdjustDamage(float damage)
    {
        transform.localScale = new Vector3(
            Random.Range(0.25f, 1f),
            Random.Range(0.25f, 1f),
            Random.Range(0.25f, 1f));
        return Random.Range(0, damage);
    }
}
