using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleAttack : BaseAttack
{
    public override void Attack()
    {
        base.Attack();

        Vector2 sidePos = transform.position;
        sidePos.y += 1;
        sidePos.x -= 1;
        
        SpawnBullet(sidePos);
        
        sidePos.x += 2;
        SpawnBullet(sidePos);
    }
}
