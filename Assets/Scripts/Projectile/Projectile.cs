using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IFireable
{
    private void Start()
    {
        
    }

    public void Fire()
    {
        transform.LookAt(targetTransform);
    }

    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
    }



    public ProjectileData profileData;
    private Transform targetTransform;
}
