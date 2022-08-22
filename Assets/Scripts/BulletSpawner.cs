using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        for (int i = 0; i < SpawnedBulletCounts; i++)
        {
            SpawnBullet();          
        }

        GameManager.GameManagerInstance.onNextLevel += GetSpawnData;
    }

    private void Update()
    {
      

        if (timeAfterSpawn > spawnRate)
        {
            SpawnBullet();
            timeAfterSpawn = 0.0f;
        }
        timeAfterSpawn += Time.deltaTime;
    }
    public void SpawnBullet()
    {
        if (ReferenceEquals(null, projectilePrefab))
        {
            return;
        }

        Projectile bullet =
           Instantiate(projectilePrefab, transform.position, transform.rotation);

        bullet.SetTarget(target);
        bullet.Fire();

        GameManager.GameManagerInstance.addBulletCount();
    }

    public void SetProjectileDataFromSpawnData(SpawnProjectileData spawnData)
    {
        projectilePrefab = spawnData.prefab;
        spawnRate = spawnData.spawnTime;
    }

    private void GetSpawnData()
    {
        int level = GameManager.GameManagerInstance.GameLevel;

        int size = GameManager.GameManagerInstance.spawnDataList.Count;

        if (level < size )
        {
            spawnData = GameManager.GameManagerInstance.spawnDataList[level];
            SetProjectileDataFromSpawnData(spawnData);
        }
    }




    public Vector3 GetRePosition()
    {
        return transform.position;
    }

    public Transform Target
    {
        get { return target; }
    }

    public Projectile ProjectilePrefab
    {
        set { projectilePrefab = value; }
        get { return projectilePrefab; }
    }

    public int SpawnedBulletCounts;
    private Transform target;
    [SerializeField]
    private Projectile projectilePrefab;
    private SpawnProjectileData spawnData;

    [SerializeField]
    private float spawnRate;
    private float timeAfterSpawn;


}
