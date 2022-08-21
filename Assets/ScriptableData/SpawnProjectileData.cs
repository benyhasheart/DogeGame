using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/SpawnProjectileData", fileName = "SpawnProjectileData", order = 0)]
public class SpawnProjectileData : ScriptableObject
{
    public Projectile prefab;
    public float spawnTime;
}
