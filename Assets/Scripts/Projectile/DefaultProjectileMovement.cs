using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectileMovement : ProjectileMovement
{
    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
        profileData = GetComponent<Projectile>().profileData;
        projectileRigidbody.velocity = transform.forward * profileData.currentSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.OnDamage(profileData.damage, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            return;
        }

        Bounds(other);
    }

}
