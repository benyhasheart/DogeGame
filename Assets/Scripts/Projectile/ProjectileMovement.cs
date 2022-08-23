using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    
    protected void Bounds(Collider other)
    {

        if (other.tag == "Bullet Zone North" || other.tag == "Bullet Zone South")
        {
            Vector3 target = transform.forward;
            target.z = -target.z;
            transform.forward = target;
            projectileRigidbody.velocity = transform.forward * profileData.currentSpeed;
            return;
        }

        if (other.tag == "Bullet Zone West" || other.tag == "Bullet Zone Est")
        {
            Vector3 target = transform.forward;
            target.x = -target.x;
            transform.forward = target;
            projectileRigidbody.velocity = transform.forward * profileData.currentSpeed;
            return;
        }
    }
    protected ProjectileData profileData;
    protected Rigidbody projectileRigidbody;
}
