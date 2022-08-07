using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        for (int i = 0; i < SpawnedBulletCounts; i++)
        {
            SpawnBullet();          
        }
    }

    // Update is called once per frame
    void Update()
    {

        //timeAfterSpawn += Time.deltaTime;

        //if ( timeAfterSpawn >= spawnRate)
        //{
        //    GameObject bullet = 
        //    Instantiate(bulletPrefab, transform.position,transform.rotation);

        //    bullet.transform.LookAt(target);

        //    timeAfterSpawn = 0.0f;
        //    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //}
    }

    
    public void SpawnBullet()
    {

        Bullet bullet =
           Instantiate<Bullet>(bulletPrefab, transform.position, transform.rotation);

        bullet.Ownner = this;

        Vector3 forward;
        forward = bullet.transform.forward;
        forward.x = Random.Range(-1.0f, 1.0f);
        bullet.transform.forward = forward;

        GameManager.GameManagerInstance.addBulletCount();
    }


    public Vector3 GetRePosition()
    {
        return transform.position;
    }

    public Transform Target
    {
        get { return target; }
    }

    
    public Bullet bulletPrefab;
    public int SpawnedBulletCounts;
    Transform target;

    public float spawnRateMin;
    public float spawnRateMax;
    private float spawnRate;
    private float timeAfterSpawn;


}
