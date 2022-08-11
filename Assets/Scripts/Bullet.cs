using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.OnDamage(1, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            return;
        }

        if (other.tag == "Bullet Zone North" || other.tag == "Bullet Zone South")
        {
            Vector3 target = transform.forward;
            target.z = -target.z;
            transform.forward = target;
            bulletRigidbody.velocity = transform.forward * speed;
            return;
        }

        if (other.tag == "Bullet Zone West" || other.tag == "Bullet Zone Est")
        {
            Vector3 target = transform.forward;
            target.x = -target.x;
            transform.forward = target;
            bulletRigidbody.velocity = transform.forward * speed;
            return;
        }        
    }

    public float speed;

    private Rigidbody bulletRigidbody;
    private BulletSpawner ownner;

    public BulletSpawner Ownner
    {
        set { ownner = value; }
        get { return ownner; }
    }

}
