using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawnProjectile : GameEventNode
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ExecuteEvent() 
    {


       EndEvent();
    }


    [SerializeField]
    Projectile spawnPrefab;

}
