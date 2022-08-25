using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    override public void Fire()
    {
        base.Fire();

        Vector3 position = transform.position;
        position.y = startHeight;

        transform.position = position;
        

    }

    [SerializeField]
    private float startHeight;
}
