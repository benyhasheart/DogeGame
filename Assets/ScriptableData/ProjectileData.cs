using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/ProjectileData", fileName = "ProjectileData", order = 0)]
public class ProjectileData : ScriptableObject
{
    public string ObjectName;
    public float damage;
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float intensity;

    public AudioClip dieClip;
    public AudioClip hitClip;
}
