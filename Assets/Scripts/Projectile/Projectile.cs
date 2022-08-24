using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IFireable
{
    private void Start()
    {
        
    }

    virtual public void Fire()
    {
        transform.LookAt(targetTransform);
    }

    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
    }



    public ProjectileData profileData;
    protected Transform targetTransform;
}
